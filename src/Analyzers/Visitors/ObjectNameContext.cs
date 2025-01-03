using System.Collections.Generic;
using System.Diagnostics;
using Coding4Fun.TransactSql.Analyzers.Extensions;
using Coding4Fun.TransactSql.Analyzers.ValidationResults;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// The context of the object inside syntax tree.
/// For example we have:
/// <code>
/// CREATE TABLE Production.Product (ProductID int IDENTITY(1,1) NOT NULL);
/// </code>
/// For the column ProductID the context is: [Schema] Production => [Table] Product => [Column] ProductID.
/// </summary>
[DebuggerDisplay("{GetPath()}")]
public class ObjectNameContext
{
    private readonly LinkedList<Identifier> _identifiers;
    private readonly LinkedList<ObjectNameValidationResult> _objectKinds;

    /// <summary>
    /// Add table to the context.
    /// </summary>
    public ObjectNameContext(CreateTableStatement createTableStatement)
    {
        _identifiers = [];
        _objectKinds = [];
        Add4(createTableStatement.SchemaObjectName, ObjectNameValidationResult.Table);
    }

    /// <summary>
    /// Add procedure to the context.
    /// </summary>
    public ObjectNameContext(ProcedureStatementBody createProcedureStatement)
    {
        _identifiers = [];
        _objectKinds = [];
        Add4(createProcedureStatement.ProcedureReference.Name, ObjectNameValidationResult.Procedure);
    }

    /// <summary>
    /// Add a function to the context.
    /// </summary>
    public ObjectNameContext(FunctionStatementBody createFunctionStatement)
    {
        _identifiers = [];
        _objectKinds = [];
        Add4(createFunctionStatement.Name, ObjectNameValidationResult.Function);
    }

    /// <summary>
    /// Current kind of object.
    /// </summary>
    public ObjectNameValidationResult CurrentKind => _objectKinds.Last.Value;

    /// <summary>
    /// Last part of identifiers inside the context.
    /// </summary>
    public Identifier LastIdentifier => _identifiers.Last.Value;

    private void Add4(SchemaObjectName schemaObjectName, ObjectNameValidationResult lastKind)
    {
        if (schemaObjectName.ServerIdentifier != null)
        {
            _identifiers.AddLast(schemaObjectName.ServerIdentifier);
            _objectKinds.AddLast(ObjectNameValidationResult.Server);
        }

        if (schemaObjectName.DatabaseIdentifier != null)
        {
            _identifiers.AddLast(schemaObjectName.DatabaseIdentifier);
            _objectKinds.AddLast(ObjectNameValidationResult.Database);
        }

        if (schemaObjectName.SchemaIdentifier != null)
        {
            _identifiers.AddLast(schemaObjectName.SchemaIdentifier);
            _objectKinds.AddLast(ObjectNameValidationResult.Schema);
        }

        if (schemaObjectName.BaseIdentifier != null)
        {
            _identifiers.AddLast(schemaObjectName.BaseIdentifier);
            _objectKinds.AddLast(lastKind);
        }
    }

    /// <summary>
    /// Add a column to the context.
    /// </summary>
    public void Add(ColumnDefinition columnDefinition)
    {
        _identifiers.AddLast(columnDefinition.ColumnIdentifier);
        _objectKinds.AddLast(ObjectNameValidationResult.Column);
    }

    /// <summary>
    /// Add a constraint to the context.
    /// </summary>
    public void Add(ConstraintDefinition constraintDefinition)
    {
        switch (constraintDefinition)
        {
            case UniqueConstraintDefinition uniqueConstraint:
                _identifiers.AddLast(constraintDefinition.ConstraintIdentifier);
                _objectKinds.AddLast(uniqueConstraint.IsPrimaryKey
                    ? ObjectNameValidationResult.PrimaryKeyConstraint
                    : ObjectNameValidationResult.UniqueConstraint);
                break;
            case CheckConstraintDefinition:
                _identifiers.AddLast(constraintDefinition.ConstraintIdentifier);
                _objectKinds.AddLast(ObjectNameValidationResult.CheckConstraint);
                break;
            case DefaultConstraintDefinition:
                _identifiers.AddLast(constraintDefinition.ConstraintIdentifier);
                _objectKinds.AddLast(ObjectNameValidationResult.DefaultConstraint);
                break;
        }
    }

    /// <summary>
    /// Add an index to the context.
    /// </summary>
    public void Add(IndexDefinition indexDefinition)
    {
        var hasMapping = true;
        switch (indexDefinition.IndexType.IndexTypeKind)
        {
            case IndexTypeKind.ClusteredColumnStore:
                _objectKinds.AddLast(ObjectNameValidationResult.ClusteredColumnStoreIndex);
                break;
            case IndexTypeKind.NonClusteredColumnStore:
                _objectKinds.AddLast(ObjectNameValidationResult.NonClusteredColumnStoreIndex);
                break;
            case IndexTypeKind.Clustered:
                _objectKinds.AddLast(indexDefinition.Unique
                    ? ObjectNameValidationResult.BTreeUniqueClusteredIndex
                    : ObjectNameValidationResult.BTreeNonUniqueClusteredIndex);
                break;
            case IndexTypeKind.NonClustered:
                _objectKinds.AddLast(indexDefinition.Unique
                    ? ObjectNameValidationResult.BTreeUniqueNonClusteredIndex
                    : ObjectNameValidationResult.BTreeNonUniqueNonClusteredIndex);
                break;
            default:
                hasMapping = false;
                break;
        }

        if (hasMapping) _identifiers.AddLast(indexDefinition.Name);
    }

    /// <summary>
    /// Add a parameter to the context.
    /// </summary>
    public void Add(ProcedureParameter procedureParameter)
    {
        _objectKinds.AddLast(ObjectNameValidationResult.RoutineParameter);
        _identifiers.AddLast(procedureParameter.VariableName);
    }

    /// <summary>
    /// Remove a last element from the context.
    /// </summary>
    public void RemoveLast()
    {
        _identifiers.RemoveLast();
        _objectKinds.RemoveLast();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public string RenderPattern(string pattern)
    {
        Debug.Assert(_identifiers.Count == _objectKinds.Count,
            "Count of identifiers must equals to count of object kinds.");

        string renderedString = pattern;

        LinkedListNode<Identifier>? identifierNode = _identifiers.First;
        LinkedListNode<ObjectNameValidationResult>? objectKindNode = _objectKinds.First;
        do
        {
            renderedString = renderedString.Replace("{" + objectKindNode.Value + "}", identifierNode.Value.Value);
            identifierNode = identifierNode.Next;
            objectKindNode = objectKindNode.Next;
        } while (identifierNode != null && objectKindNode != null);

        return renderedString;
    }

    /// <summary>
    /// Get the full path with all elements.
    /// </summary>
    public string GetPath() => _identifiers.GetPath();

    /// <summary>
    /// Add a variable to the context.
    /// </summary>
    public void Add(DeclareVariableElement declareVariableElement)
    {
        _objectKinds.AddLast(ObjectNameValidationResult.Variable);
        _identifiers.AddLast(declareVariableElement.VariableName);
    }
}
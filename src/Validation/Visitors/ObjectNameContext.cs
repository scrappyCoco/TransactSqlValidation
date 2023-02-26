using System.Collections.Generic;
using System.Diagnostics;
using Coding4fun.TransactSql.Validations.Extensions;
using Coding4fun.TransactSql.Validations.ValidationResults;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    [DebuggerDisplay("{GetPath()}")]
    public class ObjectNameContext
    {
        private readonly LinkedList<Identifier> _identifiers;
        private readonly LinkedList<ObjectNameValidationResult> _objectKinds;

        public ObjectNameContext(CreateTableStatement createTableStatement)
        {
            _identifiers = new LinkedList<Identifier>();
            _objectKinds = new LinkedList<ObjectNameValidationResult>();
            Add4(createTableStatement.SchemaObjectName, ObjectNameValidationResult.Table);
        }

        public ObjectNameContext(ProcedureStatementBody createProcedureStatement)
        {
            _identifiers = new LinkedList<Identifier>();
            _objectKinds = new LinkedList<ObjectNameValidationResult>();
            Add4(createProcedureStatement.ProcedureReference.Name, ObjectNameValidationResult.Procedure);
        }

        public ObjectNameContext(FunctionStatementBody createFunctionStatement)
        {
            _identifiers = new LinkedList<Identifier>();
            _objectKinds = new LinkedList<ObjectNameValidationResult>();
            Add4(createFunctionStatement.Name, ObjectNameValidationResult.Function);
        }

        public ObjectNameValidationResult CurrentKind => _objectKinds.Last.Value;

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

        public void Add(ColumnDefinition columnDefinition)
        {
            _identifiers.AddLast(columnDefinition.ColumnIdentifier);
            _objectKinds.AddLast(ObjectNameValidationResult.Column);
        }

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
                case CheckConstraintDefinition _:
                    _identifiers.AddLast(constraintDefinition.ConstraintIdentifier);
                    _objectKinds.AddLast(ObjectNameValidationResult.CheckConstraint);
                    break;
                case DefaultConstraintDefinition _:
                    _identifiers.AddLast(constraintDefinition.ConstraintIdentifier);
                    _objectKinds.AddLast(ObjectNameValidationResult.DefaultConstraint);
                    break;
            }
        }

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

        public void Add(ProcedureParameter procedureParameter)
        {
            _objectKinds.AddLast(ObjectNameValidationResult.RoutineParameter);
            _identifiers.AddLast(procedureParameter.VariableName);
        }
        
        public void RemoveLast()
        {
            _identifiers.RemoveLast();
            _objectKinds.RemoveLast();
        }

        public string RenderPattern(string pattern)
        {
            Debug.Assert(_identifiers.Count == _objectKinds.Count,
                "Count of identifiers must equals to count of object kinds.");

            var renderedString = pattern;

            var identifierNode = _identifiers.First;
            var objectKindNode = _objectKinds.First;
            do
            {
                renderedString = renderedString.Replace("{" + objectKindNode.Value + "}", identifierNode.Value.Value);
                identifierNode = identifierNode.Next;
                objectKindNode = objectKindNode.Next;
            } while (identifierNode != null && objectKindNode != null);

            return renderedString;
        }

        public string GetPath() => _identifiers.GetPath();

        public void Add(DeclareVariableElement declareVariableElement)
        {
            _objectKinds.AddLast(ObjectNameValidationResult.Variable);
            _identifiers.AddLast(declareVariableElement.VariableName);
        }
    }
}
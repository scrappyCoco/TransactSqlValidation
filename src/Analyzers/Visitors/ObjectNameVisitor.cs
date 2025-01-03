using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Coding4Fun.TransactSql.Analyzers.Configuration;
using Coding4Fun.TransactSql.Analyzers.Extensions;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Result = Coding4Fun.TransactSql.Analyzers.ValidationResults.ObjectNameValidationResult;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Visitor, which checks names of object for naming rules, that defined in the configuration procedure dbo.SqlAnalysisConfiguration.
/// </summary>
public class ObjectNameVisitor : SqlVisitorBase
{
    private readonly Dictionary<Result, NamingRule> _namingRules = [];
    private readonly TimeSpan _regexTimeout = TimeSpan.FromSeconds(1d);
    private ObjectNameContext? _objectNameContext;

    private void ValidateObjectName(ObjectNameContext context)
    {
        Result currentObjectKind = context.CurrentKind;
        if (!_namingRules.TryGetValue(currentObjectKind, out NamingRule objectNameProperlyPattern)) return;

        string renderPattern = context.RenderPattern(objectNameProperlyPattern.CompiledPattern);
        string fullName = context.GetPath();

        bool isValidObjectName =
            new Regex(renderPattern, RegexOptions.None, _regexTimeout).IsMatch(fullName);

        if (!isValidObjectName)
            //if (_ignoreRegexes.Any(regex => regex.IsMatch(fullName))) return;
            AddValidationResult((int)currentObjectKind, context.LastIdentifier);
    }

    /// <inheritdoc />
    public override void Visit(CreateTableStatement tableStatement)
    {
        ObjectNameContext context = new ObjectNameContext(tableStatement);
        ValidateObjectName(context);

        foreach (ColumnDefinition columnDefinition in tableStatement.Definition.ColumnDefinitions)
        {
            context.Add(columnDefinition);
            ValidateObjectName(context);

            if (columnDefinition.Constraints?.Any() ?? false)
                foreach (ConstraintDefinition constraint in columnDefinition.Constraints)
                    ValidateConstraint(constraint, context);

            if (columnDefinition.DefaultConstraint != null)
                ValidateConstraint(columnDefinition.DefaultConstraint, context);

            if (columnDefinition.Index != null)
            {
                context.Add(columnDefinition.Index);
                ValidateObjectName(context);
                context.RemoveLast();
            }

            context.RemoveLast();
        }

        if (tableStatement.Definition.TableConstraints?.Any() ?? false)
            foreach (ConstraintDefinition constraint in tableStatement.Definition.TableConstraints)
                ValidateConstraint(constraint, context);

        if (!(tableStatement.Definition.Indexes?.Any() ?? false)) return;
        foreach (IndexDefinition index in tableStatement.Definition.Indexes)
        {
            context.Add(index);
            ValidateObjectName(context);
            context.RemoveLast();
        }
    }

    /// <inheritdoc />
    public override void Visit(CreateProcedureStatement procedureStatement)
    {
        _objectNameContext = new ObjectNameContext(procedureStatement);
        ValidateObjectName(_objectNameContext);

        if (procedureStatement.Parameters == null) return;
        foreach (ProcedureParameter procedureParameter in procedureStatement.Parameters)
        {
            _objectNameContext.Add(procedureParameter);
            ValidateObjectName(_objectNameContext);
            _objectNameContext.RemoveLast();
        }
    }

    /// <inheritdoc />
    public override void Visit(CreateFunctionStatement functionStatement)
    {
        _objectNameContext = new ObjectNameContext(functionStatement);
        ValidateObjectName(_objectNameContext);
            
        if (functionStatement.Parameters == null) return;
        foreach (ProcedureParameter parameter in functionStatement.Parameters)
        {
            _objectNameContext.Add(parameter);
            ValidateObjectName(_objectNameContext);
            _objectNameContext.RemoveLast();
        }
    }

    /// <inheritdoc />
    public override void Visit(DeclareVariableStatement declareVariableStatement)
    {
        foreach (var declareVariableElement in declareVariableStatement.Declarations)
        {
            if (_objectNameContext == null)
                throw new SqlValidationException($"Method {nameof(DeclareVariableStatement)} has invalid state.");

            _objectNameContext.Add(declareVariableElement);
            ValidateObjectName(_objectNameContext);
            _objectNameContext.RemoveLast();
        }
    }

    /// <summary>
    /// Add naming rules
    /// </summary>
    public void AddNamingRules(Dictionary<Result, NamingRule> rules) => _namingRules.AddRange(rules);

    private void ValidateConstraint(ConstraintDefinition constraint, ObjectNameContext context)
    {
        // In case of:
        // CREATE TABLE[dbo].[MY_TABLE]
        // (
        //    [MY_TABLE_ID] INT NOT NULL PRIMARY KEY
        // );
        if (constraint.ConstraintIdentifier == null) return;

        context.Add(constraint);
        ValidateObjectName(context);
        context.RemoveLast();
    }
}
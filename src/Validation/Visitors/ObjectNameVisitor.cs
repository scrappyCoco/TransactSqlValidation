using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Result = Coding4fun.TransactSql.Validations.ValidationResults.ObjectNameValidationResult;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    public class ObjectNameVisitor : SqlVisitorBase
    {
        private readonly Dictionary<Result, string>
            _objectNamePatterns = new Dictionary<Result, string>();

        private readonly TimeSpan _regexTimeout = TimeSpan.FromSeconds(1d);

        private ObjectNameContext _objectNameContext;

        private void ValidateObjectName(ObjectNameContext context)
        {
            var currentObjectKind = context.CurrentKind;
            if (!_objectNamePatterns.TryGetValue(currentObjectKind, out var objectNameProperlyPattern)) return;

            objectNameProperlyPattern = context.RenderPattern(objectNameProperlyPattern);
            var fullName = context.GetPath();

            var isValidObjectName =
                new Regex(objectNameProperlyPattern, RegexOptions.None, _regexTimeout).IsMatch(fullName);

            if (!isValidObjectName)
                //if (_ignoreRegexes.Any(regex => regex.IsMatch(fullName))) return;
                AddValidationResult((int)currentObjectKind, context.LastIdentifier);
        }

        public override void Visit(CreateTableStatement tableStatement)
        {
            var context = new ObjectNameContext(tableStatement);
            ValidateObjectName(context);

            foreach (var columnDefinition in tableStatement.Definition.ColumnDefinitions)
            {
                context.Add(columnDefinition);
                ValidateObjectName(context);

                if (columnDefinition.Constraints?.Any() ?? false)
                    foreach (var constraint in columnDefinition.Constraints)
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
                foreach (var constraint in tableStatement.Definition.TableConstraints)
                    ValidateConstraint(constraint, context);

            if (!(tableStatement.Definition.Indexes?.Any() ?? false)) return;
            foreach (var index in tableStatement.Definition.Indexes)
            {
                context.Add(index);
                ValidateObjectName(context);
                context.RemoveLast();
            }
        }

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
                _objectNameContext.Add(declareVariableElement);
                ValidateObjectName(_objectNameContext);
                _objectNameContext.RemoveLast();
            }
        }

        public void AddNamingRules(Dictionary<Result, string> rules)
        {
            if (rules == null) return;
            foreach (var rule in rules) _objectNamePatterns.Add(rule.Key, rule.Value);
        }

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
}
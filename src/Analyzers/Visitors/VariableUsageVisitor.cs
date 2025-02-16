using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Coding4Fun.TransactSql.Analyzers.Extensions;
using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.TransactSql.ScriptDom;

/// <summary>
/// Finds defined variables, that were never used.
/// </summary>
public class VariableUsageVisitor : SqlVisitorBase
{
    private readonly Dictionary<string, bool> _variableName2UsageMark = new(StringComparer.InvariantCultureIgnoreCase);
    private readonly Dictionary<string, Identifier> _variableName2Definition = new(StringComparer.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    public override void Visit(DeclareVariableElement node)
    {
        const bool isVariableUsed = false;
        _variableName2UsageMark.Add(node.VariableName.Value, isVariableUsed);
        _variableName2Definition.Add(node.VariableName.Value, node.VariableName);
        base.Visit(node);
    }

    /// <inheritdoc />
    public override void Visit(VariableReference variableReference)
    {
        if (IsVarUsedForRead(PathContext, variableReference))
        {
            const bool usedForWrite = true;
            _variableName2UsageMark[variableReference.Name] = usedForWrite;
        }

        base.Visit(variableReference);
    }

    /// <inheritdoc />
    public override void Visit(ProcedureParameter procedureParameter)
    {
        // CREATE PROCEDURE dbo.T @i INT OUTPUT
        // AS
        // BEGIN
        //     ...
        // END
        if (procedureParameter.Modifier.HasFlag(ParameterModifier.Output))
        {
            const bool usedForWrite = true;
            _variableName2UsageMark[procedureParameter.VariableName.Value] = usedForWrite;
        }
        base.Visit(procedureParameter);
    }

    [Pure]
    private static bool IsVarUsedForRead(
        IReadOnlyCollection<TSqlFragment> pathContext,
        VariableReference variableReference
        )
    {
        return
            // IF (@someUsefulValue = 1) PRINT '@someUsefulValue is used';
            pathContext.Any(ancestor => ancestor is IfStatement) ||

            // SELECT t
            // FROM dbo.MY_TABLE
            // WHERE t < @someUsefulValue
            pathContext.Any(ancestor => ancestor is SelectStatement)
            // SELECT @someUsefulValue = 1
            // --     ^ SelectSetVariable ^
            // FROM dbo.MY_TABLE;
            && !pathContext.Any(ancestor => ancestor is SelectSetVariable selectSetVariable && selectSetVariable.Variable.Name.Equals(variableReference.Name, StringComparison.InvariantCultureIgnoreCase)) ||

            // EXEC #StoredProcedure @someUsefulValue;
            pathContext.Any(ancestor => ancestor is ExecuteStatement) ||

            // DECLARE @a INT = 1;
            // DECLARE @b INT = @a;
            pathContext.Any(ancestor => ancestor is DeclareVariableStatement) ||

            // DECLARE @i INT = 1;
            // RETURN @i;
            pathContext.Any(ancestor => ancestor is ReturnStatement) ||

            // DECLARE @a INT = 1, @b INT;
            // SET @b = @a;
            (pathContext
                .OfType<SetVariableStatement>()
                .FirstOrDefault()
                ?.Let(setStatement => !setStatement.Variable.Name.Equals(variableReference.Name, StringComparison.InvariantCultureIgnoreCase))
                ?? false) ||

            // UPDATE/DELETE/INSERT/MERGE. Example:
            // DECLARE @i INT = 1;
            // INSERT INTO #T (C)
            // VALUES (@i);
            pathContext.Any(ancestor => ancestor is DataModificationStatement) ||

            // WHILE @i <= 10
            pathContext.Any(ancestor => ancestor is WhileStatement) ||

            // DECLARE @msg NVARCHAR(2048) = 'Something goes wrong';
            // THROW 60000, @msg, 1;
            pathContext.Any(ancestor => ancestor is ThrowStatement) ||

            // DECLARE @Delay1 DATETIME = '00:00:02';
            // WAITFOR DELAY @Delay1;
            pathContext.Any(ancestor => ancestor is WaitForStatement);
    }

    /// <inheritdoc />
    protected override void OnGettingValidationResult()
    {
        foreach ((string varName, bool isVarUsed) in _variableName2UsageMark)
        {
            if (isVarUsed) continue;
            Identifier varDefinition = _variableName2Definition[varName];
            AddValidationResult(0, varDefinition);
        }
        base.OnGettingValidationResult();
    }
}
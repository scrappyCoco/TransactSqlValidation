#nullable enable
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Base visitor for TSQL validations.
/// </summary>
public abstract class SqlVisitorBase : TSqlFragmentVisitor
{
    private static readonly LinkedList<ValidationResult> EmptyList = [];
    private LinkedList<ValidationResult>? _validationResults;
    private LinkedList<TSqlFragment> _pathContext = [];
    private bool _hasBeenCompleted = false;

    /// <summary>
    /// Problems that were found during validation.
    /// </summary>
    public IEnumerable<ValidationResult> ValidationResults
    {
        get
        {
            if (!_hasBeenCompleted)
            {
                OnGettingValidationResult();
                _hasBeenCompleted = true;
            }
            
            return _validationResults ?? EmptyList;
        }
    }

    /// <summary>
    /// Occurs when <see cref="ValidationResults"/> is getting/using.
    /// It executes only one time.
    /// </summary>
    protected virtual void OnGettingValidationResult()
    {
    }

    /// <summary>
    /// Path to the current element. These collection consists for parent and ancestors.
    /// </summary>
    protected IReadOnlyCollection<TSqlFragment> PathContext => _pathContext;

    /// <summary>
    /// Add validation error.
    /// </summary>
    /// <param name="resultCode">Error code.</param>
    /// <param name="invalidFragment">Part of the code with smell.</param>
    public void AddValidationResult(int resultCode, TSqlFragment invalidFragment)
    {
        _validationResults ??= [];
        _validationResults.AddLast(new ValidationResult(invalidFragment, resultCode));
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StatementList node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResultSetsExecuteOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResultSetDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InlineResultSetDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResultColumnDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectResultSetDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteContext node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecutableEntity node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureReferenceName node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecutableProcedureReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecutableStringList node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AdHocDataSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterViewStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateViewStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterViewStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewStatementBody node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewForAppendOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewDistributionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewRoundRobinDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ViewHashDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TriggerObject node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TriggerOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsTriggerOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TriggerAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTriggerStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateTriggerStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterTriggerStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TriggerStatementBody node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(Identifier node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterProcedureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateProcedureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterProcedureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MethodSpecifier node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureStatementBody node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureStatementBodyBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FunctionStatementBody node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsProcedureOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FunctionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InlineFunctionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsFunctionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespaces node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespacesElement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespacesDefaultElement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespacesAliasElement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CommonTableExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WithCtesAndXmlNamespaces node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FunctionReturnType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableValuedFunctionReturnType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataTypeReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ParameterizedDataTypeReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SqlDataTypeReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UserDataTypeReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlDataTypeReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarFunctionReturnType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectFunctionReturnType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeclareTableVariableBody node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeclareTableVariableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NamedTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexTableHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralTableHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryDerivedTable node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InlineDerivedTable node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SubqueryComparisonPredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExistsPredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LikePredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DistinctPredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InPredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextPredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UserDefinedTypePropertyAccess node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ForClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BrowseForClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ReadOnlyForClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlForClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlForClauseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(JsonForClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(JsonKeyValue node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(JsonForClauseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateForClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OptimizerHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralOptimizerHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableHintsOptimizerHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ForceSeekTableHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OptimizeForOptimizerHint node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UseHintList node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(VariableValuePair node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WhenClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SimpleWhenClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SearchedWhenClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CaseExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SimpleCaseExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SearchedCaseExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NullIfExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CoalesceExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IIfCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SemanticTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenXmlTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenJsonTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InternalOpenRowset node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetCosmos node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BulkOpenRowset node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetColumnDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenQueryTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AdHocTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaDeclarationItem node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaDeclarationItemOpenjson node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ConvertCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TryConvertCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ParseCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TryParseCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CastCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TryCastCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AtTimeZoneCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FunctionCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CallTarget node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExpressionCallTarget node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MultiPartIdentifierCallTarget node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UserDefinedTypeCallTarget node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LeftFunctionCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RightFunctionCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PartitionFunctionCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OverClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WindowClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WindowDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ParameterlessCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarSubquery node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OdbcFunctionCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExtractFromExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OdbcConvertSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BeginEndBlockStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BeginEndAtomicBlockStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AtomicBlockOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralAtomicBlockOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierAtomicBlockOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffAtomicBlockOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BeginTransactionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BreakStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnWithSortOrder node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CommitTransactionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RollbackTransactionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SaveTransactionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ContinueStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateDefaultStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateRuleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeclareVariableElement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeclareVariableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GoToStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IfStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LabelStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MultiPartIdentifier node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectName node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChildObjectName node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TransactionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WhileStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeleteStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateDeleteSpecificationBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeleteSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InsertStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InsertSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSchemaStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WaitForStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ReadTextStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateTextStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WriteTextStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TextModificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LineNoStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GrantStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DenyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RevokeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAuthorizationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(Permission node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityTargetObject node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityTargetObjectName node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPrincipal node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityStatementBody80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GrantStatement80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DenyStatement80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RevokeStatement80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityElement80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CommandSecurityElement80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PrivilegeSecurityElement80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(Privilege80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityUserClause80 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SqlCommandIdentifier node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AssignmentSetClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FunctionCallSetClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InsertSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ValuesInsertSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectInsertSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteInsertSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RowValue node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PrintStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TSEqualCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PrimaryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(Literal node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IntegerLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NumericLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RealLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MoneyLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BinaryLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StringLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NullLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DefaultLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OdbcLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralRange node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ValueExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(VariableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OptionValue node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffOptionValue node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralOptionValue node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GlobalVariableExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierOrValueExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierOrScalarExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectNameOrValueExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ParenthesisExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnReferenceExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NextValueForExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SequenceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SequenceOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataTypeSequenceOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionSequenceOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSequenceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterSequenceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSequenceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPolicyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPredicateAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPolicyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSecurityPolicyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterSecurityPolicyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSecurityPolicyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateColumnMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyPathParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyEnclaveComputationsParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropColumnMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropColumnEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyValue node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyValueParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyNameParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EncryptedValueParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableDistributionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableRejectTypeOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalDataSourceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalDataSourceOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalDataSourceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalDataSourceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalDataSourceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamLiteralOrIdentifierOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalStreamStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalStreamStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatLiteralOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatContainerOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalFileFormatStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalFileFormatStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamingJobStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalStreamingJobStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalStreamingJobStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateAssemblyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAssemblyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffAssemblyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PermissionSetAssemblyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AddFileSpec node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropXmlSchemaCollectionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyName node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAlterPartitionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableRebuildStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableSetStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LockEscalationTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamOnTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileTableDirectoryTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileTableCollateFileNameTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileTableConstraintNameTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MemoryOptimizedTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DurabilityTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDatabaseSetting node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDbServerSetting node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RetentionPeriodDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SystemVersioningTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LedgerTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LedgerViewOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataRetentionTableOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAddTableElementStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableConstraintModificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableSwitchStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableSwitchOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TruncateTargetTableSwitchOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintStateOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintValueOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintMoveOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableDropTableElement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableDropTableElementStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableTriggerModificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EnableDisableTriggerStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TryCatchStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeUdtStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeUddtStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSynonymStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueStateOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueProcedureOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueValueOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueExecuteAsOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RouteOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RouteStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterRouteStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateRouteStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterQueueStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateQueueStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SystemTimePeriodDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PartitionSpecifier node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateXmlIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileGroupOrPartitionScheme node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexStateOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IndexExpressionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxDurationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WaitAtLowPriorityOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnlineIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IgnoreDupKeyIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OrderIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextIndexColumn node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateFullTextIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StopListFullTextIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextCatalogAndFileGroup node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventTypeGroupContainer node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventTypeContainer node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventGroupContainer node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateEventNotificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventNotificationObjectScope node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ApplicationRoleOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ApplicationRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateApplicationRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterApplicationRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterRoleAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RenameAlterRoleAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AddMemberAlterRoleAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropMemberAlterRoleAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateServerRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropServerRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UserLoginOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UserStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateUserStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterUserStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StatisticsOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResampleStatisticsOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StatisticsPartitionRange node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffStatisticsOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralStatisticsOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateStatisticsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateStatisticsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ReturnStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeclareCursorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CursorDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CursorOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetVariableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CursorId node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CursorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenCursorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CloseCursorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CryptoMechanism node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenSymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CloseSymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CloseMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeallocateCursorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FetchType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FetchCursorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WhereClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropUnownedObjectStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropObjectsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropDatabaseStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropChildObjectsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropIndexClauseBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropIndexClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MoveToDropIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamOnDropIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropStatisticsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropProcedureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropViewStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropDefaultStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropRuleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropTriggerStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSchemaStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RaiseErrorLegacyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RaiseErrorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ThrowStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UseStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(KillStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(KillStatsJobStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CheckpointStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ReconfigureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ShutdownStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetUserStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TruncateTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetOnOffStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PredicateSetStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetStatisticsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetRowCountStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetOffsetsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetCommand node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GeneralSetCommand node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetFipsFlaggerCommand node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetCommandStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetTransactionIsolationLevelStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetTextSizeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetIdentityInsertStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetErrorLevelStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateDatabaseStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileDeclaration node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileDeclarationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NameFileDeclarationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileNameFileDeclarationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SizeFileDeclarationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxSizeFileDeclarationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileGrowthFileDeclarationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileGroupDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseScopedConfigurationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseConfigurationClearOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseConfigurationSetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffPrimaryConfigurationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxDopConfigurationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DWCompatibilityLevelConfigurationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GenericConfigurationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseCollateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseAddFileStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseModifyNameStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseModifyFileStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseTermination node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseSetStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ContainmentDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(HadrDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DelayedDurabilityDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CursorDefaultDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RecoveryDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PageVerifyDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PartnerDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WitnessDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ParameterizationDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTrackingDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTrackingOptionDetail node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AcceleratedDatabaseRecoveryDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreDesiredStateOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreCapturePolicyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreIntervalLengthOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningCreateIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningDropIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CatalogCollationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LedgerOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxSizeDatabaseOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAlterIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAlterColumnStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionDefinitionParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionTypeParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentityOptions node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnStorageOptions node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FederationScheme node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableDataCompressionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableXmlCompressionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableDistributionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableReplicateDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableRoundRobinDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableHashDistributionPolicy node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableIndexType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableClusteredIndexType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableNonClusteredIndexType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TablePartitionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PartitionSpecifications node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TablePartitionOptionSpecifications node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LocationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RenameEntityStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CopyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CopyStatementOptionBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CopyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CopyCredentialOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SingleValueTypeCopyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ListTypeCopyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CopyColumnOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataCompressionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(XmlCompressionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CompressionPartitionRange node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CheckConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DefaultConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(NullableConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphConnectionBetweenNodes node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphConnectionConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UniqueConstraintDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupDatabaseStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupTransactionLogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RestoreStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RestoreOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionRestoreOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MoveRestoreOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StopRestoreOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamRestoreOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupEncryptionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeviceInfo node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MirrorToClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupRestoreFileInfo node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BulkInsertBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BulkInsertStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InsertBulkStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BulkInsertOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetCosmosOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralOpenRowsetCosmosOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralBulkInsertOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OrderBulkInsertOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ColumnDefinitionBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableColumnDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InsertBulkColumnDefinition node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DbccStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DbccOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DbccNamedLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateAsymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreatePartitionFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PartitionParameterType node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreatePartitionSchemeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteServiceBindingStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RemoteServiceBindingOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffRemoteServiceBindingOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UserRemoteServiceBindingOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateRemoteServiceBindingStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterRemoteServiceBindingStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EncryptionSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyEncryptionSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FileEncryptionSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProviderEncryptionSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CertificateStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterCertificateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateCertificateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CertificateOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateContractStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ContractMessage node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CredentialStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateCredentialStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterCredentialStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MessageTypeStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateMessageTypeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterMessageTypeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateAggregateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateEndpointStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterEndpointStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterCreateEndpointStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EndpointAffinity node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EndpointProtocolOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralEndpointProtocolOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuthenticationEndpointProtocolOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PortsEndpointProtocolOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CompressionEndpointProtocolOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ListenerIPEndpointProtocolOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IPv4 node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SoapMethod node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EnabledDisabledPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WsdlPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LoginTypePayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SessionTimeoutPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CharacterSetPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RolePayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuthenticationPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EncryptionPayloadOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(KeyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(KeySourceKeyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlgorithmKeyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentityValueKeyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProviderKeyNameKeyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreationDispositionKeyOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterSymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextCatalogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextCatalogOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffFullTextCatalogOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateFullTextCatalogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextCatalogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterCreateServiceStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateServiceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServiceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ServiceContract node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BinaryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BuiltInFunctionTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GlobalFunctionTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ComputeClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ComputeFunction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PivotedTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UnpivotedTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UnqualifiedJoin node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableSampleClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanNotExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanParenthesisExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanComparisonExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanBinaryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanIsNullExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchPredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchLastNodePredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchNodeExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchRecursivePredicate node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchCompositeExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GraphRecursiveMatchQuantifier node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExpressionWithSortOrder node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GroupByClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExpressionGroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CompositeGroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CubeGroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RollupGroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GrandTotalGroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GroupingSetsGroupingSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OutputClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OutputIntoClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(HavingClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentityFunctionCall node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(JoinParenthesisTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OrderByClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(JoinTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QualifiedJoin node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OdbcQualifiedJoinTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueryParenthesisExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QuerySpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FromClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PredictTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectElement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectScalarExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectStarExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectSetVariable node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableReferenceWithAlias node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TableReferenceWithAliasAndColumns node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataModificationTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTableChangesTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTableVersionTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanTernaryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TopRowFilter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OffsetClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UnaryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BinaryQueryExpression node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(VariableTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(VariableMethodCallTableReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropPartitionFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropPartitionSchemeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSynonymStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropAggregateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropAssemblyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropApplicationRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropFullTextCatalogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropFullTextIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropLoginStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropRoleStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropTypeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropUserStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropAsymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropCertificateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropCredentialStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterPartitionFunctionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterPartitionSchemeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SimpleAlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropAlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AddAlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSearchPropertyListStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterSearchPropertyListStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SearchPropertyListAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AddSearchPropertyListAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSearchPropertyListAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSearchPropertyListStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateLoginStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateLoginSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PasswordCreateLoginSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PrincipalOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffPrincipalOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralPrincipalOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierPrincipalOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WindowsCreateLoginSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalCreateLoginSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CertificateCreateLoginSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PasswordAlterPrincipalOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginOptionsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginEnableDisableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RevertStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropContractStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropEndpointStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropMessageTypeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropQueueStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropRemoteServiceBindingStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropRouteStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropServiceStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SignatureStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AddSignatureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSignatureStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropEventNotificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EndConversationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MoveConversationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GetConversationGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ReceiveStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SendStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WaitForSupportedStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterSchemaStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAsymmetricKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServiceMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BeginConversationTimerStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BeginDialogStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DialogOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionDialogOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffDialogOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupCertificateStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupRestoreMasterKeyStatementBase node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupServiceMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RestoreServiceMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BackupMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RestoreMasterKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BooleanExpressionSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StatementListSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectStatementSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectNameSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TSqlFragmentSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TSqlStatementSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierSnippet node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TSqlScript node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TSqlBatch node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TSqlStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataModificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DataModificationSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MergeStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MergeSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MergeActionClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MergeAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UpdateMergeAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DeleteMergeAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(InsertMergeAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeTableStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SensitivityClassificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SensitivityClassificationOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AddSensitivityClassificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropSensitivityClassificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditSpecificationPart node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditSpecificationDetail node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditActionSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseAuditAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditActionGroupReference node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateServerAuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerAuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropServerAuditSpecificationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ServerAuditStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateServerAuditStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerAuditStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropServerAuditStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditTarget node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(QueueDelayAuditOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditGuidAuditOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnFailureAuditOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OperatorAuditOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(StateAuditOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AuditTargetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxSizeAuditTargetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(RetentionDaysAuditTargetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralAuditTargetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffAuditTargetOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResourcePoolParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ResourcePoolAffinitySpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalResourcePoolParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalResourcePoolStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupResourceParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupImportanceParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateWorkloadGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterWorkloadGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropWorkloadGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadClassifierStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadClassifierOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierWorkloadGroupOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierMemberNameOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierWlmLabelOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierImportanceOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierWlmContextOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierStartTimeOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierEndTimeOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WlmTimeLiteral node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateWorkloadClassifierStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropWorkloadClassifierStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BrokerPriorityStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BrokerPriorityParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateBrokerPriorityStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterBrokerPriorityStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropBrokerPriorityStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateFullTextStopListStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextStopListStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FullTextStopListAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropFullTextStopListStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateCryptographicProviderStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterCryptographicProviderStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropCryptographicProviderStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventSessionObjectName node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventSessionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateEventSessionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventDeclaration node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventDeclarationSetParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SourceDeclaration node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TargetDeclaration node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SessionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(EventRetentionSessionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MemoryPartitionSessionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralSessionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(MaxDispatchLatencySessionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(OnOffSessionOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterEventSessionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropEventSessionStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterResourceGovernorStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateSpatialIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SpatialIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SpatialIndexRegularOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BoundingBoxSpatialIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(BoundingBoxParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GridsSpatialIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(GridParameter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ProcessAffinityRange node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateAvailabilityGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityReplica node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityReplicaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralReplicaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityModeReplicaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(FailoverModeReplicaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(PrimaryRoleReplicaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SecondaryRoleReplicaOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityGroupOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(LiteralAvailabilityGroupOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropAvailabilityGroupStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateFederationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterFederationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropFederationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(UseFederationStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DiskStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DiskStatementOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateColumnStoreIndexStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WindowFrameClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WindowDelimiter node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(WithinGroupClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(TemporalClause node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CompressionDelayIndexOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLibraryStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalLibraryStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalLibraryStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLibraryFileOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalLibraryStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLanguageStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalLanguageStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalLanguageStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLanguageFileOption node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalLanguageStatement node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }
    /// <inheritdoc />
    public override void ExplicitVisit(ElasticPoolSpecification node)
    {
        _pathContext.AddLast(node);
        base.ExplicitVisit(node);
        _pathContext.RemoveLast();
    }

}
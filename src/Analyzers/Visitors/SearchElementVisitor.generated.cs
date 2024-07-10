// Disable this file for analysis, because it will hung CPU by 100%:
// https://www.jetbrains.com/help/rider/Code_Analysis__Configuring_Warnings.html#exclude_items
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Finds element of <typeparamref name="TSearchElement"/>.
/// </summary>
/// <typeparam name="TSearchElement">Type of elements to be searched.</typeparam>
public class SearchElementVisitor<TSearchElement> : TSqlFragmentVisitor where TSearchElement : TSqlFragment
{
    private readonly List<TSearchElement> _foundElements = [];

    /// <summary>
    /// All found elements of type <typeparamref name="TSearchElement"/>.
    /// </summary>
    public IReadOnlyList<TSearchElement> FoundElements => _foundElements;

    /// <inheritdoc />
    public override void ExplicitVisit(StatementList node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResultSetsExecuteOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResultSetDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InlineResultSetDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResultColumnDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectResultSetDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteContext node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecutableEntity node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureReferenceName node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecutableProcedureReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecutableStringList node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AdHocDataSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterViewStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateViewStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterViewStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewStatementBody node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewForAppendOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewDistributionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewRoundRobinDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ViewHashDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TriggerObject node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TriggerOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsTriggerOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TriggerAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTriggerStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateTriggerStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterTriggerStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TriggerStatementBody node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(Identifier node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterProcedureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateProcedureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterProcedureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MethodSpecifier node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureStatementBody node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureStatementBodyBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FunctionStatementBody node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsProcedureOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FunctionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InlineFunctionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsFunctionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespaces node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespacesElement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespacesDefaultElement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlNamespacesAliasElement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CommonTableExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WithCtesAndXmlNamespaces node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FunctionReturnType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableValuedFunctionReturnType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataTypeReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ParameterizedDataTypeReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SqlDataTypeReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UserDataTypeReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlDataTypeReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarFunctionReturnType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectFunctionReturnType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeclareTableVariableBody node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeclareTableVariableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NamedTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexTableHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralTableHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryDerivedTable node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InlineDerivedTable node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SubqueryComparisonPredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExistsPredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LikePredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DistinctPredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InPredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextPredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UserDefinedTypePropertyAccess node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ForClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BrowseForClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ReadOnlyForClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlForClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlForClauseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(JsonForClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(JsonKeyValue node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(JsonForClauseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateForClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OptimizerHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralOptimizerHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableHintsOptimizerHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ForceSeekTableHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OptimizeForOptimizerHint node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UseHintList node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(VariableValuePair node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WhenClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SimpleWhenClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SearchedWhenClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CaseExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SimpleCaseExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SearchedCaseExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NullIfExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CoalesceExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IIfCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SemanticTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenXmlTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenJsonTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InternalOpenRowset node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetCosmos node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BulkOpenRowset node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetColumnDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenQueryTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AdHocTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaDeclarationItem node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaDeclarationItemOpenjson node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ConvertCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TryConvertCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ParseCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TryParseCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CastCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TryCastCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AtTimeZoneCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FunctionCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CallTarget node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExpressionCallTarget node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MultiPartIdentifierCallTarget node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UserDefinedTypeCallTarget node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LeftFunctionCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RightFunctionCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PartitionFunctionCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OverClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WindowClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WindowDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ParameterlessCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarSubquery node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OdbcFunctionCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExtractFromExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OdbcConvertSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BeginEndBlockStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BeginEndAtomicBlockStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AtomicBlockOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralAtomicBlockOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierAtomicBlockOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffAtomicBlockOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BeginTransactionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BreakStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnWithSortOrder node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CommitTransactionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RollbackTransactionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SaveTransactionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ContinueStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateDefaultStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateOrAlterFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateRuleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeclareVariableElement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeclareVariableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GoToStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IfStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LabelStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MultiPartIdentifier node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectName node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChildObjectName node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcedureParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TransactionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WhileStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeleteStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateDeleteSpecificationBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeleteSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InsertStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InsertSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSchemaStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WaitForStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ReadTextStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateTextStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WriteTextStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TextModificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LineNoStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GrantStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DenyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RevokeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAuthorizationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(Permission node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityTargetObject node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityTargetObjectName node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPrincipal node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityStatementBody80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GrantStatement80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DenyStatement80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RevokeStatement80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityElement80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CommandSecurityElement80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PrivilegeSecurityElement80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(Privilege80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityUserClause80 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SqlCommandIdentifier node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AssignmentSetClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FunctionCallSetClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InsertSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ValuesInsertSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectInsertSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteInsertSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RowValue node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PrintStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TSEqualCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PrimaryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(Literal node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IntegerLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NumericLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RealLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MoneyLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BinaryLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StringLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NullLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DefaultLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OdbcLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralRange node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ValueExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(VariableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OptionValue node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffOptionValue node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralOptionValue node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GlobalVariableExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierOrValueExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierOrScalarExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectNameOrValueExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ParenthesisExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnReferenceExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NextValueForExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SequenceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SequenceOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataTypeSequenceOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionSequenceOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSequenceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterSequenceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSequenceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPolicyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPredicateAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecurityPolicyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSecurityPolicyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterSecurityPolicyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSecurityPolicyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateColumnMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyPathParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyEnclaveComputationsParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropColumnMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropColumnEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyValue node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyValueParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnMasterKeyNameParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EncryptedValueParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableDistributionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableRejectTypeOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalDataSourceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalDataSourceOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalDataSourceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalDataSourceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalDataSourceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamLiteralOrIdentifierOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalStreamStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalStreamStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatLiteralOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalFileFormatContainerOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalFileFormatStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalFileFormatStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalStreamingJobStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalStreamingJobStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalStreamingJobStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateAssemblyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAssemblyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffAssemblyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PermissionSetAssemblyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AddFileSpec node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropXmlSchemaCollectionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyName node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAlterPartitionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableRebuildStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableSetStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LockEscalationTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamOnTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileTableDirectoryTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileTableCollateFileNameTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileTableConstraintNameTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MemoryOptimizedTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DurabilityTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDatabaseSetting node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDbServerSetting node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RetentionPeriodDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SystemVersioningTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LedgerTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LedgerViewOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataRetentionTableOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAddTableElementStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableConstraintModificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableSwitchStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableSwitchOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TruncateTargetTableSwitchOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintStateOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintValueOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropClusteredConstraintMoveOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableDropTableElement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableDropTableElementStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableTriggerModificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EnableDisableTriggerStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TryCatchStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeUdtStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeUddtStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSynonymStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueStateOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueProcedureOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueValueOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueExecuteAsOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RouteOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RouteStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterRouteStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateRouteStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterQueueStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateQueueStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SystemTimePeriodDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PartitionSpecifier node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateXmlIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileGroupOrPartitionScheme node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexStateOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IndexExpressionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxDurationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WaitAtLowPriorityOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnlineIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IgnoreDupKeyIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OrderIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextIndexColumn node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateFullTextIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StopListFullTextIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextCatalogAndFileGroup node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventTypeGroupContainer node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventTypeContainer node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventGroupContainer node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateEventNotificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventNotificationObjectScope node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ApplicationRoleOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ApplicationRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateApplicationRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterApplicationRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterRoleAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RenameAlterRoleAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AddMemberAlterRoleAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropMemberAlterRoleAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateServerRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropServerRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UserLoginOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UserStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateUserStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterUserStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StatisticsOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResampleStatisticsOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StatisticsPartitionRange node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffStatisticsOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralStatisticsOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateStatisticsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateStatisticsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ReturnStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeclareCursorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CursorDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CursorOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetVariableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CursorId node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CursorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenCursorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CloseCursorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CryptoMechanism node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenSymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CloseSymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CloseMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeallocateCursorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FetchType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FetchCursorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WhereClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropUnownedObjectStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropObjectsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropDatabaseStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropChildObjectsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropIndexClauseBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropIndexClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MoveToDropIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamOnDropIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropStatisticsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropProcedureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropViewStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropDefaultStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropRuleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropTriggerStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSchemaStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RaiseErrorLegacyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RaiseErrorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ThrowStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UseStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(KillStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(KillStatsJobStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CheckpointStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ReconfigureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ShutdownStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetUserStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TruncateTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetOnOffStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PredicateSetStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetStatisticsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetRowCountStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetOffsetsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetCommand node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GeneralSetCommand node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetFipsFlaggerCommand node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetCommandStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetTransactionIsolationLevelStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetTextSizeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetIdentityInsertStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetErrorLevelStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateDatabaseStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileDeclaration node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileDeclarationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NameFileDeclarationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileNameFileDeclarationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SizeFileDeclarationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxSizeFileDeclarationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileGrowthFileDeclarationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileGroupDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseScopedConfigurationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseConfigurationClearOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseConfigurationSetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffPrimaryConfigurationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxDopConfigurationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DWCompatibilityLevelConfigurationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GenericConfigurationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseCollateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseAddFileStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseModifyNameStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseModifyFileStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseTermination node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseSetStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ContainmentDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(HadrDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DelayedDurabilityDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CursorDefaultDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RecoveryDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PageVerifyDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PartnerDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WitnessDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ParameterizationDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTrackingDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTrackingOptionDetail node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AcceleratedDatabaseRecoveryDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreDesiredStateOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreCapturePolicyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreIntervalLengthOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningCreateIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningDropIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CatalogCollationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LedgerOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxSizeDatabaseOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAlterIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterTableAlterColumnStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionDefinitionParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionTypeParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentityOptions node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnStorageOptions node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FederationScheme node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableDataCompressionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableXmlCompressionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableDistributionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableReplicateDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableRoundRobinDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableHashDistributionPolicy node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableIndexType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableClusteredIndexType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableNonClusteredIndexType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TablePartitionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PartitionSpecifications node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TablePartitionOptionSpecifications node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LocationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RenameEntityStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CopyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CopyStatementOptionBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CopyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CopyCredentialOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SingleValueTypeCopyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ListTypeCopyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CopyColumnOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataCompressionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(XmlCompressionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CompressionPartitionRange node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CheckConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DefaultConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NullableConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphConnectionBetweenNodes node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphConnectionConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UniqueConstraintDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupDatabaseStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupTransactionLogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RestoreStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RestoreOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionRestoreOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MoveRestoreOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StopRestoreOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileStreamRestoreOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupEncryptionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeviceInfo node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MirrorToClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupRestoreFileInfo node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BulkInsertBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BulkInsertStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InsertBulkStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BulkInsertOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OpenRowsetCosmosOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralOpenRowsetCosmosOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralBulkInsertOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OrderBulkInsertOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ColumnDefinitionBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalTableColumnDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InsertBulkColumnDefinition node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DbccStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DbccOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DbccNamedLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateAsymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreatePartitionFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PartitionParameterType node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreatePartitionSchemeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteServiceBindingStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RemoteServiceBindingOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffRemoteServiceBindingOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UserRemoteServiceBindingOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateRemoteServiceBindingStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterRemoteServiceBindingStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EncryptionSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AssemblyEncryptionSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FileEncryptionSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProviderEncryptionSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CertificateStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterCertificateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateCertificateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CertificateOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateContractStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ContractMessage node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CredentialStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateCredentialStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterCredentialStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MessageTypeStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateMessageTypeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterMessageTypeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateAggregateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateEndpointStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterEndpointStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterCreateEndpointStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EndpointAffinity node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EndpointProtocolOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralEndpointProtocolOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuthenticationEndpointProtocolOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PortsEndpointProtocolOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CompressionEndpointProtocolOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ListenerIPEndpointProtocolOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IPv4 node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SoapMethod node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EnabledDisabledPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WsdlPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LoginTypePayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SessionTimeoutPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CharacterSetPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RolePayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuthenticationPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EncryptionPayloadOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(KeyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(KeySourceKeyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlgorithmKeyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentityValueKeyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProviderKeyNameKeyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreationDispositionKeyOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterSymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextCatalogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextCatalogOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffFullTextCatalogOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateFullTextCatalogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextCatalogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterCreateServiceStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateServiceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServiceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ServiceContract node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BinaryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BuiltInFunctionTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GlobalFunctionTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ComputeClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ComputeFunction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PivotedTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UnpivotedTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UnqualifiedJoin node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableSampleClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanNotExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanParenthesisExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanComparisonExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanBinaryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanIsNullExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchPredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchLastNodePredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchNodeExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchRecursivePredicate node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphMatchCompositeExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GraphRecursiveMatchQuantifier node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExpressionWithSortOrder node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GroupByClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExpressionGroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CompositeGroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CubeGroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RollupGroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GrandTotalGroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GroupingSetsGroupingSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OutputClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OutputIntoClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(HavingClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentityFunctionCall node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(JoinParenthesisTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OrderByClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(JoinTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QualifiedJoin node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OdbcQualifiedJoinTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueryParenthesisExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QuerySpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FromClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PredictTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectElement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectScalarExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectStarExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectSetVariable node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableReferenceWithAlias node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TableReferenceWithAliasAndColumns node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataModificationTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTableChangesTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ChangeTableVersionTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanTernaryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TopRowFilter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OffsetClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UnaryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BinaryQueryExpression node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(VariableTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(VariableMethodCallTableReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropPartitionFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropPartitionSchemeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSynonymStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropAggregateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropAssemblyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropApplicationRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropFullTextCatalogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropFullTextIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropLoginStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropRoleStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropTypeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropUserStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropAsymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropCertificateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropCredentialStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterPartitionFunctionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterPartitionSchemeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SimpleAlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropAlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AddAlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSearchPropertyListStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterSearchPropertyListStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SearchPropertyListAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AddSearchPropertyListAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSearchPropertyListAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSearchPropertyListStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateLoginStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateLoginSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PasswordCreateLoginSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PrincipalOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffPrincipalOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralPrincipalOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierPrincipalOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WindowsCreateLoginSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalCreateLoginSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CertificateCreateLoginSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PasswordAlterPrincipalOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginOptionsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginEnableDisableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RevertStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropContractStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropEndpointStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropMessageTypeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropQueueStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropRemoteServiceBindingStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropRouteStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropServiceStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SignatureStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AddSignatureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSignatureStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropEventNotificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExecuteAsStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EndConversationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MoveConversationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GetConversationGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ReceiveStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SendStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WaitForSupportedStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterSchemaStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAsymmetricKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServiceMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BeginConversationTimerStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BeginDialogStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DialogOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionDialogOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffDialogOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupCertificateStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupRestoreMasterKeyStatementBase node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupServiceMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RestoreServiceMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BackupMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RestoreMasterKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ScalarExpressionSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BooleanExpressionSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StatementListSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectStatementSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SchemaObjectNameSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TSqlFragmentSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TSqlStatementSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(IdentifierSnippet node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TSqlScript node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TSqlBatch node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TSqlStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataModificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DataModificationSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MergeStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MergeSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MergeActionClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MergeAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateMergeAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeleteMergeAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(InsertMergeAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateTypeTableStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SensitivityClassificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SensitivityClassificationOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AddSensitivityClassificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropSensitivityClassificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditSpecificationPart node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditSpecificationDetail node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditActionSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseAuditAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditActionGroupReference node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateServerAuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerAuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropServerAuditSpecificationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ServerAuditStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateServerAuditStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerAuditStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropServerAuditStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditTarget node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(QueueDelayAuditOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditGuidAuditOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnFailureAuditOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OperatorAuditOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(StateAuditOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AuditTargetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxSizeAuditTargetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(RetentionDaysAuditTargetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralAuditTargetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffAuditTargetOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DatabaseEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResourcePoolParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ResourcePoolAffinitySpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalResourcePoolParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalResourcePoolStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupResourceParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupImportanceParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadGroupParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateWorkloadGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterWorkloadGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropWorkloadGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadClassifierStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WorkloadClassifierOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierWorkloadGroupOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierMemberNameOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierWlmLabelOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierImportanceOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierWlmContextOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierStartTimeOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ClassifierEndTimeOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WlmTimeLiteral node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateWorkloadClassifierStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropWorkloadClassifierStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BrokerPriorityStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BrokerPriorityParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateBrokerPriorityStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterBrokerPriorityStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropBrokerPriorityStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateFullTextStopListStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterFullTextStopListStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FullTextStopListAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropFullTextStopListStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateCryptographicProviderStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterCryptographicProviderStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropCryptographicProviderStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventSessionObjectName node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventSessionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateEventSessionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventDeclaration node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventDeclarationSetParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SourceDeclaration node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TargetDeclaration node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SessionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(EventRetentionSessionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MemoryPartitionSessionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralSessionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MaxDispatchLatencySessionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(OnOffSessionOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterEventSessionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropEventSessionStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterResourceGovernorStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateSpatialIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SpatialIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SpatialIndexRegularOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BoundingBoxSpatialIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(BoundingBoxParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GridsSpatialIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(GridParameter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ProcessAffinityRange node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateAvailabilityGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityReplica node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityReplicaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralReplicaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityModeReplicaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(FailoverModeReplicaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(PrimaryRoleReplicaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SecondaryRoleReplicaOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AvailabilityGroupOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(LiteralAvailabilityGroupOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropAvailabilityGroupStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateFederationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterFederationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropFederationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UseFederationStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DiskStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DiskStatementOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateColumnStoreIndexStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WindowFrameClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WindowDelimiter node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(WithinGroupClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(TemporalClause node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CompressionDelayIndexOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLibraryStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalLibraryStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalLibraryStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLibraryFileOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalLibraryStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLanguageStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(CreateExternalLanguageStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(AlterExternalLanguageStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ExternalLanguageFileOption node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DropExternalLanguageStatement node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(ElasticPoolSpecification node)
    {
        if (node is TSearchElement fragment) _foundElements.Add(fragment);
        base.ExplicitVisit(node);
    }
}
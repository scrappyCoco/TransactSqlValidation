namespace Coding4Fun.TransactSql.Analyzers.ValidationResults;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
/// <summary>
/// Types of SQL objects.
/// </summary>
public enum ObjectNameValidationResult
{
    Server,
    Database,
    Schema,
    Table,
    Column,
    PrimaryKeyConstraint,
    UniqueConstraint,
    CheckConstraint,
    DefaultConstraint,
    BTreeNonUniqueClusteredIndex,
    BTreeUniqueClusteredIndex,
    BTreeNonUniqueNonClusteredIndex,
    BTreeUniqueNonClusteredIndex,
    ClusteredColumnStoreIndex,
    NonClusteredColumnStoreIndex,
    Procedure,
    Function,
    RoutineParameter,
    Variable
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
namespace Coding4fun.TransactSql.Validations.ValidationResults
{
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
}
using BenchmarkDotNet.Running;

namespace Coding4fun.TransactSql.Benchmark
{
    internal static class Program
    {
        public static void Main()
        {
            // BenchmarkRunner.Run<SingleRuleValidation>();
            BenchmarkRunner.Run<VendorValidation>();
        }
    }
}
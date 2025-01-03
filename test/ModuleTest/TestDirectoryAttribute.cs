using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Coding4Fun.TransactSql.ModuleTest;

public class TestDirectoryAttribute(string testDataRootPath) : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return Directory.GetFiles(testDataRootPath)
            .Select(filePath => new object[] { Path.GetFileNameWithoutExtension(filePath) })
            .ToArray();
    }
}
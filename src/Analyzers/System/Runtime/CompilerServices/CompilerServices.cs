// ReSharper disable once CheckNamespace

namespace System.Runtime.CompilerServices;

/// <summary>
/// Fixing error during compilation: [CS0518] Predefined type 'System.Runtime.CompilerServices.IsExternalInit' is not defined or imported
/// Comment: This is a small bug in Visual Studio 2019 that hasn't been fixed yet. To solve this,
///          you need to add a dummy class named IsExternalInit with the namespace System.Runtime.CompilerServices anywhere in your project.
/// </summary>
internal static class IsExternalInit
{
}

internal class RequiredMemberAttribute : Attribute
{
}

internal class CompilerFeatureRequiredAttribute : Attribute
{
    public CompilerFeatureRequiredAttribute(string name)
    {
    }
}
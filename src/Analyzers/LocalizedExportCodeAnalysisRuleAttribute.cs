using System.Globalization;
using System.Resources;
using Microsoft.SqlServer.Dac.CodeAnalysis;

namespace Coding4Fun.TransactSql.Analyzers;

/// <summary>
/// Original: https://github.com/microsoft/DACExtensions/blob/master/RuleSamples/LocalizedExportCodeAnalysisRuleAttribute.cs
/// </summary>
internal sealed class LocalizedExportCodeAnalysisRuleAttribute : ExportCodeAnalysisRuleAttribute
{
    private readonly string _displayName;
    private readonly ResourceManager _resourceManager;

    /// <summary>
    /// Creates the attribute, with the specified rule ID, the fully qualified
    /// name of the resource file that will be used for looking up display name
    /// and description, and the Ids of those resources inside the resource file.
    /// </summary>
    public LocalizedExportCodeAnalysisRuleAttribute(
        string id,
        string displayNameResourceId)
        : base(id, null)
    {
        string resourceBaseName = typeof(RuleResources).FullName!;
        _resourceManager = new ResourceManager(resourceBaseName, GetType().Assembly);
        _displayName = GetResourceString(displayNameResourceId);
    }

    /// <summary>
    /// Overrides the standard DisplayName and looks up its value inside a resources file
    /// </summary>
    public override string DisplayName => _displayName;

    private string GetResourceString(string resourceId)
    {
        return _resourceManager.GetString(resourceId, CultureInfo.CurrentUICulture)
               ?? throw new SqlValidationException($"Can not find resource with id '{resourceId}'");
    }
}
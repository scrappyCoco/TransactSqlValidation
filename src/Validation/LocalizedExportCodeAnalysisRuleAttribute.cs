using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.SqlServer.Dac.CodeAnalysis;

namespace Coding4fun.TransactSql.Validations
{
    /// <summary>
    /// Оригинал: https://github.com/microsoft/DACExtensions/blob/master/RuleSamples/LocalizedExportCodeAnalysisRuleAttribute.cs
    /// </summary>
    internal sealed class LocalizedExportCodeAnalysisRuleAttribute : ExportCodeAnalysisRuleAttribute
    {
        private readonly string _displayNameResourceId;
        private readonly string _resourceBaseName;
        private string _displayName;

        private ResourceManager _resourceManager;

        /// <summary>
        ///     Creates the attribute, with the specified rule ID, the fully qualified
        ///     name of the resource file that will be used for looking up display name
        ///     and description, and the Ids of those resources inside the resource file.
        /// </summary>
        public LocalizedExportCodeAnalysisRuleAttribute(
            string id,
            string displayNameResourceId)
            : base(id, null)
        {
            _resourceBaseName = typeof(RuleResources).FullName;
            _displayNameResourceId = displayNameResourceId;
        }

        /// <summary>
        ///     Overrides the standard DisplayName and looks up its value inside a resources file
        /// </summary>
        public override string DisplayName =>
            _displayName ?? (_displayName = GetResourceString(_displayNameResourceId));

        /// <summary>
        ///     Rules in a different assembly would need to overwrite this
        /// </summary>
        /// <returns></returns>
        private Assembly GetAssembly() => GetType().Assembly;

        private void EnsureResourceManagerInitialized()
        {
            var resourceAssembly = GetAssembly();

            try
            {
                _resourceManager = new ResourceManager(_resourceBaseName, resourceAssembly);
            }
            catch (Exception ex)
            {
                var msg = string.Format(CultureInfo.CurrentCulture, RuleResources.CannotCreateResourceManager,
                    _resourceBaseName, resourceAssembly);
                throw new RuleException(msg, ex);
            }
        }

        private string GetResourceString(string resourceId)
        {
            EnsureResourceManagerInitialized();
            return _resourceManager.GetString(resourceId, CultureInfo.CurrentUICulture);
        }
    }
}
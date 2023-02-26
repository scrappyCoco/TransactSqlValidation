using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Extensions
{
    public static class SqlObjectExtensions
    {
        /// <summary>
        ///     Значение в строковом литерале.
        /// </summary>
        private static readonly Regex StringLiteralRegex = new Regex("^N?'(?<value>.+?)'$");

        /// <summary>
        ///     Поиск расширенного свойства в объекте.
        /// </summary>
        /// <param name="sqlObject">Объект, в котором нужно искать свойство.</param>
        /// <param name="propertyName">Название искомого свойства.</param>
        /// <returns>True - если свойство найдено, иначе false.</returns>
        public static bool HasExtendedProperty(this TSqlObject sqlObject, string propertyName) =>
            sqlObject.GetChildren()
                .Where(child =>
                    child.ObjectType == ModelSchema.ExtendedProperty
                    && child.Name.Parts.Last() == propertyName)
                .Select(propertyObject => propertyObject.GetProperty(ExtendedProperty.Value).ToString())
                .Any(propertyValue => !string.IsNullOrWhiteSpace(propertyValue));

        /// <summary>
        ///     Получение значения искомого свойства в объекте.
        /// </summary>
        /// <param name="sqlObject">Объект, в котором нужно искать свойство.</param>
        /// <param name="propertyName">Название искомого свойства.</param>
        /// <returns>Значение искомго свойства.</returns>
        public static string GetExtendedPropertyValue(this TSqlObject sqlObject, string propertyName)
        {
            var stringLiteral = sqlObject.GetChildren()
                .Where(child =>
                    child.ObjectType == ModelSchema.ExtendedProperty
                    && child.Name.Parts.Last() == propertyName)
                .Select(propertyObject => propertyObject.GetProperty(ExtendedProperty.Value))
                .FirstOrDefault()
                ?.ToString();

            if (stringLiteral == null) return null;
            var stringLiteralMatch = StringLiteralRegex.Match(stringLiteral);
            return !stringLiteralMatch.Success ? null : stringLiteralMatch.Groups["value"].Value;
        }

        /// <summary>
        ///     Экранизация пути к объекту TSQL.
        /// </summary>
        /// <param name="identifiers">Список идентификаторов, составлящих путь к объекту.</param>
        /// <returns>Экранизированный путь к объекту.</returns>
        public static string GetPath(this IEnumerable<Identifier> identifiers) => identifiers
            .Select(i => i.Value.StartsWith("[") ? i.Value : "[" + i.Value + "]")
            .Let(quotedIdentifiers => string.Join(".", quotedIdentifiers));
    }
}
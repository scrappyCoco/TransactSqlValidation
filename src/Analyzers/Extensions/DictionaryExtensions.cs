using System.Collections.Generic;

namespace Coding4Fun.TransactSql.Analyzers.Extensions;

/// <summary>
/// Extensions for <see cref="Dictionary{TKey, TValue}"/>.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Add all items from <paramref name="source"/> to <paramref name="target"/>.
    /// </summary>
    /// <param name="target">Dictionary, where items will be added.</param>
    /// <param name="source">Dictionary, from witch items will be copied.</param>
    public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> source)
    {
        foreach (var (key, value) in source) target.Add(key, value);
    }
}
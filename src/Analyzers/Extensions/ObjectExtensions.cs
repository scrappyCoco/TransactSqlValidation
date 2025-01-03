using System;

namespace Coding4Fun.TransactSql.Analyzers.Extensions;

/// <summary>
/// Extensions for all object types.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Calls the specified function block with this value as its argument and returns its result (from Kotlin).
    /// </summary>
    /// <param name="source">Source object.</param>
    /// <param name="func">Converter from <typeparamref name="TSource"/> to <typeparamref name="TResult"/>.</param>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TResult">Target type.</typeparam>
    /// <remarks>https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/let.html</remarks>
    public static TResult Let<TSource, TResult>(this TSource source, Func<TSource, TResult> func) =>
        func.Invoke(source);

    /// <summary>
    /// Execute a function over disposable object and then dispose it (for conciseness).
    /// </summary>
    /// <param name="disposable">Disposable object.</param>
    /// <param name="converter">Object converter.</param>
    public static TTarget Using<TDisposable, TTarget>(this TDisposable disposable,
        Func<TDisposable, TTarget> converter)
        where TDisposable : IDisposable
    {
        using (disposable) return converter.Invoke(disposable);
    }
}
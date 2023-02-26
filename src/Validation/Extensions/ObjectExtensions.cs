using System;

namespace Coding4fun.TransactSql.Validations.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Преобразование исходного обхекта в результирующий.
        /// </summary>
        /// <param name="source">Исходный объект.</param>
        /// <param name="func">Преобразователь объекта.</param>
        /// <typeparam name="TSource">Тип исходного объекта.</typeparam>
        /// <typeparam name="TResult">Тип результирующего объекта.</typeparam>
        /// <remarks>https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/let.html</remarks>
        public static TResult Let<TSource, TResult>(this TSource source, Func<TSource, TResult> func) =>
            func.Invoke(source);

        /// <summary>
        ///     Вместо трех строчек, пишем одну.
        /// </summary>
        /// <param name="disposable">Disposable-объект</param>
        /// <param name="converter">Преобразователь объекта.</param>
        public static TTarget Using<TDisposable, TTarget>(this TDisposable disposable,
            Func<TDisposable, TTarget> converter)
            where TDisposable : IDisposable
        {
            using (disposable)
            {
                return converter.Invoke(disposable);
            }
        }
    }
}
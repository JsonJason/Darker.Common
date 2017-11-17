using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Darker
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Converts an enumerable into a string in the format: <c>'[A,B,C]'</c>
        /// </summary>
        /// <param name="source">Enumeration collection source</param>
        /// <returns>Formatted String</returns>
        public static string ToDisplayString(this IEnumerable source)
        {
            if (source == null) return "null";
            var usableSource = source.Cast<object>().ToList();
            if (!usableSource.Any()) return "[]";
            var s = "[";
            s = usableSource.Aggregate(s, (res, x) => res + x.ToString() + ", ");
            return $"{s.Substring(0, s.Length - 2)}]";
        }

        /// <summary>
        ///     Returns true if each element in the collection is distinct from each other
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if all elements unique, <c>false</c> otherwise.</returns>
        public static bool AllElementsAreUnique<T>(this IEnumerable<T> source)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            if (!enumerable.Any()) return true;
            return enumerable.Distinct().Count() == enumerable.Count;
        }

        /// <summary>
        /// Filters an Enumerable collection by the class or interface subtype
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>IEnumerable of the filtered type</returns>
        public static IEnumerable<TFilter> FilterByType<T, TFilter>(this IEnumerable<T> source)
            where T : class
            where TFilter : T
        {
            return source.Where(item => item is TFilter).Cast<TFilter>();
        }

        /// <summary>
        /// Filters an Enumerable collection by the class or interface subtype
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="filterType"></param>
        /// <returns>IEnumerable of the filtered type</returns>
        public static IEnumerable<T> FilterByType<T>(this IEnumerable<T> source,Type filterType)
            where T : class
        {
            return source.Where(item => item.GetType() == filterType);
        }

        /// <summary>
        ///     Returns highest element in collection by provided comparator
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="score">The score.</param>
        /// <returns>T.</returns>
        public static T MaxBy<T>(this IEnumerable<T> source, Func<T, IComparable> score)
        {
            return source.Aggregate((x, y) => score(x).CompareTo(score(y)) > 0 ? x : y);
        }

        /// <summary>
        ///     Returns lowest element in collection by provided comparator
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="score">The score.</param>
        /// <returns>T.</returns>
        public static T MinBy<T>(this IEnumerable<T> source, Func<T, IComparable> score)
        {
            return source.Aggregate((x, y) => score(x).CompareTo(score(y)) < 0 ? x : y);
        }

    }
}
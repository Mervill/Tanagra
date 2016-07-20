using System;
using System.Collections.Generic;
using System.Linq;

namespace Tanagra.Generator
{
    static class IEnumerableExtensions
    {
        /// <summary>
        /// Find exactly one element matching the predicate
        /// </summary>
        public static T UniqueOrAssert<T>(this IEnumerable<T> _this, Func<T, bool> predicate)
        {
            var x = _this.Where(predicate);
            var enumerable = x as T[] ?? x.ToArray();
            if (!enumerable.Any()) throw new InvalidOperationException("found nothing");
            if (enumerable.Count() != 1) throw new InvalidOperationException("found many");
            return enumerable.First();
        }

        /// <summary>
        /// Find exactly one element matching the predicate, else return `default(T)`
        /// </summary>
        public static T UniqueOrDefault<T>(this IEnumerable<T> _this, Func<T, bool> predicate)
        {
            var x = _this.Where(predicate);
            var enumerable = x as T[] ?? x.ToArray();
            if (!enumerable.Any()) return default(T);
            if (enumerable.Count() != 1) throw new InvalidOperationException("found many");
            return enumerable.First();
        }
    }
}

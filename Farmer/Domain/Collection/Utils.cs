using System;
using System.Collections.Generic;
using System.Linq;

namespace Farmer.Domain.Collection
{
    public static class Utils
    {
        public static void Foreach<T>(this IImmutableList<T> list, Action<T> action)
        {
            for (var i = 0; i < list.Size; i++)
            {
                action(list[i]);
            }
        }

        public static int IndexOf<T>(this IImmutableList<T> list, Predicate<T> predicate)
        {
            for (var i = 0; i < list.Size; i++)
            {
                if (predicate(list[i])) return i;
            }

            return -1;
        }

        public static T[] ToArray<T>(this IImmutableList<T> list)
        {
            var arr = new T[list.Size];
            for (var i = 0; i < list.Size; i++)
            {
                arr[i] = list[i];
            }

            return arr;
        }

        public static IImmutableList<T> ToList<T>(this IEnumerable<T> enumerable) => ListFactory.ListOf(enumerable.ToArray());

        public static IMutableList<T> ToMutableList<T>(this IImmutableList<T> list) => ListFactory.MutableListOf(list.ToArray());

        public static void AddAll<T>(this IMutableList<T> destination, IImmutableList<T> list) => list.Foreach(destination.Add);
    }
}
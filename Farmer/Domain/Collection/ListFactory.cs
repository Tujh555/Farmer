using System.Collections;

namespace Farmer.Domain.Collection
{
    public static class ListFactory
    {
        public static IImmutableList<T> ListOf<T>(params T[] values) => ArrayListOf(values);

        public static IMutableList<T> MutableListOf<T>(params T[] values) => ArrayListOf(values);
        
        public static IImmutableList<T> ListOf<T>(int capacity = 16) => new ArrayList<T>(capacity);

        public static IMutableList<T> MutableListOf<T>(int capacity = 16) => new ArrayList<T>(capacity);

        private static ArrayList<T> ArrayListOf<T>(params T[] values)
        {
            var list = new ArrayList<T>(values.Length);

            foreach (var value in values)
            {
                list.Add(value);
            }

            return list;
        }
    }
}
using System.Collections.Generic;

namespace Farmer.Domain.Collection
{
    public interface IMutableList<T> : IImmutableList<T>, IEnumerable<T>
    {
        new T this[int index]
        {
            get;
            set;
        }

        void Add(T item);
    }
}
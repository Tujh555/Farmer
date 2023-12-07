using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Farmer.Domain.Collection
{
    public class ArrayList<T> : IMutableList<T>
    {
        private T[] _arr;
        private int _currentSize;

        public T this[int index]
        {
            get => _arr[index];
            set => _arr[index] = value;
        }

        public int Size => _currentSize;

        public ArrayList(int initialCapacity = 16)
        {
            if (initialCapacity < 0) throw new ArgumentException("Initial capacity should be greater then 0");

            _arr = new T[initialCapacity];
        }

        public void Add(T item)
        {
            if (_currentSize + 1 >= _arr.Length)
            {
                var tempArray = new T[_arr.Length * 2];
                Array.Copy(_arr, tempArray, _arr.Length);
                _arr = tempArray;
            }

            _arr[_currentSize++] = item;
        }

        public void Delete(int index)
        {
            if (_currentSize <= 0 || index < 0 || index >= Size) return;

            for (var i = index + 1; i < _arr.Length; i++)
            {
                var current = _arr[i];
                _arr[i - 1] = current;
            }

            _currentSize--;
        }
        
        public IEnumerator<T> GetEnumerator() => _arr.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
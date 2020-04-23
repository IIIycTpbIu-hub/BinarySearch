using System;
using System.Collections.Generic;
using System.Text;

namespace SortedArrayProject
{
    public class OrderedArray<T> where T : IComparable<T>
    {
        private readonly T[] _array;

        public int Count { get; private set; }

        public OrderedArray(int size)
        {
            _array = new T[size];
            Count = 0;
        }

        public int Find(T item)
        {
            bool found = BinarySearch(item, out var itemIndex);
            if (found)
            {
                return itemIndex;
            }
            else
            {
                return -1;
            }
        }

        public void Add(T item)
        {
            if (Count <= _array.Length)
            {
                Count++;
                BinarySearch(item, out var itemIndex);
                for (int i = Count - 1; i > itemIndex; i--)
                {
                    _array[i] = _array[i - 1];
                }
                _array[itemIndex] = item;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(_array[i] + " ");
            }

            Console.WriteLine();
        }

        private bool BinarySearch(T item, out int index)
        {
            int lowerBound = 0;
            int upperBound = Count - 1;

            while (true)
            {
                var currentItemIndex = (lowerBound + upperBound) / 2;
                int comparison = _array[currentItemIndex].CompareTo(item);

                if (comparison == 0)
                {
                    index = currentItemIndex;
                    return true;
                }
                else if (comparison < 0)
                {
                    lowerBound = currentItemIndex + 1;
                }
                else
                {
                    upperBound = currentItemIndex - 1;
                }

                if (lowerBound > upperBound)
                {
                    index = currentItemIndex;
                    return false;
                }
            }
        }

    }
}

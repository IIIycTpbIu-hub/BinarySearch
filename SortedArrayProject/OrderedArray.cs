using System;
using System.Collections.Generic;
using System.Text;

namespace SortedArrayProject
{
    public class OrderedArray<T> where T : IComparable<T>
    {
        private T[] _array;

        public int Count { get; private set; }

        public OrderedArray(int size)
        {
            _array = new T[size];
            Count = 0;
        }

        public int Find(T item)
        {
            return BinarySearch(item);
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        private int BinarySearch(T item)
        {
            int lowerBound = 0;
            int upperBound = Count - 1;
            int currentItemIndex;


            while (true)
            {
                currentItemIndex = (lowerBound + upperBound) / 2;
                int comparison = _array[currentItemIndex].CompareTo(item);

                if (comparison == 0)
                {
                    return currentItemIndex;
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
                    return -1;
                }
            }
        }

    }
}

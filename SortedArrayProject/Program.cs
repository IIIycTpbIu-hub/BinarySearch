using System;

namespace SortedArrayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OrderedArray<Int32> array = new OrderedArray<int>(5);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Show();
            array.Add(3);
            array.Show();
            Console.WriteLine(array.Find(3));
        }
    }
}

using System;
using System.Diagnostics;

namespace SortedArrayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch simpleArrayStopWatch = new Stopwatch();
            Stopwatch orderedArrayStopWatch = new Stopwatch();

            int count = 100000;
            Console.WriteLine("Создаем массивы из {0} элементов", count);
            int[] sipmleArray = new int[count];

            OrderedArray<Int32> orderedArray = new OrderedArray<int>(count);

            Random random = new Random();
            int millisecondsSimple = 0;
            int millisecondsOrdered = 0;
            for (int i = 0; i < count; i++)
            {
                int val = random.Next(0, count);
                simpleArrayStopWatch.Start();
                sipmleArray[i] = val;
                simpleArrayStopWatch.Stop();
                //millisecondsSimple += simpleArrayStopWatch.Elapsed.Milliseconds;

                orderedArrayStopWatch.Start();
                orderedArray.Add(val);
                orderedArrayStopWatch.Stop();
                //millisecondsOrdered += orderedArrayStopWatch.Elapsed.Milliseconds;
            }
            Console.WriteLine("Заполнение обычного массива из {0} элементов заняло {1} секунд {2} милисекунд", count, simpleArrayStopWatch.Elapsed.Seconds, simpleArrayStopWatch.Elapsed.Milliseconds);
            Console.WriteLine("Заполнение отсортированного массива из {0} элементов заняло {1} секунд {2} милисекунд", count, orderedArrayStopWatch.Elapsed.Seconds, orderedArrayStopWatch.Elapsed.Milliseconds);

            orderedArrayStopWatch.Reset();
            simpleArrayStopWatch.Reset();

            int searchingItemsCount = 100000;
            Console.WriteLine("Поиск случайных элементов",searchingItemsCount);
            for (int i = 0; i < searchingItemsCount; i++)
            {
                int val = random.Next(0, count);
                for (int j = 0; j < count; j++)
                {
                    simpleArrayStopWatch.Start();
                    if (sipmleArray[j] == val)
                    {
                        simpleArrayStopWatch.Stop();
                        break;
                    }
                }

                orderedArrayStopWatch.Start();
                orderedArray.Find(val);
                orderedArrayStopWatch.Stop();
            }

            Console.WriteLine("Поиск {0} случайных элементов в неупорядоченном массиве занял {3} минут {1} секунд {2} милисекунд"
                ,searchingItemsCount, simpleArrayStopWatch.Elapsed.Seconds, simpleArrayStopWatch.Elapsed.Milliseconds,
                simpleArrayStopWatch.Elapsed.Minutes);
            Console.WriteLine("Поиск {0} случайных элементов в упорядоченном массиве занял {1} секунд {2} милисекунд",
                searchingItemsCount, orderedArrayStopWatch.Elapsed.Seconds, orderedArrayStopWatch.Elapsed.Milliseconds);
        }
    }
}

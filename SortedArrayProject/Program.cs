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

            int count = 320000;
            Console.WriteLine("Создаем массивы из {0} элементов", count);
            int[] sipmleArray = new int[count];

            OrderedArray<Int32> orderedArray = new OrderedArray<int>(count);
            int progress = 0;
            int step = count/100;
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int val = random.Next(0, count);
                simpleArrayStopWatch.Start();
                sipmleArray[i] = val;
                simpleArrayStopWatch.Stop();

                orderedArrayStopWatch.Start();
                orderedArray.Add(val);
                orderedArrayStopWatch.Stop();

                if (i - progress == step)
                {
                    progress += step;
                    Console.Write(progress/ step + "% .. ");
                }
                
            }
            Console.WriteLine("Заполнение обычного массива из {0} элементов заняло {3} минут {1} секунд {2} милисекунд", count, simpleArrayStopWatch.Elapsed.Seconds, simpleArrayStopWatch.Elapsed.Milliseconds, simpleArrayStopWatch.Elapsed.Minutes);
            Console.WriteLine("Заполнение отсортированного массива из {0} элементов заняло {3} минут {1} секунд {2} милисекунд", count, orderedArrayStopWatch.Elapsed.Seconds, orderedArrayStopWatch.Elapsed.Milliseconds, orderedArrayStopWatch.Elapsed.Minutes);

            orderedArrayStopWatch.Reset();
            simpleArrayStopWatch.Reset();

            int searchingItemsCount = count;
            Console.WriteLine("Поиск случайных элементов",searchingItemsCount);
            progress = 0;
            for (int i = 0; i < searchingItemsCount; i++)
            {
                int val = random.Next(0, count);
                //simpleArrayStopWatch.Start();
                //for (int j = 0; j < count; j++)
                //{
                //    if (sipmleArray[j] == val)
                //    {
                //        break;
                //    }
                //}
                //simpleArrayStopWatch.Stop();

                orderedArrayStopWatch.Start();
                orderedArray.Find(val);
                orderedArrayStopWatch.Stop();

                if (i - progress == step)
                {
                    progress += step;
                    Console.Write(progress / step + "% .. ");
                }
            }

            Console.WriteLine("Поиск {0} случайных элементов в неупорядоченном массиве занял {3} минут {1} секунд {2} милисекунд"
                ,searchingItemsCount, simpleArrayStopWatch.Elapsed.Seconds, simpleArrayStopWatch.Elapsed.Milliseconds,
                simpleArrayStopWatch.Elapsed.Minutes);
            Console.WriteLine("Поиск {0} случайных элементов в упорядоченном массиве занял {1} секунд {2} милисекунд",
                searchingItemsCount, orderedArrayStopWatch.Elapsed.Seconds, orderedArrayStopWatch.Elapsed.Milliseconds);
        }
    }
}

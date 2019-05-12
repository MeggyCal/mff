using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace paralizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            List<int> array = new List<int>();
            Random randNum = new Random();
            for (int i = 0; i < 100*1000; i++)
            {
                array.Add(randNum.Next(int.MinValue, int.MaxValue));
            }
            
            stopwatch.Start();
            List<int> sortedSerialized = MergeSort(array, 0);
            stopwatch.Stop();
            Console.WriteLine("serialized done in: " + stopwatch.ElapsedMilliseconds + "ms");
            
            stopwatch.Restart();
            List<int> sortedParrallel = MergeSort(array, 3);
            stopwatch.Stop();
            Console.WriteLine("parrallel done in: " + stopwatch.ElapsedMilliseconds + "ms");
            
            bool correctness = true;
            for (int i = 0; i < array.Count; i++)
            {
                if (sortedParrallel[i] != sortedSerialized[i])
                {
                    correctness = false;
                }
            Console.WriteLine("are sorted arrays same? " + correctness);
            }

            Console.ReadKey();
        }
        private static List<int> MergeSort(List<int> unsorted, int depth)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            if (depth<=0)
            { // serrial
                left = MergeSort(left, depth - 1);
                right = MergeSort(right, depth - 1);
            }
            else
            { // parralel
                Parallel.Invoke(
                    () => left = MergeSort(left, depth-1),
                    () => right = MergeSort(right, depth-1)
                );
            }

            return Merge(left, right);
        }
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] <= right[0])
                    {
                        result.Add(left[0]);
                        left.Remove(left[0]);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.Remove(right[0]);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);

                    right.Remove(right[0]);
                }
            }
            return result;
        }
    }
}

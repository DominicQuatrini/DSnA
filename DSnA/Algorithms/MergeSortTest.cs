using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA.Algorithms
{
    public class MergeSortTest
    { // Dominic's code
        public static int[] MergeSort(int[] arr, bool continueStopWatch)
        {
            Stopwatch sw = null;
            if (continueStopWatch)
            {
                sw = new Stopwatch();
                sw.Start();
            }

            if (arr.Length == 1) return arr;
            int mid = arr.Length / 2;

            int[] arrLeft = new int[mid];
            int[] arrRight = new int[arr.Length - mid];

            Array.Copy(arr, 0, arrLeft, 0, mid);
            Array.Copy(arr, mid, arrRight, 0, arr.Length - mid);

            int[] sortedArray = Merge(MergeSort(arrLeft, false), MergeSort(arrRight, false));

            if (continueStopWatch)
            {
                sw.Stop();
                Console.WriteLine($"Merge sort with array length {arr.Length} completed. Elapsed time: {sw.Elapsed}");
            }
            return sortedArray;
        }
        private static int[] Merge(int[] arrLeft, int[] arrRight)
        {
            int[] arr = new int[arrLeft.Length + arrRight.Length];
            int i = 0;
            int j = 0;
            while (i < arrLeft.Length && j < arrRight.Length)
            {
                if (arrLeft[i] < arrRight[j])
                {
                    arr[i + j] = arrLeft[i];
                    i++;
                }
                else
                {
                    arr[i + j] = arrRight[j];
                    j++;
                }
            }
            while (i < arrLeft.Length)
            {
                arr[i + j] = arrLeft[i];
                i++;
            }
            while (j < arrRight.Length)
            {
                arr[i + j] = arrRight[j];
                j++;
            }
            return arr;
        }
    }
}

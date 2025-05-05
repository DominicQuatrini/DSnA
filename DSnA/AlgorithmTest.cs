using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSnA.Algorithms;

namespace DSnA
{
    // Riley contributed this code
    public class AlgorithmTest
    {
        public static void TestRun(int size)
        {
            Console.WriteLine($"Testing with {size} integers: ");

            int[] bubbleArray = GenerateRandomArray(size);
            int[] heapArray = (int[])bubbleArray.Clone();
            int[] insertionArray = (int[])bubbleArray.Clone();
            int[] mergeArray = (int[])bubbleArray.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSortTest.BubbleSort(bubbleArray);
            stopwatch.Stop();
            Console.WriteLine($"Bubble sort time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            HeapSortTest.HeapSort(heapArray);
            stopwatch.Stop();
            Console.WriteLine($"Heap sort time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            InsertionSortTest.InsertionSort(insertionArray);
            stopwatch.Stop();
            Console.WriteLine($"Insertion sort time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            MergeSortTest.MergeSort(mergeArray, true);
            stopwatch.Stop();
            Console.WriteLine($"Merge sort time: {stopwatch.ElapsedTicks} ticks");
        }

        public static void RealWorldApplication()
        {
            int numberOfProducts = 200;
            Console.WriteLine($"Loading {numberOfProducts} product prices: ");

            int[] prices = GenerateRandomArray(numberOfProducts);
            int[] bubblePrices = (int[])prices.Clone();
            int[] heapPrices = (int[])prices.Clone();

            Console.WriteLine("\nSorting prices using Bubble Sort: ");

            Stopwatch stopwatchBubble = Stopwatch.StartNew();
            BubbleSortTest.BubbleSort(bubblePrices);
            stopwatchBubble.Stop();
            Console.WriteLine($"Bubble Sort Time: {stopwatchBubble.ElapsedTicks} ticks");

            Console.WriteLine("\nFive Cheapest Prices after Bubble Sort:");
            DisplayTop5Prices(bubblePrices);

            Console.WriteLine("\nSorting prices using Heap Sort: ");

            Stopwatch stopwatchHeap = Stopwatch.StartNew();
            HeapSortTest.HeapSort(heapPrices);
            stopwatchHeap.Stop();
            Console.WriteLine($"Heap Sort Time: {stopwatchHeap.ElapsedTicks} ticks");

            Console.WriteLine("\nFive Cheapest Prices after Heap Sort:");
            DisplayTop5Prices(heapPrices);
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(10000);
            }
            return array;
        }

        static void DisplayTop5Prices(int[] prices)
        {
            for (int i = 0; i < Math.Min(5, prices.Length); i++)
            {
                Console.WriteLine($"#{i + 1}: ${prices[i]}");
            }
        }
    }
}

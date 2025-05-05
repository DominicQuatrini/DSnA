using DSnA.DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DSnA
{
    public class CompareAll
    {
        public static void CompareAllSorts(int iterations, int size)
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();

            double insertionArrTicks = 0;
            double bubbleArrTicks = 0;
            double heapArrTicks = 0;
            double mergeArrTicks = 0;

            for (int i = 0; i < iterations; i++)
            {
                int[] insertionArr = Program.GenerateRandomArray(size);
                int[] bubbleArr = (int[])insertionArr.Clone();
                int[] heapArr = (int[])insertionArr.Clone();
                int[] mergeArr = (int[])insertionArr.Clone();

                watch.Start();
                Algorithms.InsertionSortTest.InsertionSortArray(insertionArr);
                watch.Stop();
                insertionArrTicks += watch.ElapsedTicks;
                watch.Reset();

                watch.Start();
                Algorithms.BubbleSorter.BubbleSort(bubbleArr);
                watch.Stop();
                bubbleArrTicks += watch.ElapsedTicks;
                watch.Reset();

                watch.Start();
                Algorithms.HeapSorter.HeapSort(heapArr);
                watch.Stop();
                heapArrTicks += watch.ElapsedTicks;
                watch.Reset();

                watch.Start();
                Algorithms.MergeSorter.MergeSort(mergeArr);
                watch.Stop();
                mergeArrTicks += watch.ElapsedTicks;
                watch.Reset();

                //watch.Start();
                //InsertionSort.InsertionSortList(li);
                //watch.Stop();
                //insertionLiTicks += watch.ElapsedTicks;
                //watch.Reset();

                //SinglyLinkedList.Print(sll);
                //Console.WriteLine("\n");
                //watch.Start();
                //InsertionSort.InsertionSortSLL(sll);
                //watch.Stop();
                //insertionSllTicks += watch.ElapsedTicks;
                //watch.Reset();
            }

            double insertionArrAvg = insertionArrTicks / iterations;
            double bubbleArrAvg = bubbleArrTicks / iterations;
            double heapArrAvg = heapArrTicks / iterations;
            double mergeArrAvg = mergeArrTicks / iterations;

            Console.WriteLine($"Total time to sort a randomized sample of {size} numbers {iterations} times with: ");
            Console.WriteLine($"\t\tINSERTION SORT: {insertionArrTicks} ticks");
            Console.WriteLine($"\t\tBUBBLE SORT: {bubbleArrTicks} ticks");
            Console.WriteLine($"\t\tHEAP SORT: {heapArrTicks} ticks");
            Console.WriteLine($"\t\tMERGE SORT: {mergeArrTicks} ticks\n");

            Console.WriteLine($"AVERAGE time to sort {size} numbers with: ");
            Console.WriteLine($"\t\tINSERTION SORT: {insertionArrAvg} ticks");
            Console.WriteLine($"\t\tBUBBLE SORT: {bubbleArrAvg} ticks");
            Console.WriteLine($"\t\tHEAP SORT: {heapArrAvg} ticks");
            Console.WriteLine($"\t\tMERGE SORT: {mergeArrAvg} ticks");

            //double percentInsertionBubble = 100 * (insertionArrAvg / bubbleArrAvg);
            //double percentInsertionHeap = 100 * (insertionArrAvg / heapArrAvg);

            //Console.WriteLine($"Insertion Sort took {percentInsertionBubble}% as much time to perform as Bubble Sort.");
            //Console.WriteLine($"Insertion Sort took {percentInsertionHeap}% as long to perform as Heap Sort.");

        }
        public static void CompareAllSearch(int iterations, int size)
        {
            Stopwatch sw = new Stopwatch();
            Random rand = new Random();

            double arrTicks = 0;
            double BSTTicks = 0;
            double SLLTicks = 0;

            for (int j = 0; j < iterations; j++)
            {
                int[] array = Program.GenerateRandomArray(size);

                BinarySearchTree bst = new BinarySearchTree();
                foreach (int value in array)
                {
                    bst.Insert(value);
                }
                SinglyLinkedList sll = new SinglyLinkedList();
                for (int i = 0; i < array.Length; i++)
                    sll.InsertFirst(array[i]);

                Random random = new Random();
                int target = array[random.Next(array.Length)];

                sw.Start();
                Program.LinearSearch(array, target);
                sw.Stop();
                arrTicks += sw.ElapsedTicks;

                sw.Restart();
                bst.Search(target);
                sw.Stop();
                BSTTicks += sw.ElapsedTicks;

                sw.Restart();
                sll.Search(target);
                sw.Stop();
                SLLTicks += sw.ElapsedTicks;
            }
            Console.WriteLine($"AVERAGE time to search {size} numbers with: ");
            Console.WriteLine($"\t\tARRAY: {arrTicks / iterations} ticks");
            Console.WriteLine($"\t\tBST: {BSTTicks / iterations} ticks");
            Console.WriteLine($"\t\tSLL: {SLLTicks / iterations} ticks");
        }
    }
}

using DSnA.DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA
{
    internal class DataStructuresTest
    {
        public static void Performance(int size)
        {
            Console.WriteLine($"Searching in an array of {size} integers: ");

            int[] array = GenerateRandomArray(size);
            int[] treeArray = (int[])array.Clone();

            BinarySearchTreeTest bst = new BinarySearchTreeTest();
            foreach (int value in treeArray)
            {
                bst.Insert(value);
            }

            Random random = new Random();
            int target = array[random.Next(array.Length)];

            Stopwatch stopwatchArray = Stopwatch.StartNew();
            bool foundInArray = LinearSearch(array, target);
            stopwatchArray.Stop();
            Console.WriteLine($"Array search time: {stopwatchArray.ElapsedTicks} ticks");

            Stopwatch stopwatchTree = Stopwatch.StartNew();
            bool foundInTree = bst.Search(target);
            stopwatchTree.Stop();
            Console.WriteLine($"Binary Tree search time: {stopwatchTree.ElapsedTicks} ticks");
        }

        public static void Application()
        {
            int numberOfStudents = 50;
            Console.WriteLine($"Loading {numberOfStudents} students... ");

            int[] studentIDs = GenerateRandomArray(numberOfStudents);
            int[] treeIDs = (int[])studentIDs.Clone();

            BinarySearchTreeTest studentTree = new BinarySearchTreeTest();
            foreach (int id in treeIDs)
            {
                studentTree.Insert(id);
            }

            Random random = new Random();
            int targetID = studentIDs[random.Next(studentIDs.Length)];
            Console.WriteLine($"Searching for Student ID: {targetID}");

            Console.WriteLine("\nArray Linear Search:");
            Stopwatch stopwatchArray = Stopwatch.StartNew();
            bool foundinArray = LinearSearch(studentIDs, targetID);
            stopwatchArray.Stop();
            Console.WriteLine($"Array Search Time: {stopwatchArray.ElapsedTicks} ticks");
            Console.WriteLine($"Student ID found in array: {foundinArray}");

            Console.WriteLine("\nBinary Search Tree:");
            Stopwatch stopwatchTree = Stopwatch.StartNew();
            bool foundInTree = studentTree.Search(targetID);
            stopwatchTree.Stop();
            Console.WriteLine($"Binary Search Tree time: {stopwatchTree.ElapsedTicks} ticks");
            Console.WriteLine($"Student ID found in tree: {foundInTree}");
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1000, 9999);
            }
            return array;
        }

        public static bool LinearSearch(int[] array, int key)
        {
            foreach (int value in array)
            {
                if (value == key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

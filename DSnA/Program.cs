using BenchmarkDotNet.Running;
using DSnA.DataStructures;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System.Diagnostics;

namespace DSnA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Algorithms Performance Test --------------------------------------------------\n");
            AlgorithmTest.Performance(100);
            Console.WriteLine();
            AlgorithmTest.Performance(10000);

            Console.WriteLine("\nAlgorithms Application Test --------------------------------------------------\n");
            AlgorithmTest.Application(200);

            Console.WriteLine("\nData Structures Performance Test ---------------------------------------------\n");
            DataStructuresTest.Performance(100);
            Console.WriteLine();
            DataStructuresTest.Performance(10000);

            Console.WriteLine("\nData Structures Application Test ---------------------------------------------\n");
            DataStructuresTest.Application(50);

            /* The method InsertionSortSLL() isn't working properly with
             * the benchmark testing. It keeps throwing up error 
             * System.ArgumentException: Objects are not comparable
             * even though the method itself properly sorts all of the 
             * Singly Linked Lists I've thrown at it.
             * 
             * Uncomment the var summary = BenchmarkRunner line and all of 
             * the [Benchmark] throughout the classes to run the benchmark
             */

            //var summary = BenchmarkRunner.Run<AlgorithmsBenchmarks>();
        }
    }
}

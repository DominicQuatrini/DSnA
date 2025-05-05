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
            //InsertionSort.InsertionSortCompare(10, 30000);

            // Riley and Dominic contributed the code below this line
            Console.WriteLine("Algorithms Performance Test --------------------------------------------------\n");
            AlgorithmTest.TestRun(100);
            Console.WriteLine();
            AlgorithmTest.TestRun(10000);

            Console.WriteLine("Algorithms Application Test --------------------------------------------------\n");
            AlgorithmTest.RealWorldApplication();

            Console.WriteLine("Data Structures Performance Test ---------------------------------------------\n");
            DataStructuresTest.TestRun(100);
            Console.WriteLine();
            DataStructuresTest.TestRun(10000);

            Console.WriteLine("Data Structures Application Test ---------------------------------------------\n");
            DataStructuresTest.RealWorldApplication();

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

using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace DSnA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InsertionSort.InsertionSortCompare(100, 1000);

            /* The method InsertionSortSLL() isn't working properly with
             * the benchmark testing. It keeps throwing up error 
             * System.ArgumentException: Objects are not comparable
             * even though the method itself properly sorts all of the 
             * Singly Linked Lists I've thrown at it.
             */

            //var summary = BenchmarkRunner.Run<AlgorithmsBenchmarks>();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ViSortLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            // test
            
            BubbleSort bubble = new BubbleSort();

            List<int> input = new List<int> { 8, 5, 20, 4, 9, 7, 14, 17, 2, 16, 10, 3, 13, 18, 1, 12, 6, 19, 11, 15 };

            bubble.SetInputData(input);

            bubble.Sort();
            int complexity = bubble.GetTotalNumberOfComparisons();
            bubble.SetInputData(input);
            int comparisons = 0;
            Console.WriteLine(complexity);

            foreach (var item in input)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("bubble");

            while (!bubble.HasSortingCompleted())
            {
                bubble.ProceedOneStep();
                comparisons += bubble.GetLastStepComplexityInComparisons();
                List<int> temp = bubble.GetInterimData();
                foreach(var item in temp)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine("bubble");
            }

            Console.WriteLine(comparisons);
            /*
            QuickSort quick = new QuickSort();

            quick.SetInputData(input);
            
            foreach (var item in input)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("quick");

            quick.Sort();

            foreach (var item in quick.GetOutputData())
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("quick");
            */
            Console.ReadKey(true);
        }
    }
}

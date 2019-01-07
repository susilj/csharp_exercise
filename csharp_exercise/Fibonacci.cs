using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_exercise
{
    public sealed class Fibonacci
    {
        public void Run(int number)
        {
            long iterativeAnswer = this.IterativeFibonacci(number);
            Console.WriteLine($"IterativeAnswer Fibonacci {iterativeAnswer}");

            long recursiveAnswer = this.RecursiveFibonacci(number);
            Console.WriteLine($"Recursive Fibonacci {recursiveAnswer}");
        }

        // Big O of recursive fibonacci is 0 (N - 2) => 0 (N)
        // 2 is the initial 2 elements that would be excluded from the loop
        public long IterativeFibonacci(int number)
        {
            List<long> seriesArray = new List<long>() { 0, 1 };

            for (int i = 2; i <= number; i++)
            {
                seriesArray.Add(seriesArray[i - 2] + seriesArray[i - 1]);
            }

            return seriesArray[number];
        }

        // Big O of recursive fibonacci is 0 (2 ^ N)
        public long RecursiveFibonacci(int number)
        {
            if(number < 2)
            {
                return number;
            }

            return this.RecursiveFibonacci(number - 1) + this.RecursiveFibonacci(number - 2);
        }
    }
}

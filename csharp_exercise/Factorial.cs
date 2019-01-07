
namespace csharp_exercise
{
    using System;

    public sealed class Factorial
    {
        public void Run(long number)
        {
            long iterativeAnswer = this.IterativeFactorial(number);
            Console.WriteLine($"Iterative Factorial {iterativeAnswer}");

            long recursiveAnswer = this.RecursiveFactorial(number);
            Console.WriteLine($"Recursive Factorial {recursiveAnswer}");
        }

        public long IterativeFactorial(long number)
        {
            long answer = 1;

            if (number == 2)
            {
                answer = 2;
            }

            for (int i = 2; i <= number; i++)
            {
                answer = answer * i;
            }

            return answer;
        }

        public long RecursiveFactorial(long number)
        {
            if (number == 2)
            {
                return 2;
            }

            return number * RecursiveFactorial(number - 1);
        }
    }
}

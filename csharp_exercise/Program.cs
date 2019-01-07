using System;

namespace csharp_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProxyServer ps = new ProxyServer();
            //ps.Run();

            Factorial factorial = new Factorial();
            factorial.Run(5);

            Fibonacci fibonacci = new Fibonacci();
            fibonacci.Run(8);

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}

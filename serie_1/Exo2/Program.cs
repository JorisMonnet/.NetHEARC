using System;
using System.Diagnostics;
using static System.Console;

namespace Exo2 {
    class Program {
        public static double[] Root(double number) {
            double root = number;
            int iterations = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            do {
                iterations++;
                root = (root + number / root) / 2;
                WriteLine($"Approximation of the root of  {number} is {root}");
            }
            while (Math.Abs(root - Math.Sqrt(number)) > number / (Math.Pow(10, 9)));
            stopwatch.Stop();

            return new double[] { root, iterations, stopwatch.ElapsedMilliseconds, (Math.Sqrt(number) - root) / Math.Sqrt(number) * 100 };
        }
        static void Main() {
            double number = 0;
            bool correctInput = false;
            while (correctInput == false) {
                try {
                    WriteLine("Write a number : ");
                    number = double.Parse(ReadLine());
                    if (number > 0) correctInput = true;
                }
                catch {WriteLine("Error, that's not a normal positive number");}
            }
            double[] result = Root(number);
            WriteLine($"The number {number} has got {result[0]} as root , found after {result[1]} iterations in {result[2]} ms with a relative margin from Math.sqrt of {result[3]}%.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Exo4
{
    class Program {
        public static int[][] PairImpair(int[] tab) {
            List<int> evenList = new List<int>();
            List<int> oddList = new List<int>();
            foreach (int e in tab)  {
                if (e % 2 == 0) {
                    evenList.Add(e);
                } else {
                    oddList.Add(e);
                }
            }
            return new int[][] {evenList.ToArray(), oddList.ToArray()};
        }
        static void Main() {
            Random r = new Random();
            int[] arr = new int[20];
            for (int i = 1; i < 20; i++) arr[i] = r.Next(0, 100);
            int[][] result = PairImpair(arr);
            WriteLine($"Base Array : [{string.Join(", ", arr)}]\n ****Call of PairImpair****\n" +
                $"Pair : [{string.Join(", ", result[0])}]\nImpair : [{string.Join(", ", result[1])}]");
        }
    }
}

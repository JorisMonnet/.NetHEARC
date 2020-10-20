using System;
using static System.Console;

namespace Exo4
{
    class Program {
        public static int[][] PairImpair(int[] tab) {
            int indexT1=0, indexT2 = 0;
            int[] t1 = new int[20];//max size if all elmt are even
            int[] t2 = new int[20];
            foreach (int e in tab)  {
                if (e % 2 == 0) {
                    t1[indexT1++] = e;
                } else {
                    t2[indexT2++] = e;
                }
            }
            int [] result1 = new int[indexT1]; //good size arrays
            int [] result2 = new int[indexT2];
            for(int i=0;i<indexT1;i++){
                result1[i] = t1[i];
            }
            for (int j = 0; j < indexT2; j++) {
                result2[j] = t2[j];
            }
            return new int[][] {result1, result2};
        }
        static void Main() {
            Random r = new Random();
            int[] arr = new int[20];
            for (int i = 1; i < 20; i++) arr[i] = r.Next(0, 99);
            int[][] result = PairImpair(arr);
            WriteLine($"Base Array : [{string.Join(", ", arr)}]\n ****Call of PairImpair****\n" +
                $"Pair : [{string.Join(", ", result[0])}]\nImpair : [{string.Join(", ", result[1])}]");
        }
    }
}

using System;
using static System.Console;

namespace Exo3
{
    class Program {
        static void Main()  {
            string[] lines = System.IO.File.ReadAllLines("./Mesures.txt");
            WriteLine("Mesures.txt = ");
            string str = "";

            for (int i = 0; i < lines.Length; i++) {
                if (i % 11 != 0) {
                    str += ", " + lines[i];
                }
                else {
                    WriteLine(str);
                    str = lines[++i];
                }
            }
            ReadKey();
        }
    }
}

using System;
using System.IO;
using System.Text;
using static System.Console;

namespace Exo3 {
    class Program {
        static void Main()  {
            string[] lines = System.IO.File.ReadAllLines(@"./Mesures.txt");
            StringBuilder str = new StringBuilder("Mesures.txt = \n");
            for (int i = 0; i < lines.Length; i++) {
                str.Append((i % 10 != 0?", ":"\n") + lines[i]);
            }
            WriteLine(str.ToString());
            ReadKey();
        }
    }
}

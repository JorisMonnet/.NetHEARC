using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using static System.Console;

namespace Exo5
{
    class Program {
        static void Main() {
            string s1 = "Hello World";
            string s2 = "Hello World";
            string s3 = s1;
            Test(s1,s2,s3);
            WriteLine("------Change s3------");
            s3 += '!';
            Test(s1,s2,s3);
            
        }
        static void Test(string s1,string s2,string s3){
            WriteLine($"s1.Equals(s2) -> {s1.Equals(s2)}");
            WriteLine($"s1.Equals(s3) -> {s1.Equals(s3)}");
            WriteLine($"s3.Equals(s2) -> {s3.Equals(s2)}");

            WriteLine($"s1.CompareTo(s2) -> {s1.CompareTo(s2)}");
            WriteLine($"s1.CompareTo(s3) -> {s1.CompareTo(s3)}");
            WriteLine($"s3.CompareTo(s2) -> {s3.CompareTo(s2)}");

            WriteLine($"ReferenceEquals(s1,s2) -> {ReferenceEquals(s1,s2)}");
            WriteLine($"ReferenceEquals(s1,s3) -> {ReferenceEquals(s1,s3)}");
            WriteLine($"ReferenceEquals(s3,s2) -> {ReferenceEquals(s3,s2)}");
        }
    }
}

/* s1 stay always the same as s2, moreover they seems to be the same object because the reference eqauls is true
 * when s3 change, it's not the same as s1 or s2 and the reference change, so a new object has benn created.
 * We can conclude that string are immutable and we need to use a stringbuilder to avoid creating other objects when changing a string
 * */

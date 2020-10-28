using System;
using System.Text;

namespace Exo1 {
    public static class ExtensionString {
        public static string UpLowUp(this string s){
            StringBuilder builder = new StringBuilder();
            for(int i =0;i<s.Length;i++){
                if(char.IsLower(s[i])){
                    builder.Append(s[i].ToString().ToUpper());
                }else{
                    builder.Append(s[i].ToString().ToLower());
                }
            }
            return builder.ToString();
        } 
    }
    class Program {
        static void Main(string[] args) {
            string phrase = "Hugo, Ada et Jean jouent avec les robots.";
            Console.WriteLine(phrase);
            Console.WriteLine(phrase.UpLowUp());
        }
    }
}

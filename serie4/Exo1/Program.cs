using System;

namespace Exo1 {
    public static class ExtensionString {
        public static void UpLowUp(this string s){
            for(int i =0;i<s.Length;i++){
                if(char.IsLower(s[i])){
                    Console.Write(s[i].ToString().ToUpper());
                }
                else{
                    Console.Write(s[i].ToString().ToLower());
                }
            }
        } 
    }
    class Program {
        static void Main(string[] args) {
            string phrase = "Hugo, Ada et Jean jouent avec les robots.";
            Console.WriteLine(phrase);
            phrase.UpLowUp();
        }
    }
}

using System;
using ExtensionMethods;

namespace TestArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            var s = "Արամ";
            Console.WriteLine(s.IsPalindrome());
            Console.WriteLine("\u0531\u0580\u0561\u0574");
            Console.WriteLine("\u2323");

            var str = "I'll be staying there -> with my friends :) do you want to come with us?<- or not?:()";
            Console.WriteLine(str.ReplaceWithSymbols());

            var translitText = "chanaprah@ shat erkar tvac indz bayc cicernakner@ prkecin gonya";
            Console.WriteLine(translitText.ToArmenian());

            Console.ReadKey();
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static bool IsPalindrome(this string str)
        {
            str = str.ToLower();
            return !str.Where((t, i) => t != str[str.Length - 1 - i]).Any();
        }

        public static string ReplaceWithSymbols(this string str)
        {
            str = str.Replace(":)", "\u2323");
            str = str.Replace(":(", "\u2639");
            str = str.Replace("->", "\u2192");
            str = str.Replace("<-", "\u2190");
            return str;
        }

        public static string ToArmenian(this string text)
        {
            var map = new Dictionary<string, string>
            {
            // specific armenian letters
                {"@", "ը"},
                {"th", "թ"},
                {"zh", "ժ"},
                {"&", "ծ"},
                {"dz", "ձ"},
                {"gh", "ղ"},
                {"sh", "շ"},
                {"ch", "չ"},     // +ճ
                {"ph", "փ"},
                {"ev", "և"},

            //standard latin letters
                {"a", "ա"},
                {"b", "բ"},
                {"c", "ց"},
                {"d", "դ"},
                {"e", "ե"},    // +է
                {"f", "ֆ"},
                {"g", "գ"},
                {"h", "հ"},
                {"i", "ի"},
                {"j", "ջ"},
                {"k", "կ"},
                {"l", "լ"},
                {"m", "մ"},
                {"n", "ն"},
                {"o", "ո"},
                {"p", "պ"},
                {"q", "ք"},
                {"r", "ր"},    // +ռ
                {"s", "ս"},
                {"t", "տ"},
                {"u", "ու"},
                {"v", "վ"},
                {"w", "ինչ ես գրում w-ով՞"},
                {"x", "խ"},
                {"y", "յ"},
                {"z", "զ"},

            };

            return map.Aggregate(text, (current, pair) => current.Replace(pair.Key, pair.Value));
        }
    }
}

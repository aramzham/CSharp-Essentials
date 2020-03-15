using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.Strings.Formats
{
    class MyClass : IFormattable
    {
        private int _value;

        public MyClass(int value)
        {
            _value = value;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{0}, now = {1}", _value.ToString(format, formatProvider), DateTime.Now.ToString("U", formatProvider));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyClass(10);
            Console.WriteLine(m.ToString());
            Console.WriteLine(m.ToString("C", new CultureInfo("ru-RU")));
            Console.WriteLine(m.ToString("F", CultureInfo.InvariantCulture));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EssentialTypes.Strings.Formats
{
    internal sealed class MyFomatProvider : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var formattable = arg as IFormattable;
            var s = formattable is null ? arg.ToString() : formattable.ToString(format, formatProvider);

            return arg is int ? $"<b>{s}</b>" : s;
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }
    }

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

            Console.WriteLine("Enter two numbers...");
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = a + b;
            var sb = new StringBuilder();
            sb.AppendFormat(new MyFomatProvider(), "{0} + {1} = {2} and this is {3}", a, b, c, a + b == c);
            Console.WriteLine(sb);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.NullableTypes.ClrSupport
{
    //when the CLR is boxing a Nullable<T> instance, it checks to see if it is null , and if
    //so, the CLR doesn’t actually box anything, and null is returned.If the nullable instance is not null ,
    //the CLR takes the value out of the nullable instance and boxes it
    class Program
    {
        static void Main(string[] args)
        {
            // Boxing Nullable<T> is null or boxed T
            int? n = null;
            object o = n; // o is null, a struct must have been boxed here, but clr just assignes null to object
            Console.WriteLine("o is null={0}", o == null); // "True"
            n = 5;
            o = n; // o refers to a boxed Int32
            Console.WriteLine("o's type={0}", o.GetType()); // "System.Int32"

            // Create a boxed Int32
            object obj = 5;
            // Unbox it into a Nullable<Int32> and into an Int32
            int? a = (int?)obj; // a = 5
            int b = (int)obj; // b = 5

            // Create a reference initialized to null
            obj = null;
            // "Unbox" it into a Nullable<Int32> and into an Int32
            a = (int?)obj; // a = null
            b = (int)obj; // NullReferenceException
        }
    }
}

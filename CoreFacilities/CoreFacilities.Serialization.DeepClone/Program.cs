using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CoreFacilities.Serialization.DeepClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new object();
            var second = DeepClone(first);
            Console.WriteLine($"Are objects the same? - {ReferenceEquals(first, second)}");

            Console.ReadKey();
        }

        private static object DeepClone(object original)
        {
            // Construct a temporary memory stream
            using (var stream = new MemoryStream())
            {
                // Construct a serialization formatter that does all the hard work
                var formatter = new BinaryFormatter
                {
                    Context = new StreamingContext(StreamingContextStates.Clone)
                };
                // Serialize the object graph into the memory stream
                formatter.Serialize(stream, original);
                // Seek back to the start of the memory stream before deserializing
                stream.Position = 0;
                // Deserialize the graph into a new set of objects and
                // return the root of the graph (deep copy) to the caller
                return formatter.Deserialize(stream);
            }
        }
    }
}

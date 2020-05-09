using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CoreFacilities.Serialization.QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph of objects to serialize them to the stream
            var objectGraph = new List<string> { "Levon", "Robert", "Serj", "Nikol" };
            Stream stream = SerializeToMemory(objectGraph);
            // Reset everything for this demo
            stream.Position = 0;
            objectGraph = null;
            // Deserialize the objects and prove it worked
            objectGraph = (List<string>)DeserializeFromMemory(stream);
            foreach (var s in objectGraph) 
                Console.WriteLine(s);

            Console.ReadKey();
        }

        private static MemoryStream SerializeToMemory(object objectGraph)
        {
            // Construct a stream that is to hold the serialized objects
            var stream = new MemoryStream();
            // Construct a serialization formatter that does all the hard work
            var formatter = new BinaryFormatter();
            // Tell the formatter to serialize the objects into the stream
            formatter.Serialize(stream, objectGraph);
            // Return the stream of serialized objects back to the caller
            return stream;
        }
        private static object DeserializeFromMemory(Stream stream)
        {
            // Construct a serialization formatter that does all the hard work
            var formatter = new BinaryFormatter();
            // Tell the formatter to deserialize the objects from the stream
            return formatter.Deserialize(stream);
        }
    }
}

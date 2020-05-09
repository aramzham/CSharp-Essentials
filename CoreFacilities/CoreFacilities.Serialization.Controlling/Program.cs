using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CoreFacilities.Serialization.Controlling
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new MemoryStream();
            var formatter= new BinaryFormatter();
            var derived = new Derived();

            formatter.Serialize(stream, derived);
            stream.Position = 0;
            var deserializedDerived = formatter.Deserialize(stream);

            Console.ReadKey();
        }
    }
}

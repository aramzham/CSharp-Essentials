using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Test
{
    public class Program
    {
        private static ConcurrentDictionary<int, char> _dictionary = new ConcurrentDictionary<int, char>();
        //private static Dictionary<int, char> _dictionary = new Dictionary<int, char>();

        static void Main()
        {
            var reader = new Thread(Read);
            var writer = new Thread(Writer);
            var remover = new Thread(Remove);

            reader.Start();
            writer.Start();
            remover.Start();

            Console.ReadKey();
        }

        static void Read()
        {
            while (true)
            {
                Thread.Sleep(10);
                var key = 10;

                if (_dictionary.ContainsKey(key))
                    Console.Write(_dictionary[key]);

                //_dictionary.TryGetValue(key, out var value);
                //Console.Write(value);
            }
        }

        static void Writer()
        {
            while (true)
            {
                Thread.Sleep(10);

                var key = 10;
                _dictionary[key] = '.';
            }
        }

        static void Remove()
        {
            while (true)
            {
                Thread.Sleep(10);

                var key = 10;
                //_dictionary.Remove(key);
                _dictionary.TryRemove(key, out _);
            }
        }
    }
}
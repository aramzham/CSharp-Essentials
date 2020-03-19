using System;
using System.Security;
using System.Runtime.InteropServices;

namespace EssentialTypes.Strings.SecureStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ss = new SecureString())
            {
                Console.WriteLine("Please enter password: ");

                while (true)
                {
                    var cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                        break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }

                Console.WriteLine();

                // demonstration purposes
                DisplaySecureString(ss);
            }
            // After 'using', the SecureString is Disposed; no sensitive data in memory
        }

        // this method is unsafe because it accesses unmanaged memory
        private static void DisplaySecureString(SecureString ss)
        {
            unsafe
            {
                char* pc = null;

                try
                {
                    pc = (char*)Marshal.SecureStringToCoTaskMemUnicode(ss);
                    for (int i = 0; pc[i] != 0; i++)
                    {
                        Console.Write(pc[i]);
                    }
                }
                finally
                {
                    // free unmanaged memory buffer
                    if (pc != null)
                        Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
                }
            }
        }
    }
}

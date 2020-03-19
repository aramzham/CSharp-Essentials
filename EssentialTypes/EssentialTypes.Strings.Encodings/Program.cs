using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.Strings.Encodings
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                var e = ei.GetEncoding();
                Console.WriteLine($"{e.EncodingName}{Environment.NewLine}\tCodePage={e.CodePage}, WindowsCodePage{e.WindowsCodePage}{Environment.NewLine}\tWebName={e.WebName}, HeaderName={e.HeaderName}, BodyName={e.BodyName}{Environment.NewLine}\tIsBrowserDisplay={e.IsBrowserDisplay}, IsBrowserSave={e.IsBrowserSave}{Environment.NewLine}\tIsMainNewsDisplay={e.IsMailNewsDisplay}, IsMailNewsSave={e.IsMailNewsSave}{Environment.NewLine}\tEncoderFallback={e.EncoderFallback}, DecoderFallback={e.DecoderFallback}");

                //Returns an array of bytes indicating what should be written to a stream before writing any encoded bytes.
                Console.WriteLine(e.GetString(e.GetPreamble()));
            }
        }
    }
}

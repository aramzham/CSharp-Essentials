using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Translator
{
    public class ArmenianToTranslite
    {
        #region Constructors
        public ArmenianToTranslite()
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileName = "New Translated File";
        }
        public ArmenianToTranslite(string path)
        {
            Path = path;
            fileName = "New Translated File";
        }
        public ArmenianToTranslite(string fileName, string path)
        {
            this.fileName = fileName;
            Path = path;
        }

        #endregion

        // fields
        public string Path { get; set; }
        protected string fileName;
        protected StreamWriter stream;

        // methods
        public void TranslateAndWriteToFile(string armText)
        {
            var translatedText = ToTranslite(armText);
            using (stream = new StreamWriter(Path + "\\" + fileName + ".doc"))
            {
                stream.WriteLine(translatedText);
            }
        }

        public void DeleteTranslatedFile()
        {
            var fullAddress = Path + "\\" + fileName + ".doc";
            if(File.Exists(fullAddress)) File.Delete(fullAddress);
            else throw new FileNotFoundException();
        }

        private static string ToTranslite(string text)
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

            return map.Aggregate(text, (current, pair) => current.Replace(pair.Value, pair.Key));
        }
    }
}

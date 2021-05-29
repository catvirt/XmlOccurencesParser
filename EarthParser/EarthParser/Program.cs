using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;

namespace EarthParser
{
    class Program
    {
        private static void Main(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" > Invalid Arguments!");
                Console.ResetColor();
            }
            else if (arguments[0] != null && arguments[1] != null)
            {
                var xml = XDocument.Load(arguments[0]);

                XElement root = xml.Root;

                XNamespace xname = root.GetDefaultNamespace();

                IEnumerable<XElement> KeysEntry = from key in xml.Descendants(xname + arguments[1]) select key;

                foreach (var earthParse in KeysEntry)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(earthParse.Value);
                    File.AppendAllText("OccurencesFound.txt", earthParse.Value);
                    Console.ResetColor();
                }
            }          
        }
    }
}

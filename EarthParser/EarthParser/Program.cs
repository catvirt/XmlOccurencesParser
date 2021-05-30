using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;

namespace EarthParser
{
    internal static class Program
    {
        private static void Main(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" > Invalid Arguments!");
                Console.ResetColor();
                return;
            }
            if (arguments[0] != null && arguments[1] != null)
            {
                var xml = XDocument.Load(arguments[0]);
                XElement root = xml.Root;
                XNamespace xname = root.GetDefaultNamespace();
                IEnumerable<XElement> KeysEntry = from key in xml.Descendants(xname + arguments[1]) select key;
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var earthParse in KeysEntry)
                {           
                    Console.WriteLine(earthParse.Value);
                    File.AppendAllText("FoundOccurrences.txt", $"{earthParse.Value}{Environment.NewLine}");           
                }
                Console.ResetColor();
            }          
        }
    }
}

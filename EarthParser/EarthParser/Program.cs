using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EarthParser
{
    internal static class Program
    {
        private static void Main(string[] arguments)
        {
            if (arguments.Length < 2 || arguments[0] == null || arguments[1] == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" > Invalid Arguments!");
                Console.ResetColor();
                return;
            }
            var xml = XDocument.Load(arguments[0]);
            var root = xml.Root;
            if (root == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" > Root Cannot Be Null!");
                Console.ResetColor();
                return;
            }
            var xname = root.GetDefaultNamespace();
            var KeysEntry = from key in xml.Descendants(xname + arguments[1]) select key;
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

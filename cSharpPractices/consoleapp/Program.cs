using System;
using System.Collections.Generic;
using System.IO;

namespace consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static IEnumerable<string> ReadFrom(string file){
            string line;
            using(var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null){
                    var words = line.Split(' ');
                    foreach (var word in words)
                    {
                        yield return word + " ";
                    }
                    yield return Environment.NewLine;
                }
            }
        }
    }

}

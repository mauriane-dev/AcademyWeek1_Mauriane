using System;
using System.Collections.Generic;
using Week1.Spese.Factory.Entities;
using Week1.Spese.Factory.Files;

namespace Week1.Spese.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Spesa> result = GestioneFile.ReadFromFile();

            foreach (Spesa spesa in result)
                GestioneFile.WriteToFile(spesa);
        }
    }
}

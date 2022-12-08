using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_3_10
    {
        public static int GetLettersCount(string text)
        {
            var characters = text.ToCharArray();

            var punctuationMarks = new[] {' ', ',', '.'}; // Task 13.3.11

            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Task 13.3.11 

            var symbols =  new HashSet<char>();

            foreach(var symbol in characters)
                symbols.Add(symbol);

            if (symbols.Overlaps(numbers)) // Task 13.3.11
                Console.WriteLine("Коллекция содержит цифры.");

            symbols.ExceptWith(punctuationMarks); // Task 13.3.11

            return symbols.Count;
        }
    }
}

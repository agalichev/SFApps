using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_1_6
    {
        public static void SearchUniqueChars()
        {
            List<char> punctuation = new List<char> { ' ', ',', '.', ';', ':', '?', '!' };

            while (true)
            {
                Console.WriteLine("Введите текст:");

                var input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Вы ввели пустой текст!");

                    continue;
                }
                
                var uniqueChars = input.ToCharArray().Distinct().Except(punctuation);

                foreach (var c in uniqueChars)
                    Console.Write(c + " ");

                Console.WriteLine();

                break;
            }
        }
    }
}

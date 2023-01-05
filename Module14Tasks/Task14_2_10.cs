using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14Tasks
{
    public static class Task14_2_10
    {
        public static void WatchContactBook(List<Contact2> phoneBook)
        {
            while (true)
            {
                Console.WriteLine("Введите номер страницы");

                Console.WriteLine();

                var input = Console.ReadKey().KeyChar;

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if(!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    Console.Clear();

                    var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);

                    Console.WriteLine($"Страница {pageNumber}");

                    foreach (var content in pageContent)
                        Console.WriteLine($"{content.Name} {content.LastName}\n{content.PhoneNumber} {content.Email}\n");
                }
            }
        }
    }
}

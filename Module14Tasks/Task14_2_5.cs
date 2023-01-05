using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14Tasks
{
    public static class Task14_2_5
    {
        public static void CreateContactsBook(List<Contact> contacts)
        {
            while (true)
            {
                Console.Write("Введите номер страницы книги контактов: ");

                var keyChar = Console.ReadKey().KeyChar;
                Console.Clear();

                if (!Char.IsDigit(keyChar))
                    Console.WriteLine("Ошибка ввода. Введите число");
                else
                {
                    IEnumerable<Contact> page = null;

                    switch (keyChar)
                    {
                        case '1':
                            page = contacts.Take(2);
                            break;

                        case '2':
                            page = contacts.Skip(2).Take(2);
                            break;

                        case '3':
                            page = contacts.Skip(4).Take(2);
                            break;
                    }

                    if (page == null)
                    {
                        Console.WriteLine($"Ошибка ввода. Страницы {keyChar} не существует");
                        continue;
                    }

                    foreach (var contact in page)
                        Console.WriteLine($"Имя: {contact.Name}\nМобильный телефон: {contact.Phone}\n");
                }
            }
        }
    }
}

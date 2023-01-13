using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_3_3
    {
        public static void GroupContacts(List<Contact1> contacts)
        {
            var groupedByEmail = contacts.GroupBy(c => c.Email
                                                 .Split('@')
                                                 .Last());
            foreach (var group in groupedByEmail)
            {
                if (group.Key.Contains("example"))
                {
                    Console.WriteLine("Вот фейковые адреса:");
                    foreach (var contact in group)
                        Console.WriteLine($"{contact.Name} {contact.Email}");
                }
                else
                {
                    Console.WriteLine("Реальные адреса:");
                    foreach(var contact in group)
                        Console.WriteLine($"{contact.Name} {contact.Email}");
                }

                Console.WriteLine();
            }

        }
    }
}

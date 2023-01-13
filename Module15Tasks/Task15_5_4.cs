using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_5_4
    {
        public static void DoDelayedQuery(List<Contact> contacts)
        {
            var chosenContacts = from contact in contacts 
                                 where contact.Name.StartsWith('И')
                                 select contact;

            contacts.Remove(contacts.Find(c => c.Name == "Игорь"));
            contacts.Remove(contacts.Find(c => c.Name == "Иван"));

            foreach (var choice in chosenContacts)
                Console.WriteLine($"{choice.Name}, {choice.Phone}");
        }

        public static void DoImmediateQuery(List<Contact> contacts)
        {
            var chosenContacts = (from contact in contacts
                                  where contact.Name.StartsWith('А')
                                  select contact).ToArray();

            contacts.Remove(contacts.Find(c => c.Name == "Андрей"));
            contacts.Remove(contacts.Find(c => c.Name == "Анна"));

            foreach (var choice in chosenContacts)
                Console.WriteLine($"{choice.Name}, {choice.Phone}");
        }
    }  
}

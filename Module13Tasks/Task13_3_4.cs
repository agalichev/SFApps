using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_3_4
    {
        public static void AddUnique(Contact newContact, List<Contact> phoneBook)
        {
            bool alreadyExists = false;

            foreach(var contact in phoneBook)
            {
                if(contact.Name == newContact.Name && contact.PhoneNumber == newContact.PhoneNumber)
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (!alreadyExists)
            {
                phoneBook.Add(newContact);
                phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

                foreach (var contact in phoneBook)
                    Console.WriteLine(contact.Name + ": " + contact.PhoneNumber);
            }
            
        }
    }
}

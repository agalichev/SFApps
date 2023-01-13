using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_2_2
    {
        public static void CountWrongPhoneNumbers(List<Contact> contacts)
        {
            var wrongPhones = (from contact in contacts
                               let phoneString = contact.Phone.ToString()
                               where !phoneString.StartsWith('7') || phoneString.Length != 11
                               select contact).Count();

            Console.WriteLine(wrongPhones);
        }
    }
}

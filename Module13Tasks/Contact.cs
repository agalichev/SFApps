using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public class Contact
    {
        public string Name { get; }
        public long PhoneNumber { get; }
        public string Email { get; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14Tasks
{
    public class Contact2
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; }
        public string Email { get; }

        public Contact2(string name, string lastName, long phoneNumber, string email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}

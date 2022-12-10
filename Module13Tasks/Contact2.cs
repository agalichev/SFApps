using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public class Contact2
    {
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact2(long phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}

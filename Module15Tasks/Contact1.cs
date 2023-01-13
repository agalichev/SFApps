using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public class Contact1
    {
        public string Name { get; set; }

        public long Phone { get; set; }
        public string Email { get; set; } 
        public Contact1(string name, long phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}

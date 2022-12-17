using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14Tasks
{
    public static class Task14_4
    {
        public static List<string> GetNameListFromArray(string[] names, char letter)
        {
            List<string> list = new List<string>();

            foreach(var person in names)
            {
                if(person.ToUpper().StartsWith(letter))
                    list.Add(person);
            }

            return list;
        }
    }
}

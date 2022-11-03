using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12Tasks
{
    public class Task12_1_2
    {
        public static void Greetings()
        {
            Console.WriteLine("Как вас зовут?");

            var name = Console.ReadLine();

            var greetings = "Привет, " + name;

            Console.WriteLine(greetings);
        }
    }
}

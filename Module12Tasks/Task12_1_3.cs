using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12Tasks
{
    public class Task12_1_3
    {
        public static void FillArray()
        {
            Console.WriteLine("Сколько элементов будет в массиве?");

            var count = Int32.Parse(Console.ReadLine());

            var array = new string[count];

            for(int i = 0; i < count; i++)
            {
                array[i] = Console.ReadLine();
            }

            Console.WriteLine("Все элементы записаны");
        }
    }
}

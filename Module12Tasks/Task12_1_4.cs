using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12Tasks
{
    public class Task12_1_4
    {
        static void CheckAge()
        {
            Console.WriteLine("Введите свой возраст");

            var age = Int32.Parse(Console.ReadLine());

            if (age > 13)
                Console.WriteLine("Вы успешно зарегистрированы");
            else
                Console.WriteLine("Пользователи младше 14 лет не могут быть зарегистрированы");
        }
    }
}

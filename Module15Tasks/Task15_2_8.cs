using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_2_8
    {
        static List<int> Numbers = new List<int>();

        public static void GetNumbersListInfo()
        {
            while (true)
            {
                Console.Write("Введите число: ");
                
                var input = Console.ReadLine();

                var isInteger = Int32.TryParse(input, out int inputNum);

                if (!isInteger)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы ввели не число!");
                    continue;
                }
                else
                {
                    Numbers.Add(inputNum);
                    Console.WriteLine($"Число {input} добавлено в список");

                    Console.WriteLine();

                    Console.WriteLine($"Количество чисел в списке: {Numbers.Count}");
                    Console.WriteLine($"Сумма всех чисел в списке: {Numbers.Sum()}");
                    Console.WriteLine($"Наибольшее число в списке: {Numbers.Max()}");
                    Console.WriteLine($"Наименьшее число в списке: {Numbers.Min()}");
                    Console.WriteLine($"Среднее: {Numbers.Average()}");
                }

                Console.WriteLine();
            }
        }
    }
}

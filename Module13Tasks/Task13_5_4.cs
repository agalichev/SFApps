using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Tasks
{
    public static class Task13_5_4
    {
        public static Stack<string> words = new Stack<string>();
        public static void OperateStackMyVersion()
        {
            while (true)
            {
                Console.Write("Введите команды <push>, <pop> или <peek>, чтобы оперировать со стеком: ");

                switch (Console.ReadLine())
                {
                    case "push":

                        Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в стек.");
                        Console.WriteLine();

                        var input = Console.ReadLine();

                        words.Push(input);

                        Console.WriteLine();
                        Console.WriteLine("В стеке:");

                        foreach (var word in words)
                            Console.WriteLine(" " + word);
                        
                        Console.WriteLine();

                        break;

                    case "pop":

                        if(words.Count != 0)
                        {
                            Console.WriteLine($"Извлекаем первый элемент(последний добавленный) из стека: {words.Pop()}");

                            Console.WriteLine();
                            Console.WriteLine("В стеке:");

                            foreach (var word in words)
                                Console.WriteLine(" " + word);

                            Console.WriteLine();

                            break;
                        }

                        Console.WriteLine("Стек пуст!");
                        break;

                    case "peek":

                        if(words.Count != 0)
                        {
                            Console.WriteLine($"Получаем последний элемент(сверху) из стека: {words.Peek()}");

                            break;
                        }

                        Console.WriteLine("Стек пуст!");

                        break;
                }
            }
        }

        public static void OperateStackSF()
        {
            while (true)
            {
                Console.Write("Введите команду <pop> или <peek>, чтобы извлечь или получить последний элемент(сверху) из стека: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "pop":

                        if (!words.TryPop(out string popResult))
                            Console.WriteLine("Стек пуст!");
                        else
                            Console.WriteLine($"Извлекаем последний элемент: {popResult}");

                        break;

                    case "peek":

                        if (!words.TryPeek(out string peekResult))
                            Console.WriteLine("Стек пуст!");
                        else
                            Console.WriteLine($"Получаем последний элемент: {peekResult}");

                        break;

                    default:

                        Console.Write("Введите слово и нажмите Enter, чтобы добавить его в стек: ");

                        input = Console.ReadLine();

                        words.Push(input);

                        Console.WriteLine("В стеке:");

                        foreach (var word in words)
                            Console.WriteLine(" " + word);

                        Console.WriteLine();

                        break;
                }
            }  
        }
    }
}

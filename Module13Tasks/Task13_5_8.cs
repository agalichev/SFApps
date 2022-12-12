using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;


namespace Module13Tasks
{
    public static class Task13_5_8
    {
        public static ConcurrentQueue<string> words = new ConcurrentQueue<string>();

        public static void ConcurrentQueueOperateMyVersion()
        {
            Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в очередь.");
            Console.WriteLine();

            StartQueueProcessing();

            while (true)
            {
                var input = Console.ReadLine();

                words.Enqueue(input);

                if (words.TryPeek(out var elem))
                    Console.WriteLine($"На очереди: {elem}");
            }
        }

        static void StartQueueProcessing()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    Thread.Sleep(5000);

                    if(words.TryDequeue(out var element))
                        Console.WriteLine("=====> " + element + " прошёл очередь");
                }
            }).Start();
        }
    }
}

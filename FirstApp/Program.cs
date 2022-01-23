using System;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  const string MyName = "Alexander";
            const byte Age = 32;
            bool HaveIAPet = false;
            const byte ShoeSize = 41;
            double result = 10 % 3;


            Console.WriteLine("My name is " + MyName);
            Console.WriteLine("My age is {0}", Age);
            Console.WriteLine("Do I have a pet? {0}", HaveIAPet);
            Console.WriteLine("My shoe size is {0}", ShoeSize);
            Console.WriteLine("\u0023");
            Console.WriteLine("IntMin {0} ", int.MinValue);
            Console.WriteLine("IntMax {0} ", int.MaxValue);
            Console.WriteLine("UShortMin = {0} UShortMax = {1}",ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("10 % 3 = {0}", result);*/

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("Your name is {0} and age is {1}", name, age);
            Console.Write("Enter your birthdate: ");
            var birthdate = Console.ReadLine();
            Console.WriteLine("Your birthdate is {0}", birthdate);
            Console.ReadKey();


        }
    }

    enum Semaphore : ushort
    {
        Red = 100,
        Yellow = 200,
        Green = 300
    }
}

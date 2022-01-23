// See https://aka.ms/new-console-template for more information

(string name, int age, string birthdate) quest;

Console.Write("Enter your name: ");

quest.name = Console.ReadLine();

Console.Write("Enter your age: ");

quest.age = Convert.ToInt32(Console.ReadLine());


Console.Write("Enter your birthdate: ");

quest.birthdate = Console.ReadLine();

Console.WriteLine(" Your name is {0},\n your age is {1},\n and your birthdate is {2} ", quest.name, quest.age, quest.birthdate);

Console.ReadKey();

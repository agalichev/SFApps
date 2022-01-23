// See https://aka.ms/new-console-template for more information

//----- Unit 4.5 Practiсal work -----
//----- Task 4.5.1 - Task 4.5.6 "User questionnaire" -----

for (int j = 0; j < 3; j++)
{
    Console.WriteLine($"Пользователь номер {j + 1}\n");

    (string Name, string LastName, string Login, int LogingLength, bool HavingAPet, double Age, string[] FavColors) User;

    Console.Write("Введите имя: ");

    User.Name = Console.ReadLine();

    Console.Write("Введите фамилию: ");

    User.LastName = Console.ReadLine();

    Console.Write("Введите логин: ");

    User.Login = Console.ReadLine();
    User.LogingLength = User.Login.Length;

    Console.Write("Есть ли у вас животные? (Да / Нет): ");

    var answer = Console.ReadLine();

    if (answer == "да")
    {
        User.HavingAPet = true;
    }
    else
    {
        User.HavingAPet = false;
    }

    Console.Write("Введите возраст пользователя: ");

    User.Age = double.Parse(Console.ReadLine());

    User.FavColors = new string[3];

    Console.WriteLine("Введите три любимых цвета");

    for (int i = 0; i < User.FavColors.Length; i++)
    {
        Console.Write($"Введите любимый цвет {i + 1}: ");

        User.FavColors[i] = Console.ReadLine();
    }

    Console.WriteLine();

}
//----- Unit 4.4 Corteges -----
//----- Task 4.4.2 "Cortege declaration with name"-----

/*(string name, int age, string birthdate) quest;

Console.Write("Enter your name: ");

quest.name = Console.ReadLine();

Console.Write("Enter your age: ");

quest.age = Convert.ToInt32(Console.ReadLine());


Console.Write("Enter your birthdate: ");

quest.birthdate = Console.ReadLine();

Console.WriteLine(" Your name is {0},\n your age is {1},\n and your birthdate is {2} ", quest.name, quest.age, quest.birthdate);
*/

//----- Task 4.4.3 "Cortege declaration without name"-----

/*var (name, age) = ("Cortana", 8 );

Console.WriteLine(" My name is {0} and i'm {1} years old", name, age);

Console.Write("Enter your name: ");

name = Console.ReadLine();

Console.Write("Enter your age: ");

age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("So, your name is {0}, and your age is {1}", name, age);*/

//----- Task 4.4.4 - Task 4.4.5 "Cortege Pet" -----

/*(string Name, string Type, double Age, int NameCount) Pet;

Console.Write("Enter your pet name: ");

Pet.Name = Console.ReadLine();
Pet.NameCount = Pet.Name.Length;

Console.Write("Enter your pet type: ");

Pet.Type = Console.ReadLine();

Console.Write("Enter your pet age: ");

Pet.Age = double.Parse(Console.ReadLine());

Console.WriteLine("Your pet characteristics:\n Name - {0},\n Type - {1},\n Age {2},\n NameCount {3}", Pet.Name, Pet.Type, Pet.Age, Pet.NameCount);
*/


Console.ReadKey();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");

var MyFavoriteColor = Console.ReadLine();

if (MyFavoriteColor == "red")
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.WriteLine("Your color is red!");
}

else if(MyFavoriteColor == "green")
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.WriteLine("Your color is green!");
}

else
{
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.WriteLine("Your color is cyan!");
}

Console.ReadKey();


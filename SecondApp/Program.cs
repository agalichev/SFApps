// See https://aka.ms/new-console-template for more information

// Unit 4.2: Tasks 4.2.9 - 4.2.11, 4.2.15

/*for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Iteration {0}", i);
    switch (Console.ReadLine())
    {
        case "red":
        
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("Your color is red!");
        break;

        case "green":
        
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("Your color is green!");
        break;

        case "cyan":
    
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("Your color is cyan!");
        break;

        default:
        
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("Your color is yellow!");
        break;
    }
    
}*/

/*int j = 0;


while (j < 3)
{
    Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
    Console.WriteLine("Iteration {0}", j);

    var text = Console.ReadLine();

    switch (text)
    {
        case "red":

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Your color is red!");
            break;

        case "white":

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Your color is white!");
            break;

        case "blue":

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Your color is blue!");
            break;

        default:

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Your color is cyan!");
            break;
    }

    if (text == "stop")
    {
        Console.WriteLine("Цикл остановлен");
        break;
    }

    j++;
}*/

/*int t = 0;

do
{
    Console.WriteLine("Iteration {0}", t);
    switch (Console.ReadLine())
    {
        case "red":

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Your color is red!");
            break;

        case "gray":

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Your color is gray!");
            break;

        case "yellow":

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Your color is yellow!");
            break;

        default:

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Your color is cyan!");
            break;
    }

    t++;

}
while (t < 3);
*/

// Code from screencast

/*int sum = 0;

while (true)
{
    Console.WriteLine("Ввведите число");

    var number = Convert.ToInt32(Console.ReadLine());

    if (number < 0 )
    {
        continue;
    }

    else if (number == 0)
    {
        break;
    }

    sum += number;
}

Console.WriteLine("Итоговая сумма: {0}", sum);*/

// Unit 4.3 Arrays

/*Console.WriteLine("Введите своё имя");

var name = Console.ReadLine();

Console.WriteLine("Ваше имя по буквам: ");

foreach(var letter in name)
{
    Console.Write(letter + " ");
}

Console.WriteLine("Последняя буква в вашем имени: {0}", name[name.Length - 1]);
*/

// Task 4.3.7

Console.WriteLine("Введите своё имя");

var name = Console.ReadLine();

/*char[] revers = new char[name.Length];

for (int i = 0; i < revers.Length; i++)
{
    revers[i] = name[name.Length - (i + 1)];
}

foreach (var ch in revers)
{
    Console.Write(ch + " ");
}
*/

for (int i = name.Length - 1; i >= 0; i--)
{
    Console.Write(name[i] + " ");
}

int[,] array = { { 1, 3, 5 }, { 2, 4, 6 } };

foreach (var item in array)
{
    Console.Write(item + " ");
}

Console.ReadKey();
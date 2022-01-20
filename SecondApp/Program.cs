// See https://aka.ms/new-console-template for more information
Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");

for (int i = 0; i < 3; i++)
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
    
}

int j = 0;

while(j < 3)
{
    Console.WriteLine("Iteration {0}", j);
    switch(Console.ReadLine())
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

    j++;
}

int t = 0;

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

Console.ReadKey();

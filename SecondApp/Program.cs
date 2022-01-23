// See https://aka.ms/new-console-template for more information

//----- Unit 4.2: Tasks 4.2.9 - 4.2.11, 4.2.15 -----

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

//----- Code from screencast -----

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

//----- Unit 4.3 Arrays -----

/*Console.WriteLine("Введите своё имя");

var name = Console.ReadLine();

Console.WriteLine("Ваше имя по буквам: ");

foreach(var letter in name)
{
    Console.Write(letter + " ");
}

Console.WriteLine("Последняя буква в вашем имени: {0}", name[name.Length - 1]);
*/

//----- Task 4.3.7 -----

/*Console.WriteLine("Введите своё имя");

var name = Console.ReadLine();
*/
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

/*for (int i = name.Length - 1; i >= 0; i--)
{
    Console.Write(name[i] + " ");
}

int[,] array = { { 1, 3, 5 }, { 2, 4, 6 } };

foreach (var item in array)
{
    Console.Write(item + " ");
}
*/

//----- Task 4.3.11 Array.Columns first -----

/*int[,] array = {{ 1, 2, 3, }, { 5, 6, 7 }, { 8, 9, 10 }, { 11, 12, 13 }};

for (int i = 0; i < array.GetUpperBound(1) + 1; i++)
{
    for (int k = 0; k < array.GetUpperBound(0) + 1; k++)
    {
        Console.Write(array[k, i] + " ");
    }

    Console.WriteLine();

}
*/

//----- Task 4.3.12 Array sort, Task 4.3.13 Array elemnsts sum -----

/*var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 };

int temp, sum = 0;

for (int i = 0; i < arr.Length; i++)
{
    for (int j = i + 1; j < arr.Length; j++)
    {
        if (arr[i] > arr[j])
        {
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    sum += arr[i];

}

foreach(var item in arr)
{
    Console.Write(item + " ");
}

Console.WriteLine("Сумма всех элементов массива arr: {0}", sum);
*/

// Array of colors
/*string[] favcolors = new string[3];

for(int i = 0; i < favcolors.Length; i++)
{   
    Console.WriteLine("Введите свой любимый цвет номер {0}", i + 1);
    favcolors[i] = Console.ReadLine(); 
}

foreach(var color in favcolors)
{
    foreach (var item in color)
    {
        Console.Write(item + " ");
    }
}
*/

//----- Task 4.3.14 "Jagged array" -----

/*int[][] array = new int[3][];

array[0] = new int[2] { 1, 2 };
array[1] = new int[3] { 1, 2, 3 };
array[2] = new int[5] { 1, 2, 3, 4, 5 };

foreach(var fitems in array)
{
    foreach(var sitems in fitems)
    {
        Console.Write(sitems + " ");
    }
}
*/

//----- Task 4.3.15 - Task 4.3.17 "Amount of positive numbers in one-dimensional and two-dimensional arrays. Two-dimensional array sort" -----

while (true)
{

    int n, rank;

    Console.Write("Введите ранк массива, с которым будете работать, или введите stop: ");

    var text = Console.ReadLine();

    if (text == "stop")
    {
        Console.WriteLine("Цикл остановлен");
        break;
    }

    rank = Convert.ToInt32(text);

    switch (rank)
    {
        // For Task 4.3.15
        case 1:

            Console.Write("Задайте размерность одномерного массива: ");
            n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            var AmountOne = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите число {0}-е: ", i + 1);

                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (var item in array)
            {
                if (item > 0)
                {
                    Console.Write(item + " ");
                    AmountOne++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Количество положительных элементов в массиве array: {0}", AmountOne);

            Console.WriteLine();
            Console.WriteLine("//Код из материала");

            AmountOne = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] > 0)
                {
                    AmountOne++;
                }
            }

            Console.WriteLine("Количество положительных элементов в массиве array: {0}", AmountOne);

            break;

        // For Task 4.3.16 - 4.3.17
        case 2:

            int[,] arr = { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };

            var AmountTwo = 0;

            int temp;

            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    for (int k = j + 1; k <= arr.GetUpperBound(1); k++)
                    {
                        if (arr[i, j] > arr[i, k])
                        {
                            temp = arr[i, k];
                            arr[i, k] = arr[i, j];
                            arr[i, j] = temp;
                        }
                    }

                    if (arr[i, j] > 0)
                    {
                        AmountTwo++;
                    }

                    Console.Write(arr[i, j] + " ");

                }

                Console.WriteLine();

            }

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            

            Console.WriteLine();
            Console.WriteLine("Количество положительных элементов в массиве arr: {0}", AmountTwo);

            break;

        default:

            if (rank < 0)
            {
                Console.WriteLine("Ранк не может быть меньше 1-го");
            }
            else if (rank > 2)
            {
                Console.WriteLine("Ранк должен быть не больше 2-х");
            }

            continue;

    }
}
Console.ReadKey();
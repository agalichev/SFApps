// See https://aka.ms/new-console-template for more information

//----- Module 5. Methods in C# -----

#region Repetition
//(string Name, string[] Dishes) User;

//Console.Write("Enter your Name: ");

//User.Name = Console.ReadLine();

//User.Dishes = new string[5];

//for (int i = 0; i < User.Dishes.Length; i++)
//{
//    Console.Write($"Enter your favorite dish {i + 1}: ");

//    User.Dishes[i] = Console.ReadLine();
//}

//Console.WriteLine($"So, your name {User.Name}.");

//foreach (var item in User.Dishes)
//{
//    Console.WriteLine("Your favorite dish is: {0}", item);
//}

//Console.ReadKey();
#endregion

//----- Unit 5.1 "Methods"

#region Task 5.1.5 "Method ShowColor()"

//static string ShowColor()
//{
//    Console.Write("Write your color in English with a small letter: ");
//    var color = Console.ReadLine();

//    switch (color)
//    {
//        case "red":

//            Console.BackgroundColor = ConsoleColor.Red;
//            Console.ForegroundColor = ConsoleColor.Black;

//            Console.WriteLine("Your color is red!");
//            break;

//        case "white":

//            Console.BackgroundColor = ConsoleColor.White;
//            Console.ForegroundColor = ConsoleColor.Black;

//            Console.WriteLine("Your color is white!");
//            break;

//        case "blue":

//            Console.BackgroundColor = ConsoleColor.Blue;
//            Console.ForegroundColor = ConsoleColor.White;

//            Console.WriteLine("Your color is blue!");
//            break;

//        default:

//            Console.BackgroundColor = ConsoleColor.Cyan;
//            Console.ForegroundColor = ConsoleColor.Black;

//            Console.WriteLine("Your color is cyan!");
//            break;
//    }

//    return color;
//}

//var (name, age, color) = ("Cortana", 8, "blue");

//string[] favcolors = new string[3];

//Console.WriteLine($"Ny name is {name}");
//Console.WriteLine($"My age is {age}");
//Console.WriteLine($"My favorite color is {color}\n");

//Console.Write("Enter your name: ");
//name = Console.ReadLine();
//Console.Write("Enter your age: ");
//age = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine($"So,\n your name is {name},\n your age is {age}");

//for (int i = 0; i < favcolors.Length; i++)
//{
//    favcolors[i] = ShowColor();
//}

//Console.WriteLine("Your favorite colors:");

//foreach (var item in favcolors)
//{
//    Console.WriteLine(item); 
//}

#endregion

#region Task 5.1.6 "Method GetArrayFromConsole()"

//static int[] GetArrayFromConsole()
//{
//    var myarray = new int[5];

//    for (int i = 0; i < myarray.Length; i++)
//    {
//        Console.Write($"Enter array elemnt {i + 1}: ");
//        myarray[i] = int.Parse(Console.ReadLine());
//    }

//    int temp;

//    for (int i = 0; i < myarray.Length; i++)
//    {
//        for (int j = i + 1; j < myarray.Length; j++)
//        {
//            if (myarray[i] > myarray[j])
//            {
//                temp = myarray[j];
//                myarray[j] = myarray[i];
//                myarray[i] = temp;
//            }
//        }
//    }

//    for (int i = 0;i < myarray.Length; i++)
//    {
//        Console.Write(myarray[i] + " ");
//    }

//    return myarray;

//}

//GetArrayFromConsole();

#endregion

//----- Unit 5.2 "Methods parameters"



Console.ReadKey();
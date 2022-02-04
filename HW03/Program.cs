// See https://aka.ms/new-console-template for more information

static (string, string, int, string[], string[]) GetUser()
{

    (string Name, string LastName, int Age, string[] Pets, string[] FavColors) User;

    Console.Write("Enter a name: ");
    User.Name = Console.ReadLine();

    Console.Write("Enter a lastname: ");
    User.LastName = Console.ReadLine();

    string checknum;
    int correctnum;

    do
    {
        Console.Write("Enter an age: ");
        checknum = Console.ReadLine();
    }
    while (!CheckNumber(checknum, out correctnum));

    User.Age = correctnum;

    bool HaveAPet, checkanswer;

    do
    {
        Console.Write("Have you a pets? (yes / no) ");
        switch (Console.ReadLine())
        {
            case "yes":

                checkanswer = true;
                HaveAPet = true;
                break;

            case "no":

                checkanswer = true;
                HaveAPet = false;
                break;

            default:

                checkanswer = false;
                HaveAPet = false;
                Console.WriteLine("Answer is not correct! Please, try again!");
                break;

        }
        
    }
    while(!checkanswer);

    if (HaveAPet)
    {

        do
        {

            Console.Write("Enter a number of your pets: ");
            checknum = Console.ReadLine();

        }
        while(!CheckNumber(checknum,out correctnum));

        User.Pets = GetUserPets(correctnum);

    }
    else
    {

        User.Pets = new string[1];

        for (int i = 0; i < User.Pets.Length; i++)
        {

            User.Pets[i] = "-";

        }

    }

    do
    {
        Console.Write($"Enter a {User.Name} {User.LastName} favorite colors number: ");
        checknum = Console.ReadLine();
    }
    while (!CheckNumber(checknum, out correctnum));

    User.FavColors = GetUserFavoriteColors(correctnum);

    return User;

}


static bool CheckNumber(string strnum, out int intnum)
{

    if (int.TryParse(strnum, out int number))
    {
        if (number > 0)
        {
            intnum = number;
            return true;
        }
    }
    
    intnum = 0;
    return false;
    
}

static string[] GetUserPets(int num)
{

    var petsarray = new string[num];

    for (int i = 0; i < petsarray.Length; i++)
    {
        Console.Write($"Enter a type and name of pet #{i} (for exampele: cat Felix): ");
        petsarray[i] = Console.ReadLine();
    }

    return petsarray;

}

static string[] GetUserFavoriteColors(int num)
{

    var colorsarray = new string[num];

    for (int i = 0; i < colorsarray.Length; i++)
    {

        Console.Write($"Enter a favorite color #{i + 1}: ");
        colorsarray[i] = Console.ReadLine();

    }

    return colorsarray;

}

static void ShowUser((string, string, int, string[], string[]) anyuser)
{

    Console.WriteLine($"Characteristics of added user:{Environment.NewLine}Name: {anyuser.Item1},{Environment.NewLine}LastName: {anyuser.Item2},{Environment.NewLine}Age: {anyuser.Item3}");

    Console.Write("Pets: ");
    for (int i = 0; i < anyuser.Item4.Length; i++)
    {

        Console.Write(anyuser.Item4[i] + " ");

    }

    Console.WriteLine();
    
    Console.Write("favorite colors: ");
    for (int i = 0; i < anyuser.Item5.Length; i++)
    {

        Console.Write(anyuser.Item5[i] + " ");

    }

}

var User = GetUser();

Console.WriteLine();

ShowUser(User);
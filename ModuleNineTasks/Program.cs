// See https://aka.ms/new-console-template for more information
#region Up-level
#region Task 9.1.3 - 9.1.4
//Exception exception = new Exception("Пользовательское исключение");
//exception.Data.Add("Дата создания исключения: ", DateTime.Now);
//exception.HelpLink = "www.google.ru";
#endregion

#region Tasks
//// Task 9.2.2
//try
//{
//    throw new ArgumentOutOfRangeException("Аргумент находится за пределами диапазона допустимых значений");

//}
//catch(Exception ex) 
//{
//    if (ex is ArgumentOutOfRangeException)
//    {
//        Console.WriteLine("Аргумент находится за пределами диапазона допустимых значений");
//    }
//    else
//    {
//        Console.WriteLine("Произошла ошибка");
//    }
//}
//finally
//{
//    Console.WriteLine("Блок Finally сработал");
//}

//// Task 9.2.3
//try
//{
//    throw new RankException("В метод передается массив с неправильным числом измерений");
//}
//catch(RankException ex)
//{
//    Console.WriteLine($"{ex.Message}\n{ex.GetType()}");
//}
//finally
//{
//    Console.WriteLine("Блок Finally сработал");
//}
#endregion

CalculateDelegate calculateDelegate = Subtraction;
calculateDelegate += Addition;

//Console.WriteLine("Результат вычитания 1: {0}", subDelegate.Invoke(2, 6));
//Console.WriteLine("Результат вычитания 2: {0}", subDelegate(2, 6)); // Task 9.3.3
calculateDelegate.Invoke(2, 6);

// Task 9.3.5
calculateDelegate -= Addition;
calculateDelegate.Invoke(2, 9);

// Task 9.3.2
//static int Subtraction(int a, int b)
//{
//    return b - a;
//}

// Task 9.3.7
ShowMessageDelegate showMessageDelegate = ShowMessage;
showMessageDelegate.Invoke();

SumDelegate sumDelegate = Sum;
var result = sumDelegate.Invoke(3, 6, 1);
Console.WriteLine(result);

CheckLengthDelegate checkLengthDelegate = CheckLength;
var status = checkLengthDelegate.Invoke("CDEV-14");
Console.WriteLine(status);

Console.WriteLine();

Console.WriteLine("Применяем шаблонные делегаты");

Func<int, int, int, int> additionFunc = Sum;
var result1 = additionFunc(3, 6, 1);
Console.WriteLine(result1);

Action showMessageAction = new Action (ShowMessage);
showMessageAction.Invoke();

Predicate<string> checkLengthPredicate = CheckLength;
var status1 = checkLengthPredicate.Invoke("CDEV");
Console.WriteLine(status1);

Console.WriteLine();

// Task 9.3.12
string message = "Hello user";
ShowMessageDelegate smd = delegate ()
{
    Console.WriteLine(message);
};
smd.Invoke();

// Task 9.3.13
Func<int> randomNumberFunc = delegate ()
{
    return new Random().Next(0, 100);
}; 
var result2 = randomNumberFunc.Invoke();
Console.WriteLine(result2);

Console.WriteLine();
Console.WriteLine("Применяем лямбда-выражения");
// Task 9.3.14
ShowMessageDelegate1 smd1 = (string messageDelegate) => Console.WriteLine(messageDelegate);
smd1.Invoke(message);

// Task 9.3.15
RandomNumberDelegate rnd = () => new Random().Next(0, 100);
Console.WriteLine(rnd.Invoke());

Console.WriteLine();
Console.WriteLine("Применяем ковариантность и контрвариантность делегатов");

// Task 9.4.2
CarCheckDelegate carCheckDelegate = CarCheck;
CarCheckDelegate lexusCheckDelegate = LexusCheck;

// Task 9.4.3
LexusInfo lxInfoDelegate = GetCarInfo;
lxInfoDelegate.Invoke(new Lexus());

// Unit 9.5 - Event creation practice
NumberReader nr = new NumberReader();
nr.NumberEnteredEvent += ShowNumber;
do
{
    try
    {
        nr.Read();
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Введено некорректное значение!");
    }
}
while (true);

Console.ReadLine();
#endregion

#region Methods and classes definition
static void Subtraction(int a, int b)
{
    Console.WriteLine("Результат вычитания: {0}", b - a);
}

static void Addition(int a, int b)
{
    Console.WriteLine("Результат сложения: {0}", a + b);
}

static void ShowMessage()
{
    Console.WriteLine("Hello user");
}

static int Sum(int a, int b, int c)
{
    return a + b + c;
}

static bool CheckLength(string row)
{
    if (row.Length > 3) return true;
    return false;
}

// Task 9.4.2 - 9.4.3
static Car CarCheck()
{
    return null;
}

static Lexus LexusCheck()
{
    return null;
}

static void GetCarInfo(Car car)
{
    Console.WriteLine(car.GetType());
}

static void ShowNumber(int number) 
{
    switch (number)
    {
        case 1:
            Console.WriteLine("Введено 1");
            break;
        case 2:
            Console.WriteLine("Введено 2");
            break;
        case 3:
            Console.WriteLine("Введено 3");
            break;
        case 4:
            Console.WriteLine("Введено 4");
            break;
    }
}

class Car { }
class Lexus : Car { }

// Unit 9.5 - Event creation practice

class NumberReader
{
    public event NumberEnteredDelegate NumberEnteredEvent;

    public void Read()
    {
        Console.WriteLine();
        Console.Write("Введите число от 1 до 4: ");

        int number = Convert.ToInt32(Console.ReadLine());
        if (number < 1 || number > 4) throw new FormatException();

        NumberEntered(number);
    }

    protected virtual void NumberEntered(int number)
    {
        NumberEnteredEvent.Invoke(number);
    }
}
#endregion

#region Delegates
delegate void ShowMessageDelegate();
delegate int SumDelegate(int a, int b, int c);
delegate bool CheckLengthDelegate(string row);
//public delegate int SubDelegate(int a, int b);
public delegate void CalculateDelegate(int a, int b);
delegate void ShowMessageDelegate1(string message);
delegate int RandomNumberDelegate();
delegate Car CarCheckDelegate(); // Task 9.4.2
delegate void LexusInfo(Lexus lexus);
delegate void NumberEnteredDelegate(int number);
#endregion
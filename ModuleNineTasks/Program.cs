// See https://aka.ms/new-console-template for more information

#region Task 9.1.3 - 9.1.4
//Exception exception = new Exception("Пользовательское исключение");
//exception.Data.Add("Дата создания исключения: ", DateTime.Now);
//exception.HelpLink = "www.google.ru";
#endregion

#region Task 9.2.2 - 9.2.3
// Task 9.2.2
try
{
    throw new ArgumentOutOfRangeException("Аргумент находится за пределами диапазона допустимых значений");

}
catch(Exception ex) 
{
    if (ex is ArgumentOutOfRangeException)
    {
        Console.WriteLine("Аргумент находится за пределами диапазона допустимых значений");
    }
    else
    {
        Console.WriteLine("Произошла ошибка");
    }
}
finally
{
    Console.WriteLine("Блок Finally сработал");
}

// Task 9.2.3
try
{
    throw new RankException("В метод передается массив с неправильным числом измерений");
}
catch(RankException ex)
{
    Console.WriteLine($"{ex.Message}\n{ex.GetType()}");
}
finally
{
    Console.WriteLine("Блок Finally сработал");
}

#endregion
Console.ReadLine();
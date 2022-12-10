using System.Collections;
using System.Diagnostics;

namespace Module13Tasks
{
    internal class Program
    {
        private static Dictionary<string, Contact2> PhoneBook = new Dictionary<string, Contact2>()
        {
            ["Татьяна"] = new Contact2(89242666778, "tanya@gmail.com"),
            ["Виктор"] = new Contact2(89141145533, "vitya@gmail.com")
        };

        private static SortedDictionary<string, Contact2> SortedPhoneBook = new SortedDictionary<string, Contact2>()
        {
            ["Татьяна"] = new Contact2(89242666778, "tanya@gmail.com"),
            ["Виктор"] = new Contact2(89141145533, "vitya@gmail.com")
        };

        static void Main(string[] args)
        {
            //Task 13.5.4
            Task13_5_4.OperateStackMyVersion();

            // Применяем Dictionary<TKey, TValue>

            //Console.WriteLine("Текущий список контактов:");

            //ShowAllContacts();

            //var watchOne = Stopwatch.StartNew();

            //PhoneBook.TryAdd("Андрей", new Contact2(89148887644, "andrey@gmail.com"));

            //Console.WriteLine($"Вставка в словарь: {watchOne.Elapsed.TotalMilliseconds} мс");

            //Console.WriteLine("Список контактов обновился:");

            //ShowAllContacts();

            //if (PhoneBook.TryGetValue("Андрей", out Contact2 contact))
            //    contact.PhoneNumber = 89149998989;

            //Console.WriteLine("Был изменен один из контактов:");

            //ShowAllContacts();

            // Применяем SortedDictionary<TKey, TValue>

            //var watchTwo = Stopwatch.StartNew();

            //SortedPhoneBook.TryAdd("Андрей", new Contact2(89148887644, "andrey@gmail.com"));

            //Console.WriteLine($"Вставка в сортированный словарь: {watchTwo.Elapsed.TotalMilliseconds} мс");

            //do
            //{
            //    Console.Write("Введите текст: \n>>");

            //    var myText = Console.ReadLine();

            //    Console.WriteLine(Task13_3_10.GetLettersCount(myText));

            //    Console.WriteLine("Пожалуйста, продолжайте!\n");

            //}
            //while (true);

            //string text = "Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, " +
            //               "учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";

            //Console.WriteLine(Task13_3_10.GetLettersCount(text));

            //var months = new List<string>()
            //{
            //    "Jan", "Feb", "Mar", "Apr", "May"
            //};

            //var missing = new ArrayList()
            //{
            //    1, 2, 3, 5, "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            //};

            //Task13_3_5.ModifyCollection(months, missing);

            //List<Contact> phoneBook = new List<Contact>();

            //phoneBook.Add(new Contact("Андрей", 89242223344, "andrey@gmail.com"));
            //phoneBook.Add(new Contact("Игорь", 89143332333, "igor@yandex.ru"));
            //phoneBook.Add(new Contact("Алина", 89242128899, "alina@outlook.com"));

            ////Task13_3_4.AddUnique(new Contact("Валентина", 89145556565, "valya@gmail.com"), phoneBook);
            //Task13_3_4.AddUnique(new Contact("Алина", 89242128898, "alina@outlook.com"), phoneBook);

            //ArrayList input = new ArrayList()
            //{
            //    1,
            //    "One",
            //    23,
            //    "PunchMan",
            //    43,
            //    "anime"
            //};

            //foreach(var element in Task13_2_6.OptimizeArrayList(input))
            //    Console.WriteLine(element);

            //var month = new[]
            //{
            //    "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            //};

            //var numbers = new[]
            //{
            //    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            //};

            //var combineList = Task13_2_5.GetArrayList(month, numbers);

            //foreach(var item in combineList)
            //    Console.WriteLine(item);

            //string path = "C:\\Users\\lexga\\Downloads\\cdev_Text.txt";

            //Console.WriteLine(Task13_1_6.GetWordsNumber(path));

            //Console.WriteLine(Task13_1_4.CheckAscending(new[] {1, 5, 7, 12}));
            //Console.WriteLine(Task13_1_4.CheckAscending(new[] {5, 1, 2, 4}));

            Console.ReadLine();
        }

        static void ShowAllContacts()
        {
            foreach (var contact in PhoneBook)
                Console.WriteLine(contact.Key + ": " + contact.Value.PhoneNumber);
            Console.WriteLine();
        }
    }
}
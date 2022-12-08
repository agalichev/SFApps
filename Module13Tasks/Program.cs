using System.Collections;

namespace Module13Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var months = new List<string>()
            {
                "Jan", "Feb", "Mar", "Apr", "May"
            };

            var missing = new ArrayList()
            {
                1, 2, 3, 5, "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

            Task13_3_5.ModifyCollection(months, missing);

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


    }
}
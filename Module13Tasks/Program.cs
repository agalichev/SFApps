using System.Collections;

namespace Module13Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList input = new ArrayList()
            {
                1,
                "One",
                23,
                "PunchMan",
                43,
                "anime"
            };

            foreach(var element in Task13_2_6.OptimizeArrayList(input))
                Console.WriteLine(element);

            var month = new[]
            {
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

            var numbers = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            };

            var combineList = Task13_2_5.GetArrayList(month, numbers);

            foreach(var item in combineList)
                Console.WriteLine(item);

            string path = "C:\\Users\\lexga\\Downloads\\cdev_Text.txt";

            Console.WriteLine(Task13_1_6.GetWordsNumber(path));

            Console.WriteLine(Task13_1_4.CheckAscending(new[] {1, 5, 7, 12}));
            Console.WriteLine(Task13_1_4.CheckAscending(new[] {5, 1, 2, 4}));

            Console.ReadLine();
        }


    }
}
namespace Module14Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 14.4
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            var orderedList = Task14_4.GetNameListFromArray(people, 'А');

            orderedList.Sort();

            foreach(var person in orderedList)
            {
                Console.WriteLine(person);
            }
            #endregion

            Console.ReadLine();
        }
    }
}
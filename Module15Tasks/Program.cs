using System.Numerics;

namespace Module15Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task15_1_4.SearchCommonChars("Антоха", "Суматоха");

            //Task 15.1.5
            var softwareManufacturer = new List<string>
            {
                "Microsoft", "Apple", "Oracle"
            };

            var hardwareManufacturer = new List<string>
            {
                "Apple", "Samsung", "Intel"
            };

            var itCompanies = Task15_1_5.GetUniqueList(softwareManufacturer, hardwareManufacturer);

            foreach (var it in itCompanies)
                Console.WriteLine(it);

            //Task15_1_6.SearchUniqueChars();

            var factorial = Task15_2_1.Factorial(30);
            Console.WriteLine(factorial);

            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 79994500508 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675334 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };

            Task15_2_2.CountWrongPhoneNumbers(contacts);
            var numbers = new[] { 1, 7, 45, 23 };

            Console.WriteLine(Task15_2_3.Average(numbers));

            //Task15_2_8.GetNumbersListInfo();

            var phoneBook = new List<Contact1>()
            {
                new Contact1("Игорь", 79990000001, "igor@example.com"),
                new Contact1("Сергей", 79990000010, "serge@example.com"),
                new Contact1("Анатолий", 79990000011, "anatoly@example.com"),
                new Contact1("Валерий", 79990000012, "valera@example.com"),
                new Contact1("Сергей", 799900000013, "serg@gmail.com"),
                new Contact1("Иннокентий", 799900000013, "innokentii@example.com")
            };

            Task15_3_3.GroupContacts(phoneBook);

            //Task 15.4.1
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1 },
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2 },
                new Employee() { DepartmentId = 2, Name = "Виктор", Id = 3 },
                new Employee() { DepartmentId = 3, Name = "Альберт", Id = 4 }
            };

            Task15_4_1.ShowEmploeeAndDepartment(employees, departments);

            Console.WriteLine();

            Task15_4_2.GroupDepsWithEmployees(departments, employees);

            Console.WriteLine();

            Task15_5_4.DoDelayedQuery(contacts);

            Task15_5_4.DoImmediateQuery(contacts);

            Console.ReadLine();
        }
    }
}
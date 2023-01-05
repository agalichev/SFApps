using System.Linq;
namespace Module14Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 14.4
            Console.WriteLine("Task 14.4");

            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            var orderedList = Task14_4.GetNameListFromArray(people, 'А');

            orderedList.Sort();

            foreach(var person in orderedList)
            {
                Console.WriteLine(person);
            }
            #endregion

            Console.WriteLine();

            string[] somePeople = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            var selectedPeople = from p in somePeople // промежуточная переменная p
                                 where p.StartsWith("А") // фильтрация по условию 
                                 orderby p // сортировка по возрастанию (дефолтная)
                                 select p; // выбираем объект и сохраняем в выборку

            foreach(var s in selectedPeople)
                Console.WriteLine(s);

            Console.WriteLine();

            #region Task 14.8
            Console.WriteLine("Task 14.8");

            var objects = new List<object>()
            {
                1,
                "Сергей",
                "Андрей",
                300
            };

            var selectedNames = from n in objects
                                where n is string
                                orderby n
                                select n;

            foreach(var name in selectedNames)
                Console.WriteLine(name);

            Console.WriteLine();

            foreach (var stringObject in objects.Where(o => o is string).OrderBy(o => o))
                Console.WriteLine(stringObject);
            #endregion

            Console.WriteLine("Task 14.1.1");

            var russianCities = new List<City>();

            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var bigCities = russianCities.Where(c => c.Name.Length <= 10).OrderBy(c => c.Name.Length);

            Console.WriteLine();

            Console.WriteLine("Task 14.1.2");

            string[] text = { "Раз два три",
                "четыре пять шесть",
                "семь восемь девять" };

            var words = from str in text
                from word in str.Split(' ')
                select word;

            foreach(string word in words)
                Console.WriteLine(word);

            Console.WriteLine();

            Console.WriteLine("Task 14.1.5");

            var companies = new Dictionary<string, string[]>();

            companies.Add("Apple", new[] { "Mobile", "Desktop" });
            companies.Add("Samsung", new[] { "Mobile" });
            companies.Add("IBM", new[] { "Desktop" });

            var mobileCompanies = companies
                .Where(c => c.Value.Contains("Mobile"));

            foreach(var conmpany in mobileCompanies)
                Console.WriteLine(conmpany.Key);

            Console.WriteLine();

            Console.WriteLine("Task 14.1.6");

            var numList = new List<int[]>()
            {
                new[] {2, 3, 7, 1},
                new[] {45, 17, 88, 0},
                new[] {23, 32, 44, -6},
            };

            var orderedNums = numList
                .SelectMany(s => s)
                .OrderBy(s => s);

            foreach(var ord in orderedNums)
                Console.WriteLine(ord);

            Console.WriteLine();

            Console.WriteLine("Пример использования анонимной сущности при проецировании исходных данных в другой тип");

            List<Student> students = new List<Student>()
            {
                new Student { Name = "Андрей", Age = 23, Languages = new List<string> { "английский", "немецкий" } },
                new Student { Name = "Сергей", Age = 27, Languages = new List<string> { "аглийский", "французский" } },
                new Student { Name = "Дмитрий", Age = 29, Languages = new List<string> { "английский", "испанский" } },
                new Student { Name = "Василий", Age = 24, Languages = new List<string> { "испанский", "немецкий" }}
            };

            var studentApplication = from s in students
                                    select new
                                    {
                                        FirstName = s.Name,
                                        YearOfBirth = DateTime.Now.Year - s.Age
                                    };

            foreach (var application in studentApplication)
                Console.WriteLine($"{application.FirstName}, {application.YearOfBirth}\n");

            Console.WriteLine("Task 14.2.1");

            string[] words2 = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

            var sortedWords = words2.Select(w => new
            {
                Animal = w,
                NameLength = w.Length,
            }).OrderBy(a => a.NameLength);

            foreach (var word in sortedWords)
                Console.WriteLine(word.Animal);

            Console.WriteLine();

            Console.WriteLine("Task 14.2.3");

            var studentList = from s in students
                              let yearOfBirth = DateTime.Now.Year - s.Age
                              where s.Age < 27
                              select new Application
                              {
                                  Name = s.Name,
                                  YearOfBirth = yearOfBirth,
                              };

            foreach (var student in studentList)
                Console.WriteLine(student.Name + "," + student.YearOfBirth);

            Console.WriteLine();

            Console.WriteLine("Task 14.2.4");

            var students1424 = new List<Student>
            {
                new Student { Name = "Андрей", Age = 23, Languages = new List<string> { "английский", "немецкий" } },
                new Student { Name = "Сергей", Age = 27, Languages = new List<string> { "английский", "французский" } },
                new Student { Name = "Дмитрий", Age = 29, Languages = new List<string> { "английский", "испанский"} }
            };

            //список курсов
            var coarses = new List<Coarse>
            {
                new Coarse { Name = "Язык программирования C#", StartDate = new DateTime(2023, 01, 20) },
                new Coarse { Name = "Язык SQL и реляционные базы данных", StartDate = new DateTime(2023, 01, 15) }
            };

            var studentsWithCoarses = from s in students1424
                                      where s.Age < 29
                                      where s.Languages.Contains("английский")
                                      let birthYear = DateTime.Now.Year - s.Age
                                      from c in coarses
                                      where c.Name.Contains("C#")
                                      select new
                                      {
                                          Name = s.Name,
                                          BirthYear = birthYear,
                                          CoarseName = c.Name
                                      };

            foreach (var student in studentsWithCoarses)
                Console.WriteLine($"Студент {student.Name}, {student.BirthYear} добавлен к курсу {student.CoarseName}\n");
            
            //Task 14.2.5
            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 89999455005 },
                new Contact() { Name = "Сергей", Phone = 89999904023 },
                new Contact() { Name = "Иван", Phone = 89998004333 },
                new Contact() { Name = "Игорь", Phone = 89992125677 },
                new Contact() { Name = "Анна", Phone = 89141134566 },
                new Contact() { Name = "Василий", Phone = 89241045572 }
            };

            //Task14_2_5.CreateContactsBook(contacts);

            //Task 14.2.10

            var phoneBook = new List<Contact2>();

            phoneBook.Add(new Contact2("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact2("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact2("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact2("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact2("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact2("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            //Task14_2_10.WatchContactBook(phoneBook);



            Console.ReadLine();
        }
    }
}
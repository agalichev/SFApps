//----- Module 6. OOP. Introduction -----

namespace ModuleSixApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human human = new Human();
			human.Greetings();

			human.name = "Vasiliy";
			human.age = 30;
			human.Greetings();

			Console.WriteLine("----------------");

			var department = GetCurrentDepartment();

			if (department?.Company?.Type == "Bank" && department?.City?.Name == "St. Petersburg")
            {
				Console.WriteLine($"The {department?.Company?.Name ?? "Unknown"} bank has a branch in St. Petersburg.");
            }
			Console.WriteLine();

			Console.ReadKey();



        }

		static Department GetCurrentDepartment()
		{
			Department Department = new Department();
			Department.Company = new Company();
			Department.City = new City();

			Console.Write("Enter a type of company: ");
			Department.Company.Type = Console.ReadLine();

			Console.Write("Enter a city of company: ");
			Department.City.Name = Console.ReadLine();

			Console.Write("Enter a name of company: ");
			Department.Company.Name = Console.ReadLine();

			return Department;
		}

	}

//----- Unit 6.2 "Classes and structs" -----

	class Human
    {
		// Поля класса
		public string name;
		public int age;

		// Метод класса
		public void Greetings()
		{
			Console.WriteLine("Меня зовут {0}, мне {1}", name, age);
		}
	}

	struct Animal
	{
		// Поля структуры
		public string type;
		public string name;
		public int age;

		// Метод структуры
		public void Info()
		{
			Console.WriteLine("Это {0} по кличке {1}, ему {2}", type, name, age);
		}

	}

	#region Task 6.2.2 "Add a Pen class"

	class Pen
	{
		public string color;
		public int cost;

		public Pen()
        {
			color = "black";
			cost = 100;
        }

		public Pen(string PenColor, int PenCost)
        {
			color = PenColor;
			cost = PenCost;
        }
	}

	#endregion

	#region Task 6.2.8 "Create a Rectangle class"

	public class Rectangle
	{
		public int a;
		public int b;

		public int Square()
		{
			return a * b;
		}
		
		public Rectangle()
        {
			a = 6;
			b = 4;
        }

		public Rectangle(int equal)
        {
			a = equal;
			b = equal;
        }

		public Rectangle(int firstside, int secondside)
        {
			a = firstside;
			b = secondside;
        }

	}

	#endregion

	//----- Unit 6.3 "Features of working with reference and value data types" -----

	#region Task 6.3.1

	class Company
    {
		public string Name;
		public string Type;
    }

	class Department
    {
		public Company Company;
		public City City;
    }

	class City
    {
		public string Name;
    }


    #endregion 
}


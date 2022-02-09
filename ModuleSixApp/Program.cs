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

			Console.ReadKey();

        }
    }

//----- Unit 6.2 "Classes and structs".

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

}


// See https://aka.ms/new-console-template for more information

namespace ModuleSevenApp // Note: actual namespace depends on the project name.
{
	public class Program
	{
		public static void Main(string[] args)
		{
            HomoSapiens hs = new HomoSapiens();
            Human human = hs;
            Creature creature = human;
            Creature secondCreature = new Animal();
		}
	}
	#region Task 7.1.4 "Create Employee class inheritors: ProjectManager and Developer"
	class Employee
    {
		public string Name;
		public int Age;
		public int Salary;
    }

	class ProjectManager: Employee
    {
		public string ProjectName;
    }

	class Developer: Employee
    {
		private int ProgrammingLanguage;
    }

    #endregion

    #region Task 7.1.5 "Create a classes scheme"
	class Food
    {

    }

	class Vegetables: Food
    {
		
    }

	class Fruits: Food
    {

    }

	class Potato: Vegetables
    {

    }

	class Carrot: Vegetables
    {

    }

	class Apple: Fruits
    {

    }

	class Pear: Fruits
    {

    }

    class Banana: Fruits
    {

    }

    #endregion

    #region Task 7.1.6 "Implement a constructor that populates the fields of this class"

    class Obj
    {
        private string Name;
        private string owner;
        private int length;
        private int count;

        public Obj(string name, string ownerName, int objLength, int count)
        {
            this.Name = name;
            owner = ownerName;
            length = objLength;
            this.count = count;
        }
    }

    #endregion

    #region Task 7.1.10 "Create 2 cotstructors for DerivedClass", Task 7.2.3 "Virtual and override Display method", Task 7.2.4 "Override property "Counter"", Task 7.2.5 "Using "base" in overrided method"

    class BaseClass
    {
        protected string Name;
        public virtual int Counter { get; set; }

        public BaseClass(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("BaseClass class method");
        }

    }

    class DerivedClass: BaseClass
    {
        public string Description;

        private int counter;
        public override int Counter 
        { 
            get 
            { 
                return counter;
            } 
            set 
            {
                if (value >= 0)
                {
                    counter = value;
                }
            } 
        }

        public DerivedClass(string name, string description): base(name)
        {
            Description = description;
        }

        public DerivedClass(string name, string description, int counter): base(name)
        {
            Description = description;
            Counter = counter;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("DerivedClass class method");
        }

    }

    #endregion

    class Creature { }

    class Animal : Creature { }

    class Human : Creature { }

    class HomoSapiens : Human { }


}
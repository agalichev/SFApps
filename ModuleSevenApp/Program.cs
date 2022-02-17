// See https://aka.ms/new-console-template for more information

namespace ModuleSevenApp // Note: actual namespace depends on the project name.
{
	public class Program
	{
		public static void Main(string[] args)
		{

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

    #region Task 7.1.10 "Create 2 cotstructors for DerivedClass"

    class BaseClass
    {
        protected string Name;

        public BaseClass(string name)
        {
            Name = name;
        }
    }

    class DerivedClass: BaseClass
    {
        public string Description;

        public int Counter;

        public DerivedClass(string name, string description): base(name)
        {
            Description = description;
        }

        public DerivedClass(string name, string description, int counter): base(name)
        {
            Description = description;
            Counter = counter;
        }
    }

    #endregion
}
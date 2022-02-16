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
}

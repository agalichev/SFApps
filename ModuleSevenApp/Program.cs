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
}

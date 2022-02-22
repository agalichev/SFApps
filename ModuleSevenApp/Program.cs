// See https://aka.ms/new-console-template for more information

namespace ModuleSevenApp // Note: actual namespace depends on the project name.
{
	public class Program
	{
		public static void Main(string[] args)
		{
            //HomoSapiens hs = new HomoSapiens();
            //Human human = hs;
            //Creature creature = human;
            //Creature secondCreature = new Animal();

            D d = new D();
            E e = new E();

            d.Display();
            ((A)e).Display();
            ((B)d).Display();
            ((A)d).Display();

            Vector a = new Vector { X = 3, Y = 5 };

            Vector D = +a;
            Vector E = a + (10,-5);

            Console.ReadKey();
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

    #region Task 7.1.6 "Implement a constructor that populates the fields of this class", Task 7.2.12 "Operators + and - overloading", Task 7.5.2 "Create static field MaxValue in Obj class"

    class Obj
    {
        public string Name;
        public string Description;
        public static int MaxValue = 2000;
        private string owner;
        private int length;
        private int count;
        public int Value;

        public Obj()
        {

        }

        public Obj(string name, string ownerName, int objLength, int count)
        {
            this.Name = name;
            owner = ownerName;
            length = objLength;
            this.count = count;
        }

        public static Obj operator + (Obj a, Obj b)
        {
            return new Obj
            {
                Value = a.Value + b.Value
            };
        }

        public static Obj operator - (Obj a, Obj b)
        {
            return new Obj
            {
                Value = a.Value - b.Value
            };
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

    #region Example

    
    class Creature { }

    class Animal : Creature { }

    class Human : Creature { }

    class HomoSapiens : Human { }

    #endregion

    #region Task 7.2.7 "Create a classes scheme (using hinding)"
    class A 
    {
        public virtual void Display()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public void Display()
        {
            Console.WriteLine("B");
        }
    }
    class C : A 
    {
        public override void Display()
        {
            Console.WriteLine("C");
        }
    }

    class D : B
    {
        public void Display()
        {
            Console.WriteLine("D");
        }
    }

    class E : C
    {
        public void Display()
        {
            Console.WriteLine("E");
        }
    }

    #endregion

    #region Example

    class Vector
    {
        public int X;
        public int Y;

        public static Vector operator + (Vector a)
        {
            return new Vector
            {
                X = a.X,
                Y = a.Y,
            };
        }
        
        public static Vector operator + (Vector a, (int X, int Y) b)
        {
            return new Vector
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }

    }

    #endregion

    #region Task 7.2.14 "Indexer for IndexingClass class"

    class IndexingClass
    {
        private int[] array;

        public IndexingClass(int[] array)
        {
            this.array = array;
        }

        public int this[int index]
        {
            get
            {
                if (index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if(index < array.Length)
                {
                    array[index] = value;
                }
            }
        }

    }

    #endregion

    #region Task 7.3.3 "Abstract class ComputerPart"

    abstract class ComputerPart
    {
        public abstract void Work();
    }

    class MotherBoard : ComputerPart
    {
        public override void Work()
        {
              
        }
    }

    class Processor : ComputerPart
    {
        public override void Work()
        {

        }
    }

    class GraphicCard : ComputerPart
    {
        public override void Work()
        {

        }
    }

    #endregion

}
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

            int num1 = 7;
            int num2 = -13;
            int num3 = 0;

            Console.WriteLine(num1.GetNegative());
            Console.WriteLine(num1.GetPositive());
            Console.WriteLine(num2.GetNegative());
            Console.WriteLine(num2.GetPositive());
            Console.WriteLine(num3.GetNegative());
            Console.WriteLine(num3.GetPositive());

            int count = 0;
            int number = 680000;

            
            string format = "{0:AX ######}";
            
            foreach (char c in format)
            {
                if (c == '#')
                    count++;
            }
            count = (int)(Math.Pow(10, count) - 1);
            Console.WriteLine(String.Format(format, number));
            Console.WriteLine(count);
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

    #region Task 7.1.6 "Implement a constructor that populates the fields of this class", Task 7.2.12 "Operators + and - overloading", Task 7.5.2 "Create static field MaxValue in Obj class", Task 7.5.5 "Initialize static fields in Obj class"

    class Obj
    {
        public string Name;
        public string Description;
        public static int MaxValue;
        private string owner;
        private int length;
        private int count;
        public int Value;
        public static string Parent;
        public static int DaysInWeek;
        
        public Obj()
        {

        }
        static Obj()
        {
            MaxValue = 2000;
            Parent = "System.Object";
            DaysInWeek = 7;
        }

        public Obj(string name, string ownerName, int objLength, int count)
        {
            this.Name = name;
            owner = ownerName;
            length = objLength;
            this.count = count;
        }

        public Obj(int number)
        {
            Value = number;
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

    #region Task 7.5.3 "Create a Helper class and Swap method"

    class Helper
    {
        public static void Swap(ref int number1,ref int number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
        }
    }

    #endregion

    #region Task 7.5.9 "Extension methods for int"

    static class IntExtensions
    {
        public static int GetNegative(this int value)
        {
            if (value > 0)
            {
                return -value;
            }
            else
            {
                return value;
            }
        }

        public static int GetPositive(this int value)
        {
            if (value < 0)
            {
                return -value;
            }
            else
            {
                return value;
            }
        }
    }

    #endregion

    #region Task 7.6.2 "Create a generic class Car and ElectricEngine and GasEngine classes", Task 7.6.7 "Add Battery, Differential and Wheel classes, and ChangePart method into Car class", Task 7.6.9 "Set restrictions on the generic types of the Car class", Task 7.6.10 "Rename the generic parameters", Task 7.6.12 "Inheritance from the generalized Car class"

    abstract class Car<TEngine> where TEngine : Engine
    {
        public TEngine Engine;

        public abstract void ChangePart<TCarPart>(TCarPart newPart) where TCarPart : CarPart;
    }

    abstract class Engine
    {

    }

    class ElectricEngine : Engine
    {

    }

    class GasEngine : Engine
    {

    }

    abstract class CarPart
    {

    }

    class Battery : CarPart
    {

    }

    class Differential : CarPart
    {

    }

    class Wheel : CarPart
    {

    }

    class ElectricCar : Car <ElectricEngine>
    {
        public override void ChangePart<TCarPart>(TCarPart newPart)
        {

        }
    }

    class GasCar : Car<GasEngine>
    {
        public override void ChangePart<TCarPart>(TCarPart newPart)
        {

        }
    }



    #endregion

}
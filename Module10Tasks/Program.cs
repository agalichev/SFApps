namespace Module10Tasks
{
    internal class Program
    {
        static ILogger Logger { get; set; }

        static void Main(string[] args)
        {
            // Screencast unit 10.1 practice
            Logger = new Logger();
            var worker1 = new Worker1(Logger);

            worker1.Work();

            // Task 10.2.2
            Writer writer = new Writer();
            ((IWriter) writer).Write();

            // Task 10.2.3
            Worker worker = new Worker();
            worker.Build();

            // Task 10.2.4
            Worker2 worker2 = new Worker2();
            ((IWorker1)worker2).Build();

            // Task 10.3.1
            IWriter1 writer1 = new FileManager();
            IReader reader = new FileManager();
            IMailer mailer = new FileManager();

            writer1.Write1();
            reader.Read();
            mailer.SendEmail();

            // Task 10.4.4
            var account = new Account();
            IUpdater<Account> updater = new UserService();
            updater.Update(account);

            Console.ReadLine();
        }
    }

    // Screencast unit 10.1 practice
    public interface ILogger
    {
        void Error (string message);
        void Event (string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(message);    
        }

        public void Event(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IWorker
    {
        void Work();
    }

    // Task 10.1.4
    public interface IManager
    {
        void Create();
        void Read();
        void Update();
        void Delete();   
    }
    public class Manager : IManager
    {
        public void Create(){}

        public void Read(){}

        public void Update(){}

        public void Delete(){}
    }

    // Task 10.2.2
    public interface IWriter
    {
        void Write();
    }

    public class Writer : IWriter
    {
        void IWriter.Write(){}
    }

    // Task 10.2.3
    public interface IWorker1
    {
        public void Build();
    }

    public class Worker : IWorker1
    {
        public void Build(){}
    }

    // Task 10.2.4
    public class Worker2 : IWorker1
    {
        void IWorker1.Build(){}
    }

    // Task 10.3.1
    public interface IWriter1
    {
        void Write1();
    }

    public interface IReader
    {
        void Read();
    }

    public interface IMailer
    {
        void SendEmail();
    }

    public class FileManager : IWriter1, IReader, IMailer
    {
        void IWriter1.Write1()
        {
            Console.WriteLine("Записываем файл..");
        }

        void IReader.Read()
        {
            Console.WriteLine("Читаем фвйл..");
        }

        void IMailer.SendEmail()
        {
            Console.WriteLine("Отправляем сообщение..");
        }
    }

    // Task 10.3.2
    public interface ICreatable
    {
        void Create();
    }

    public interface IDeletable
    {
        void Delete();
    }

    public interface IUpdatable
    {
        void Update();
    }

    public class Entity : ICreatable, IDeletable, IUpdatable
    {
        public void Create()
        {
        }

        public void Delete()
        {
        }

        public void Update()
        {
        }
    }

    // Task 10.3.3
    public interface IBook
    {
        void Read();
    }

    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }

    public class ElectronicBook : IBook, IDevice
    {
        void IBook.Read()
        {
        }

        void IDevice.TurnOff()
        {
        }

        void IDevice.TurnOn()
        {
        }
    }

    // Task 10.4.4

    public class User{}
    public class Account : User{}
    public interface IUpdater<in T>
    {
       void Update(T entity);
    }

    public class UserService : IUpdater<User>
    {
        public void Update(User entity){}
    }
}
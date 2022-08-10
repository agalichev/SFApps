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
}
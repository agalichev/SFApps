using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10Tasks
{
    internal class Worker1 : IWorker
    {
        public ILogger Logger { get; }

        public Worker1(ILogger logger)
        {
            Logger = logger;    
        }

        public void Work()
        {
            Logger.Event("Worker1 начал свою работу!");
            Thread.Sleep(3000);
            Logger.Event("Worker1 закончил свою работу!");
        }
    }
}

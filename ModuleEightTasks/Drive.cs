using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleEightTasks
{   //Task 8.1.4
    internal class Drive
    {
        public string Name { get; }
        public double TotalSpace { get; }
        public double FreeSpace { get; }

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;

            void CreateFolder(string folderName)
            {
                Folders.Add(folderName ,new Folder());
            }
        }
    }
}

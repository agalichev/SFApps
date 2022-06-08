namespace ModuleEightTasks
{
   public class Program
   {
        public static void Main(string[] args)
        {

            #region DriveInfo using example
            // Получаем информацию о носителе

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                WriteDriveinfo(drive);
                DirectoryInfo root = drive.RootDirectory;
                var folders = root.GetDirectories();
                WriteFolderInfo(folders);
            }
            #endregion

            // Directory using example
            // Получаем все папки и файлы корневого каталога
            //GetCatalogs();

            //MoveToTrash();

            #region Task 8.3.1 Open and display Program.cs
            //string filepath = @"C:\Users\lexga\OneDrive\Documents\CDEV-14\SFApps\ModuleEightTasks\Program.cs";

            //using(StreamReader sr = File.OpenText(filepath))
            //{
            //    string str = "";
            //    while((str = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(str);
            //    }
            //}
            #endregion

            #region Example of creation temporary file

            //string tempfile = Path.GetTempFileName();
            //var fileInfo = new FileInfo(tempfile);

            //Console.WriteLine(fileInfo.FullName);

            #endregion

            #region Task 8.3.2 Last run time
            //var fileInfo = new FileInfo(@"C:\Users\lexga\OneDrive\Documents\CDEV-14\SFApps\ModuleEightTasks\Program.cs");

            //using (StreamWriter sw = fileInfo.AppendText())
            //{
            //    sw.WriteLine($"//Время запуска: {DateTime.Now}");
            //}

            //using (StreamReader sr = fileInfo.OpenText())
            //{
            //    string str = "";
            //    while ((str = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(str);
            //    }
            //}
            #endregion

            Console.WriteLine();

            //CountFoldersAndFiles(); // Метод подсчета количества папок и файлов в корневом каталоге

            //CreateNewDirectory(); // Пример создания каталога в папке текущего пользователя
        }

        internal static void GetCatalogs()
        {
            string dirName = "C:\\"; // Путь к корневой директории

            if (Directory.Exists(dirName)) // Проверяем, что директория существует
            {
                Console.WriteLine($" Папки:");

                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }

                Console.WriteLine();
                Console.WriteLine(" Файлы:");

                string[] files = Directory.GetFiles(dirName); // Получим все файлы корневого каталога

                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }

        static void CountFoldersAndFiles() // Task 8.2.1
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo("C:\\");

                if (dirInfo.Exists)
                {
                    Console.WriteLine($" Количество папок: {dirInfo.GetDirectories().Length}\n Количество файлов: {dirInfo.GetFiles().Length}");
                }

                DirectoryInfo newDirectory = new DirectoryInfo(@"C:\newDirectory"); // Task 8.2.2
                if (!newDirectory.Exists)
                {
                    newDirectory.Create();

                    Console.WriteLine($"Название каталога: {newDirectory.Name}");
                    Console.WriteLine($"Полное название каталога: {newDirectory.FullName}");
                    Console.WriteLine($"Время создания каталога: {newDirectory.CreationTime}");
                    Console.WriteLine($"Корневой каталог: {newDirectory.Root}");
                }

                Console.WriteLine($" Количество папок: {dirInfo.GetDirectories().Length}\n Количество файлов: {dirInfo.GetFiles().Length}");

                newDirectory.Delete(); // Task 8.2.3
                Console.WriteLine(" Каталог удалён!");

                Console.WriteLine($" Количество папок: {dirInfo.GetDirectories().Length}\n Количество файлов: {dirInfo.GetFiles().Length}");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CreateNewDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\lexga");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            dirInfo.CreateSubdirectory("NewFolder");
        }

        static void MoveToTrash() // Task 8.2.4
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\lexga\OneDrive\Рабочий стол\testFolder");
                string trashPath = @"C:\$Recycle.Bin\testFolder"; 

                dirInfo.MoveTo(trashPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #region Video practice 8.2.1, 8.3.1

        static void WriteDriveinfo(DriveInfo drive) 
        {      
            Console.WriteLine($" Название: {drive.Name}");
            Console.WriteLine($" Тип: {drive.DriveType}");
            
            if (drive.IsReady)
            {
                Console.WriteLine($" Объём: {drive.TotalSize} байт");
                Console.WriteLine($" Свободно: {drive.AvailableFreeSpace} байт");
                Console.WriteLine($" Метка: {drive.VolumeLabel}");
            }
        }

        static void WriteFolderInfo(DirectoryInfo[] folders) // Video Practice 8.2.1
        {
            Console.WriteLine();
            Console.WriteLine("Папки: ");
            Console.WriteLine();

            foreach(var folder in folders) 
            {
                try // Video Practice 8.3.1
                {
                    Console.WriteLine(folder.Name + $"- {DirectoryExtension.DirSize(folder)} байт");
                }
                catch(Exception e)
                {
                    Console.WriteLine(folder.Name + $"- Не удалось рассчитать размер: {e.Message}");
                }
            }
        }
        #endregion

    }
}//Время запуска: 07.06.2022 2:35:43
//Время запуска: 08.06.2022 12:49:11

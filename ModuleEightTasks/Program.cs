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
                Console.WriteLine($" Название: {drive.Name}");
                Console.WriteLine($" Тип: {drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($" Объём: {drive.TotalSize} байт");
                    Console.WriteLine($" Свободно: {drive.AvailableFreeSpace} байт");
                    Console.WriteLine($" Метка: {drive.VolumeLabel}");
                }
            }
            #endregion

            // Directory using example
            // Получаем все папки и файлы корневого каталога
            //GetCatalogs();

            MoveToTrash();

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

    }
}
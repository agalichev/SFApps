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
            GetCatalogs();

            Console.WriteLine();

            CountFoldersAndFiles();
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

        static void CountFoldersAndFiles()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo("C:\\");

                if (dirInfo.Exists)
                {
                    Console.WriteLine($" Количество папок: {dirInfo.GetDirectories().Length}\n Количество файлов: {dirInfo.GetFiles().Length}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
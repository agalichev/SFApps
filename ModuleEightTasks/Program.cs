using System.Runtime.Serialization.Formatters.Binary;

namespace ModuleEightTasks
{
   public class Program
   {
        public static FileInfo configFile = new FileInfo(@"SystemConfig.txt"); // Video practice 8.5.1 (см. ниже классы)
        public static void Main(string[] args)
        {
            #region DriveInfo using example
            // Получаем информацию о носителе

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                
                DirectoryInfo root = drive.RootDirectory;
                var folders = root.GetDirectories();

                Console.WriteLine($"Сканируем диск {drive.Name}");

                using(StreamWriter sw = configFile.AppendText())
                {
                    WriteDriveinfo(drive, sw);
                    WriteFolderInfo(folders, sw);
                }
                
                Console.WriteLine("Завершено");
                Console.WriteLine("_________");
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

            //string filePath = @"C:\Users\lexga\OneDrive\Рабочий стол\BinaryFile.bin";
            //WriteValues(filePath);
            //ReadValues(filePath);

            //Contact newContact = new Contact("Александр", 89242195386, "lex.galichev@gmail.com");
            //Console.WriteLine("Объект создан!");

            //BinaryFormatter formatter = new BinaryFormatter();
            //using(var fs = new FileStream("Contact.bin", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, newContact);
            //    Console.WriteLine("Объект сериализовван!");
            //}

            //using (var fs = new FileStream("Contact.bin", FileMode.OpenOrCreate))
            //{
            //    var newContact2 = (Contact)formatter.Deserialize(fs);
            //    Console.WriteLine("Объект десериализован!");
            //    Console.WriteLine($"Name: {newContact2.Name}, Phone: {newContact2.PhoneNumber}, E-Mail: {newContact2.Email}");
            //}
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

        #region Video practice 8.2.1, 8.3.1, 8.5.1

        static void WriteDriveinfo(DriveInfo drive, StreamWriter sw) 
        {      
            sw.WriteLine($" Название: {drive.Name}");
            sw.WriteLine($" Тип: {drive.DriveType}");
            
            if (drive.IsReady)
            {
                sw.WriteLine($" Объём: {drive.TotalSize} байт");
                sw.WriteLine($" Свободно: {drive.AvailableFreeSpace} байт");
                sw.WriteLine($" Метка: {drive.VolumeLabel}");
            }
        }

        static void WriteFolderInfo(DirectoryInfo[] folders, StreamWriter sw) // Video Practice 8.2.1
        {
            sw.WriteLine();
            sw.WriteLine("Папки: ");
            sw.WriteLine();

            foreach(var folder in folders) 
            {
                try // Video Practice 8.3.1
                {
                    sw.WriteLine(folder.Name + $"- {DirectoryExtension.DirSize(folder)} байт");
                }
                catch(Exception e)
                {
                    sw.WriteLine(folder.Name + $"- Не удалось рассчитать размер: {e.Message}");
                }
            }
        }
        #endregion

        static void ReadValues(string path)
        {
            //string dateTime;
            // string osType;
            string fileData;
            if (File.Exists(path))
            {
                using(BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    //dateTime = reader.ReadString();
                    //osType = reader.ReadString();
                    fileData = reader.ReadString();
                }

                //Console.WriteLine($"Дата и время: {dateTime}");
                //Console.WriteLine($"Операционная система: {osType}");
                Console.WriteLine(fileData);
            }
        }// Task 8.4.1
        static void WriteValues(string path) // Task 8.4.2
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write($" Файл изменен {DateTime.Now} на компьютере {Environment.OSVersion}");
            }
        }
        
        [Serializable]
        class Contact
        {
            public string Name { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }

            public Contact(string name, long phoneNumber, string email)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }
    }
}//Время запуска: 07.06.2022 2:35:43
//Время запуска: 08.06.2022 12:49:11

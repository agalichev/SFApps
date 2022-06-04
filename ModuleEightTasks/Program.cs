DriveInfo[] drives = DriveInfo.GetDrives();

foreach (DriveInfo drive in drives)
{
    Console.WriteLine($" Название: {drive.Name}");
    Console.WriteLine($" Тип: {drive.DriveType}");

    if(drive.IsReady)
    {
        Console.WriteLine($" Объём: {drive.TotalSize} байт");
        Console.WriteLine($" Свободно: {drive.AvailableFreeSpace} байт");
        Console.WriteLine($" Метка: {drive.VolumeLabel}");
    }
}

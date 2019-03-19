using System;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Parkway\Temp\MassPAY\Data\UploadedFiles";
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.FileName | NotifyFilters.Size;
            watcher.Filter = "*.*";

            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            while (Console.Read() != 'q');
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($" {e.OldFullPath} has been renamed to  {e.FullPath}");
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($" {e.Name} has been {e.ChangeType}");
        }
    }
}

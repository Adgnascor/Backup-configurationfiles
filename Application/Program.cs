using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using Application.src;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystem = new FileSystem();
            var initBackup = new InitializeBackup(fileSystem, null);

            if(!initBackup.FolderExists())
                 initBackup.CreateFolder();

            var paths = fileSystem.Directory.GetFiles(Environment.CurrentDirectory);


            for(var i = 0; i< paths.Length; i++)
                Console.WriteLine($"{i}. {paths[i]}");

            Console.Write("Backup: ");
            var fileIndex = Console.ReadLine();

            Console.Write("Name of application: ");
            var folderName = Console.ReadLine();
            var file = fileSystem.Path.GetFileName(paths[int.Parse(fileIndex)]);
            var backUp = new Backup(new ApplicationFolder(file , paths[int.Parse(fileIndex)] , folderName), fileSystem, initBackup);

            backUp.CreateApplicationFolder();
            backUp.CopyFile();
            backUp.SaveOriginalFilePath();

            Console.ReadKey();
        }
    }
}

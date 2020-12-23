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

            // TODO - Create method that returns a dict with filename and filepath
            var paths = fileSystem.Directory.GetFiles(Environment.CurrentDirectory);

            for(var i = 0; i< paths.Length; i++)
                Console.WriteLine($"{i}. {paths[i]}");

            var fileIndex = PromptUser("Backup: ");
            var folderName = PromptUser("Name of application: ");

            var file = fileSystem.Path.GetFileName(paths[int.Parse(fileIndex)]);
            var backUp = new Backup(new ApplicationFolder(file , paths[int.Parse(fileIndex)] , folderName), fileSystem, initBackup);


            var result = backUp.CreateApplicationFolder();
            Console.WriteLine($"Application folder created: {result.Exists}");

            backUp.CopyFile();
            // Console.WriteLine($"File copied: {copiedFile.Exists}");

            backUp.SaveOriginalFilePath();
            // Console.WriteLine($"Original filepath backed up: {backedUpPath.Exists}");

            Console.WriteLine($"File: {file} is backed up with foldername: {folderName}");
            Console.ReadKey();
        }

        private static string PromptUser(string question) 
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}

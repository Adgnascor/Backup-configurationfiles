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
            var pathsAndFilenames = new BackupTool()
            .DirectoryPathsAndFilenames(fileSystem, Environment.CurrentDirectory);

            foreach (var item in pathsAndFilenames)
            {
                Console.WriteLine($"Path: {item.Key} Name: {item.Value}");
            }

/*             var filePaths = fileSystem.Directory
            .GetFiles(Environment.CurrentDirectory);

            for(var i = 0; i< filePaths.Length; i++)
                Console.WriteLine($"{i}. {filePaths[i]}");

            var fileIndex = PromptUser("Backup: ");
            var folderName = PromptUser("Name of application: ");

            var file = fileSystem.Path
            .GetFileName(filePaths[int.Parse(fileIndex)]);

            var applicationToBackup= new ApplicationFolder(
                file , filePaths[int.Parse(fileIndex)] , folderName);

            var backUp = new Backup(fileSystem, initBackup);


            var result = backUp.CreateApplicationFolder(
                applicationToBackup.Name);

            Console.WriteLine($"Application folder created: {result.Exists}");

            backUp.CopyFile(applicationToBackup.FileName, applicationToBackup.Name);
            // Console.WriteLine($"File copied: {copiedFile.Exists}");

            backUp.SaveOriginalFilePath(applicationToBackup.FilePath, applicationToBackup.Name);
            // Console.WriteLine($"Original filepath backed up: {backedUpPath.Exists}");

            Console.WriteLine($"File: {file} is backed up with foldername: {folderName}"); */
            Console.ReadKey();
        }

        private static string PromptUser(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}

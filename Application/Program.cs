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

            IDirectoryInfo backupInitInfo = default;
            if(!InitializeBackup.FolderExists(fileSystem, null))
                backupInitInfo = InitializeBackup.CreateFolder(fileSystem, null);

            var pathsAndFilenames = BackupTool
            .DirectoryPathsAndFilenames(fileSystem, Environment.CurrentDirectory);

            for (int i = 0; i < pathsAndFilenames.Count; i++)
                Console.WriteLine($"{i}. {pathsAndFilenames.ElementAt(i).Key}");

            // TODO - Handle input from user
            var fileIndex = PromptUser("Backup: ");
            var folderName = PromptUser("Name of application: ");

            var applicationToBackup= new ApplicationFolder(
                pathsAndFilenames.ElementAt(int.Parse(fileIndex)).Key
                , pathsAndFilenames.ElementAt(int.Parse(fileIndex)).Value, folderName);

            var backUp = new Backup(fileSystem, backupInitInfo);

            var result = backUp.CreateApplicationFolder(
                applicationToBackup.Name);

            Console.WriteLine($"Application folder created: {result.Exists}");

            backUp.CopyFile(applicationToBackup.FileName, applicationToBackup.Name);
            // Console.WriteLine($"File copied: {copiedFile.Exists}");

            backUp.SaveOriginalFilePath(applicationToBackup.FilePath, applicationToBackup.Name);
            // Console.WriteLine($"Original filepath backed up: {backedUpPath.Exists}");

            Console.WriteLine($"File: {applicationToBackup.FileName} is backed up with foldername: {applicationToBackup.Name}");
            Console.ReadKey();
        }

        private static string PromptUser(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}

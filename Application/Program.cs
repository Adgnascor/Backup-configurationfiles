using System;
using System.IO;
using System.Linq;
using Application.src;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {

            // TODO - Refactor this statement and clean it up
            var rootOfApplication = InitializeBackup.RootOfApplication(null);
            if(!InitializeBackup.FolderExists(null))
                rootOfApplication = InitializeBackup.CreateFolder(null);

            var pathsAndFilenames = BackupTool
                .DirectoryPathsAndFilenames(Environment.CurrentDirectory);

            for (int i = 0; i < pathsAndFilenames.Count; i++)
                Console.WriteLine($"{i}. {pathsAndFilenames.ElementAt(i).Key}");

            // TODO - Handle input from user
            var fileIndex = PromptUser("Backup: ");
            var folderName = PromptUser("Name of application: ");

            var applicationToBackup= new ApplicationFolder(
                pathsAndFilenames.ElementAt(int.Parse(fileIndex)).Key
                , pathsAndFilenames.ElementAt(int.Parse(fileIndex)).Value, folderName);

            var backUp = new Backup(rootOfApplication);

            var result = backUp.CreateApplicationFolder(
                applicationToBackup.Name);

            Console.WriteLine($"Application folder created: {result.Exists}");

            backUp.CopyFile(applicationToBackup.FileName, applicationToBackup.Name);
            backUp.SaveOriginalFilePath(applicationToBackup.FilePath, applicationToBackup.Name);

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

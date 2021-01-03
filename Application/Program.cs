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

            var rootOfApplication = InitializeBackup.RootOfApplication(null);
            if(!InitializeBackup.FolderExists(null))
                rootOfApplication = InitializeBackup.CreateFolder(null);

            var filenamesWithPaths = BackupTool
                .GetFilenamesWithPaths(Environment.CurrentDirectory);

            for (int i = 0; i < filenamesWithPaths.Count; i++)
                Console.WriteLine($"{i}. {filenamesWithPaths.ElementAt(i).Key}");

            // TODO - Handle input from user
            var fileIndex = PromptUser("Pick file to save: ");
            var folderName = PromptUser("Name of application: ");

            var folderToBackup= new ApplicationFolder(
                filenamesWithPaths.ElementAt(int.Parse(fileIndex)).Key
                , filenamesWithPaths.ElementAt(int.Parse(fileIndex)).Value
                , folderName);

            var backUp = new Backup(rootOfApplication);

            var result = backUp.CreateApplicationFolder(
                folderToBackup.Name);

            Console.WriteLine($"Application folder created: {result.Exists}");

            backUp.CopyFile(folderToBackup.File, folderToBackup.Name);
            backUp.StoreOriginalFilePath(folderToBackup.FilePath, folderToBackup.Name);

            Console.WriteLine($"File: {folderToBackup.File} is backed up with foldername: {folderToBackup.Name}");
            Console.ReadKey();
        }

        private static string PromptUser(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}

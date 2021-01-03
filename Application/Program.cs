using System;
using System.Collections.Generic;
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
            if (!InitializeBackup.FolderExists(null))
                rootOfApplication = InitializeBackup.CreateFolder(null);

            var filenamesWithPaths = BackupTool
                .GetFilenamesWithPaths(Environment.CurrentDirectory);
            PrintFileNames(filenamesWithPaths);

            int fileIndex = ValidateUserInputOfPickedFile(filenamesWithPaths);
            var folderName = PromptUser("Name of application: ");

            var folderToBackup = new ApplicationFolder(
                filenamesWithPaths.ElementAt(fileIndex).Key
                , filenamesWithPaths.ElementAt(fileIndex).Value
                , folderName);

            var backUp = new Backup(rootOfApplication);
            var result = backUp.CreateApplicationFolder(folderToBackup.Name);

            backUp.CopyFile(folderToBackup.File, folderToBackup.Name);
            backUp.StoreOriginalFilePath(folderToBackup.FilePath, folderToBackup.Name);

            Console.WriteLine($"Files stored in: {folderToBackup.Name}\n");
            foreach(var file in result.GetFiles())
                Console.WriteLine($"- {file.Name}");

            Console.ReadKey();
        }

        private static int ValidateUserInputOfPickedFile(Dictionary<string, string> filenamesWithPaths)
        {
            int fileIndex;
            do
            {
                var userInput = PromptUser("Pick file to save: ");
                if (int.TryParse(userInput, out fileIndex) && fileIndex < filenamesWithPaths.Count)
                    break;

                Console.WriteLine(" Not a valid input");
            } while (true);
            return fileIndex;
        }

        private static void PrintFileNames(Dictionary<string, string> filenamesWithPaths)
        {
            for (int i = 0; i < filenamesWithPaths.Count; i++)
                Console.WriteLine($"{i}. {filenamesWithPaths.ElementAt(i).Key}");
        }

        private static string PromptUser(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}

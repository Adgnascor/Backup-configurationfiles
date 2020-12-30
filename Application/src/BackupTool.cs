using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace Application.src
{
    public class BackupTool
    {
        public BackupTool()
        {
        }

        public Dictionary<string, string> DirectoryPathsAndFilenames(IFileSystem fileSystem, string currentDirectory)
        {
            var filePaths = fileSystem.Directory.GetFiles(currentDirectory);
            string[] fileNames = default;

            return filePaths.ToDictionary(x=> fileSystem.Path.GetFileName(x));
        }
    }
}
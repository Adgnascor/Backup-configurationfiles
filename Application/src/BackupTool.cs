using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace Application.src
{
    public static class BackupTool
    {
        public static Dictionary<string, string> DirectoryPathsAndFilenames(IFileSystem fileSystem, string currentDirectory)
        {
            var filePaths = fileSystem.Directory.GetFiles(currentDirectory);
            return filePaths.ToDictionary(x=> fileSystem.Path.GetFileName(x));
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.src
{
    public static class BackupTool
    {
        public static Dictionary<string, string> DirectoryPathsAndFilenames(string currentDirectory)
        {
            var filePaths = Directory.GetFiles(currentDirectory);
            return filePaths.ToDictionary(x=> Path.GetFileName(x));
        }
    }
}

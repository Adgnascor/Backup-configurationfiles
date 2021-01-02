using System;
using System.IO.Abstractions;

namespace Application.src
{
    public static class InitializeBackup
    {
        private static readonly string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static bool FolderExists(IFileSystem fileSystem, string backupFolderPath)
        {
            backupFolderPath=  backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" ;
            return fileSystem.Directory.Exists(backupFolderPath);
        }
        public static IDirectoryInfo CreateFolder(IFileSystem fileSystem, string backupFolderPath)
        {
            backupFolderPath=  backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" ;
            return fileSystem.Directory.CreateDirectory(backupFolderPath);
        }

        public static IDirectoryInfo BackUpRootDirectory(IFileSystem fileSystem, string backupFolderPath)
        {
            backupFolderPath=  backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" ;
            return fileSystem.DirectoryInfo.FromDirectoryName(backupFolderPath);
        }
    }
}

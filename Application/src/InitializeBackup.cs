using System;
using System.IO.Abstractions;

namespace Application.src
{
    // TODO: Make class static
    public class InitializeBackup
    {
        private static readonly string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public string BackupFolderPath { get; private set; }
        private readonly IFileSystem _fileSystem;

        public InitializeBackup(IFileSystem fileSystem, string backupFolderPath)
        {
            _fileSystem =  fileSystem;
            BackupFolderPath=  backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" ;
        }

        public bool FolderExists()
            => _fileSystem.Directory.Exists(BackupFolderPath);

        public IDirectoryInfo CreateFolder()
            => _fileSystem.Directory.CreateDirectory(BackupFolderPath);
    }
}

using System;
using System.IO.Abstractions;

namespace Application.src
{
    public class InitializeBackup
    {
        private static readonly string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public string BackupFolderPath { get; private set; }= $@"{_appDataLocal}/backup-configurationfiles";
        private readonly IFileSystem _fileSystem;
        public InitializeBackup(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public bool FolderExists()
            => _fileSystem.Directory.Exists(BackupFolderPath);

        public IDirectoryInfo CreateFolder()
            => _fileSystem.Directory.CreateDirectory(BackupFolderPath);
    }
}

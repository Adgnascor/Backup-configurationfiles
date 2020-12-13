using System.IO;
using System.IO.Abstractions;

namespace Application.src
{
    public class Backup
    {
        private readonly ApplicationFolder _applicationFolder;
        private readonly IFileSystem _fileSystem;
        private readonly InitializeBackup _initializeBackup;

        public Backup(ApplicationFolder applicationFolder, IFileSystem fileSystem, InitializeBackup initializeBackup)
        {
            _fileSystem = fileSystem;
            _applicationFolder=applicationFolder;
            _initializeBackup = initializeBackup;
        }

        public IDirectoryInfo CreateApplicationFolder()
            => _fileSystem.Directory.CreateDirectory(Path.Combine(_initializeBackup.BackupFolderPath, _applicationFolder.Name));

        public void CopyFile()
            => _fileSystem.File.Copy(_applicationFolder.FilePath, Path.Combine(_initializeBackup.BackupFolderPath, _applicationFolder.Name,_applicationFolder.FileName),true);

        public void SaveOriginalFilePath()
            => File.WriteAllText(Path.Combine(_initializeBackup.BackupFolderPath,_applicationFolder.Name,"ConfigSourcePath.txt"),_applicationFolder.FilePath);
    }
}

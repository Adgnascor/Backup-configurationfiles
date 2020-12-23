using System.IO;
using System.IO.Abstractions;

namespace Application.src
{
    // TODO - Make class static
    public class Backup
    {
        private readonly IFileSystem _fileSystem;
        private readonly InitializeBackup _initializeBackup;

        public Backup(IFileSystem fileSystem, InitializeBackup initializeBackup)
        {
            _fileSystem = fileSystem;
            _initializeBackup = initializeBackup;
        }

        public IDirectoryInfo CreateApplicationFolder(string folderName)
            => _fileSystem.Directory.CreateDirectory(Path.Combine(_initializeBackup.BackupFolderPath, folderName));

        // TODO: Make method returning some kind of status report
        public void CopyFile(string srcFile, string destFoldername)
            => _fileSystem.File.Copy(srcFile, Path.Combine(_initializeBackup.BackupFolderPath, destFoldername, srcFile),true);


        // TODO: Make method returning some kind of status report
        public void SaveOriginalFilePath(string srcFilePath, string destFoldername)
            => File.WriteAllText(Path.Combine(_initializeBackup.BackupFolderPath,destFoldername,"ConfigSourcePath.txt"), srcFilePath);
    }
}

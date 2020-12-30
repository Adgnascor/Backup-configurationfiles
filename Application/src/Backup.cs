using System.IO;
using System.IO.Abstractions;

namespace Application.src
{
    public class Backup
    {
        private readonly IFileSystem _fileSystem;
        private readonly IDirectoryInfo _initializeBackup;

        public Backup(IFileSystem fileSystem, IDirectoryInfo initializeBackup)
        {
            _fileSystem = fileSystem;
            _initializeBackup = initializeBackup;
        }

        public IDirectoryInfo CreateApplicationFolder(string folderName)
            => _fileSystem.Directory.CreateDirectory(Path.Combine(_initializeBackup.FullName, folderName));

        // TODO: Make method returning some kind of status report
        public void CopyFile(string srcFile, string destFoldername)
            => _fileSystem.File.Copy(srcFile, Path.Combine(_initializeBackup.FullName, destFoldername, srcFile),true);


        // TODO: Make method returning some kind of status report
        public void SaveOriginalFilePath(string srcFilePath, string destFoldername)
            => File.WriteAllText(Path.Combine(_initializeBackup.FullName,destFoldername,"ConfigSourcePath.txt"), srcFilePath);
    }
}

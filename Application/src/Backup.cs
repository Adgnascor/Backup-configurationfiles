using System.IO;

namespace Application.src
{
    public class Backup
    {
        private readonly DirectoryInfo _initializeBackup;

        public Backup(DirectoryInfo initializeBackup)
        {
            _initializeBackup = initializeBackup;
        }

        public DirectoryInfo CreateApplicationFolder(string folderName)
            => Directory.CreateDirectory(Path.Combine(_initializeBackup.FullName, folderName));

        // TODO: Make method returning some kind of status report
        public void CopyFile(string srcFile, string destFoldername)
            => File.Copy(srcFile, Path.Combine(_initializeBackup.FullName, destFoldername, srcFile),true);

        // TODO: Make method returning some kind of status report
        public void StoreOriginalFilePath(string srcFilePath, string destFoldername)
            => File.WriteAllText(Path.Combine(_initializeBackup.FullName,destFoldername,"ConfigSourcePath.txt"), srcFilePath);
    }
}

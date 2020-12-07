using System;
using System.IO;
// TODO Make use of System.IO.Abstraction

namespace Application.src
{
    public class Backup
    {
        // TODO Create class Initialize as static
        // TODO Move to Initialize
        private static readonly string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string _backupRootPath = $@"{_appDataLocal}/backup-configurationfiles";
        //
        
        private readonly string _backupFolderPath;
        private readonly string _backupFilePath;


        // TODO Rename to ApplicationFolder _applicationFolder
        private readonly BackupSource _backupSource;

        // TODO Implement IFileSystem as private readonly property and class Initialize
        public Backup(BackupSource backupSource)
        {

            // TODO Remove from constructor and set them in methods below
            _backupFolderPath= Path.Combine(_backupRootPath,backupSource.ApplicationName);
            _backupFilePath= Path.Combine(_backupFolderPath, backupSource.ConfigFile);
            //
            
            _backupSource=backupSource;
        }

        // TODO Move method to Initialize, rename to BackupFolderExists
        public bool BackupRootFolderExist()
            => Directory.Exists(_backupRootPath);

        // TODO Move metod to Initialize, rename to CreateBackupFolder
        public DirectoryInfo CreateBackupRoot()
            => Directory.CreateDirectory(_backupRootPath);

        // TODO Rename to CreateApplicationFolder
        public DirectoryInfo CreateApplicationBackupFolder()
            => Directory.CreateDirectory(_backupFolderPath);

        // TODO Rename to File()
        public void CopyFileToBackup()
            => File.Copy(_backupSource.FilePath, _backupFilePath, true);

        // TODO Rename to SaveOriginalFilePath
        public void StoreSrcPathAsTXTFile()
            => File.WriteAllText(Path.Combine(_backupFolderPath,"ConfigSourcePath.txt"),_backupSource.FilePath);
    }
}

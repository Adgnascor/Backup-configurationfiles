using System.IO;

namespace Application.src
{
    public class Backup
    {
        private BackupSource _backupSource;
        private BackupDestination _backupDestination;

        public Backup(BackupSource backupSource, BackupDestination backupDestination)
        {
            _backupSource= backupSource;
            _backupDestination= backupDestination;
        }

        public bool BackupRootFolderExist()
            => Directory.Exists(_backupDestination.RootPath);

        public void CreateBackupRootFolder()
            => Directory.CreateDirectory(_backupDestination.RootPath);

        private string _applicationBackupRootPath
            => Path.Combine(_backupDestination.RootPath,_backupSource.ApplicationName);

        private bool ApplicationBackupFolderExists()
            => Directory.Exists(_applicationBackupRootPath);

        private void CreateApplicationBackupFolder()
            => Directory.CreateDirectory(_applicationBackupRootPath);

        private bool FilesToBackupExists()
            => File.Exists(Path.Combine(_applicationBackupRootPath, _backupSource.ConfigurationFile));

        public void BackupApplicationFile()
        {
            if(!ApplicationBackupFolderExists())
                CreateApplicationBackupFolder();
            if(!FilesToBackupExists())
                File.Copy(_backupSource.ConfigurationFilePath,_applicationBackupRootPath+_backupSource.ConfigurationFile);
        }
    }
}

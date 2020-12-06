using System.IO;

namespace Application.src
{
    public class Backup
    {
        private const string BackupRootPath = @"$HOME/AppData/Local/Backup-configurationfiles/";
        private string _backupFolderPath;
        private string _backupFilePath;
        private BackupSource _backupSource;


        public Backup(BackupSource backupSource)
        {
            _backupFolderPath= Path.Combine(BackupRootPath,backupSource.ApplicationName);
            _backupFilePath= Path.Combine(_backupFolderPath, backupSource.File);
            _backupSource=backupSource;
        }

        public bool BackupRootFolderExist()
            => Directory.Exists(BackupRootPath);

        public void CreateBackupRoot()
            => Directory.CreateDirectory(BackupRootPath);

        public void CreateApplicationBackupFolder()
            => Directory.CreateDirectory(_backupFolderPath);

        public void CopyFileToBackup()
            => File.Copy(_backupSource.FilePath, _backupFilePath);

        public void StoreSrcPathAsTXTFile()
            => File.WriteAllText(_backupFolderPath,$@"{_backupFolderPath}/SourcePath.txt");
    }
}

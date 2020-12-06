using System;
using System.IO;

namespace Application.src
{
    public class Backup
    {
        private static readonly string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string _backupRootPath = $@"{_appDataLocal}/backup-configurationfiles";
        private readonly string _backupFolderPath;
        private readonly string _backupFilePath;
        private readonly BackupSource _backupSource;


        public Backup(BackupSource backupSource)
        {
            _backupFolderPath= Path.Combine(_backupRootPath,backupSource.ApplicationName);
            _backupFilePath= Path.Combine(_backupFolderPath, backupSource.ConfigFile);
            _backupSource=backupSource;
        }

        public bool BackupRootFolderExist()
            => Directory.Exists(_backupRootPath);

        public DirectoryInfo CreateBackupRoot()
            => Directory.CreateDirectory(_backupRootPath);


        public DirectoryInfo CreateApplicationBackupFolder()
            => Directory.CreateDirectory(_backupFolderPath);

        public void CopyFileToBackup()
            => File.Copy(_backupSource.FilePath, _backupFilePath);

        // TODO use _backupSource.FilePath as content
        public void StoreSrcPathAsTXTFile()
            => File.WriteAllText(_backupFolderPath,$@"{_backupFolderPath}/SourcePath.txt");
    }
}

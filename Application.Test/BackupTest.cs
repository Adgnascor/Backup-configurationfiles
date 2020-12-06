using Application.src;
using System.IO;
using Xunit;

namespace Application.Test
{
    public class BackupTest
    {
        private readonly BackupSource _backupSource = new BackupSource(
            "init.vim",
            @"C:/Users/willi/dev/GitGub/Backup-configurationfiles/Application.Test/MockSourceApplicationsFolder/nvim/init.vim",
            "nvim"
            );

        [Fact]
        public void BackupRootFolderExist_RootFolderExists()
        {
            // Arrange
            var backup = new Backup(_backupSource);
            // Act
            var exists = backup.BackupRootFolderExist();
            // Assert
            Assert.True(exists);
        }


        [Fact]
        public void CreateBackupRoot_Success()
        {
            // Arrange
            var backup = new Backup(_backupSource);
            // Act
            var folderInfo= backup.CreateBackupRoot();
            // Assert
            Assert.True(folderInfo.Exists);
        }


        [Fact]
        public void CreateApplicationBackupFolder_Success()
        {
            // Arrange
            var backup = new Backup(_backupSource);
            // Act
            var folderInfo= backup.CreateApplicationBackupFolder();
            // Assert
            Assert.True(folderInfo.Exists);
        }

        [Fact]
        public void CopyFileToBackup_Success()
        {
            // Arrange
            var backup = new Backup(_backupSource);
            backup.CopyFileToBackup();
            // Act
            var fileExists = File.Exists(Path.Combine(_backupSource.FilePath));

            // Assert
            Assert.True(fileExists);
        }

    }


}

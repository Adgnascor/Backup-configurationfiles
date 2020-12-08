using Application.src;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using Xunit;

namespace Application.Test
{
    // TODO Rewrite and make use of MockFileSystem
    public class BackupTest
    {
        private readonly ApplicationFolder _applicationFolder = new ApplicationFolder(
            "init.vim",
            @"C:/Users/willi/dev/GitGub/Backup-configurationfiles/Application.Test/MockSourceApplicationsFolder/nvim/init.vim",
            "nvim"
            );

        private readonly MockFileSystem _mockFileSystem;
        private readonly InitializeBackup _initializeBackup; 
        public BackupTest()
        {
            _mockFileSystem= new MockFileSystem();
            _initializeBackup= new InitializeBackup(_mockFileSystem);
        }


        // TODO Move to InitializeBackupTest
        [Fact]
        public void BackupRootFolderExist_RootFolderExists()
        {
            // Act
            var exists= _initializeBackup.FolderExists();
            // Assert
            Assert.True(exists);
        }


        // TODO Move to InitializeBackupTest
        [Fact]
        public void CreateBackupRoot_Success()
        {
            // Act
            var folderInfo= _initializeBackup.CreateFolder();
            // Assert
            Assert.True(folderInfo.Exists);
        }


        [Fact]
        public void CreateApplicationBackupFolder_Success()
        {
            // Arrange
            var backup = new Backup(_applicationFolder, _mockFileSystem, _initializeBackup);
            // Act
            var folderInfo= backup.CreateApplicationFolder();
            // Assert
            Assert.True(folderInfo.Exists);
        }

        // TODO Finish up
        [Fact]
        public void CopyFileToBackup_Success()
        {
            // Arrange
            var backup = new Backup(_applicationFolder, _mockFileSystem, _initializeBackup);
            backup.CopyFile();
            // Act
            var fileExists = _mockFileSystem.File.Exists(Path.Combine(_initializeBackup.BackupFolderPath,_applicationFolder.Name,_applicationFolder.FileName));
            // Assert
            Assert.True(fileExists);
        }

        // TODO Finish up
        [Fact]
        public void SaveOriginalFilePath_Success()
        {
            // Arrange
            var backup = new Backup(_applicationFolder, _mockFileSystem, _initializeBackup);
            backup.SaveOriginalFilePath();
            // Act

            var fileExist = _mockFileSystem.File.Exists(Path.Combine(_initializeBackup.BackupFolderPath,_applicationFolder.Name,"ConfigSourcePath.txt"));
            // Assert
            Assert.True(fileExist);
        }
    }
}

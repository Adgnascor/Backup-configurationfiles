using Application.src;
using System.IO;
using Xunit;
using System.IO.Abstractions;

namespace Application.Test
{
    public class BackupTest
    {
        // Arrange
        private static readonly ApplicationFolder _applicationFolder = new ApplicationFolder(
            "init.vim",
            @"C:\Users\willi\dev\GitGub\Backup-configurationfiles\Application.Test\TestResources\MockSourceApplicationsFolder\nvim\init.vim",
            "nvim"
            );

        private static readonly IFileSystem _fileSystem = new FileSystem();
        private static readonly InitializeBackup _initializeBackup = new InitializeBackup(_fileSystem, @"./TestResources/MockBackupFolder");
        private readonly Backup _backup = new Backup(_applicationFolder, _fileSystem, _initializeBackup);
        
        [Fact]
        public void CreateApplicationBackupFolder_Success()
        {
            // Act
            var folderInfo= _backup.CreateApplicationFolder();
            // Assert
            Assert.True(folderInfo.Exists);
        }

        [Fact]
        public void CopyFileToBackup_Success()
        {
            _backup.CopyFile();
            // Act
            var fileExists = _fileSystem.File.Exists(Path.Combine(_initializeBackup.BackupFolderPath,_applicationFolder.Name,_applicationFolder.FileName));
            // Assert
            Assert.True(fileExists);
        }

        [Fact]
        public void SaveOriginalFilePath_Success()
        {
            _backup.SaveOriginalFilePath();
            // Act
            var fileExist = _fileSystem.File.Exists(Path.Combine(_initializeBackup.BackupFolderPath,_applicationFolder.Name,"ConfigSourcePath.txt"));
            // Assert
            Assert.True(fileExist);
        }
    }
}

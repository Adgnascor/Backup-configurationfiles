using Application.src;
using Xunit;
using System.IO.Abstractions;

namespace Application.Test
{
    public class InitializeBackupTest
    {
        // Arrange
        private static readonly IFileSystem _fileSystem = new FileSystem();
        private readonly InitializeBackup _initializeBackup 
            = new InitializeBackup(_fileSystem, @"./TestResources/MockBackupFolder/");

        [Fact]
        public void BackupRootFolderExist_RootFolderExists()
        {
            // Act
            var exists= _initializeBackup.FolderExists();
            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void CreateBackupRoot_Success()
        {
            // Act
            var folderInfo= _initializeBackup.CreateFolder();
            // Assert
            Assert.True(folderInfo.Exists);
        }
    }
}

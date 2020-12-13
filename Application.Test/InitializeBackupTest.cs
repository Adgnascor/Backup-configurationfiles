using Application.src;
using Xunit;
using System.IO.Abstractions.TestingHelpers;

namespace Application.Test
{
    public class InitializeBackupTest
    {
        // Arrange
        private static readonly MockFileSystem _fileSystem = new MockFileSystem();
        private readonly InitializeBackup _initializeBackup 
            = new InitializeBackup(_fileSystem, @"./TestResources/MockBackupFolder/");

        [Fact]
        public void BackupRootFolderExist_RootFolderExists()
        {
            // Act
            var exists= _initializeBackup.FolderExists();
            // Assert
            Assert.False(exists);
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

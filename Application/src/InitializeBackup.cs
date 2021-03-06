﻿using System;
using System.IO;
namespace Application.src
{
    public static class InitializeBackup
    {
        private static readonly string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static bool FolderExists(  string backupFolderPath)
        {
            backupFolderPath=  backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" ;
            return Directory.Exists(backupFolderPath);
        }
        public static DirectoryInfo CreateFolder(string backupFolderPath)
        {
            backupFolderPath=  backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" ;
            return Directory.CreateDirectory(backupFolderPath);
        }

        public static DirectoryInfo RootOfApplication(string backupFolderPath)
        {
            return new DirectoryInfo(backupFolderPath?? $@"{_appDataLocal}/backup-configurationfiles" );
        }
    }
}

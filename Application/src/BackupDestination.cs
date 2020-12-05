namespace Application.src
{
    public class BackupDestination
    {
        private const string BackupRootPath = @"$HOME/AppData/Local/Backup-configurationfiles/";
        public string RootPath => BackupRootPath;
    }
}

namespace Application.src
{
    // TODO Rename to ApplicationFolder
    public class BackupSource
    {
        // TODO Change all fields to private set
        // TODO Rename to Name
        public string ApplicationName { get; set; }

        // TODO Rename to FileName
        public string ConfigFile { get; set; }

        public string FilePath { get; set; }

        public BackupSource(string ConfigFile,string FilePath,string ApplicationName)
        {
            this.ConfigFile = ConfigFile;
            this.FilePath = FilePath;
            this.ApplicationName = ApplicationName;
        }
    }
}

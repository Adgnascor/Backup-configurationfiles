namespace Application.src
{
    public class BackupSource
    {
        public string ConfigFile { get; set; }
        public string FilePath { get; set; }
        public string ApplicationName { get; set; }

        public BackupSource(string ConfigFile,string FilePath,string ApplicationName)
        {
            this.ConfigFile = ConfigFile;
            this.FilePath = FilePath;
            this.ApplicationName = ApplicationName;
        }

        // TODO Create method for SetConfigFile

        // TODO Create method for SetFilePath

        // TODO Possible to get application root folder name? And set it as ApplicationName
    }
}

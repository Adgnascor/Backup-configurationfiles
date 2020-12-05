namespace Application.src
{
    public class BackupSource
    {
        public string ConfigurationFile { get; set; }
        public string ConfigurationFilePath { get; set; }
        public string ApplicationName { get; set; }

        public BackupSource(string ConfigurationFile,string ConfigurationFilePath,string ApplicationName)
        {
            this.ConfigurationFile = ConfigurationFile;
            this.ConfigurationFilePath = ConfigurationFilePath;
            this.ApplicationName = ApplicationName;
        }
    }
}

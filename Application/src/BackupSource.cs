namespace Application.src
{
    public class BackupSource
    {
        public string File { get; set; }
        public string FilePath { get; set; }
        public string ApplicationName { get; set; }

        public BackupSource(string File,string FilePath,string ApplicationName)
        {
            this.File = File;
            this.FilePath = FilePath;
            this.ApplicationName = ApplicationName;
        }
    }
}

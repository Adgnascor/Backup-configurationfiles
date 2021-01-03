namespace Application.src
{
    public class ApplicationFolder
    {
        public string Name { get; private set; }

        public string File { get; private set; }

        public string FilePath { get; private set; }

        public ApplicationFolder(string FileName,string FilePath,string FolderName)
        {
            this.File = FileName;
            this.FilePath = FilePath;
            this.Name = FolderName;
        }
    }
}

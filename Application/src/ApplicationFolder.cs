namespace Application.src
{
    public class ApplicationFolder
    {
        public string Name { get; private set; }

        public string FileName { get; private set; }

        public string FilePath { get; private set; }

        public ApplicationFolder(string FileName,string FilePath,string Name)
        {
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.Name = Name;
        }
    }
}

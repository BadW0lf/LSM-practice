using System.IO;

namespace DataLayer.Utilities
{
    public class File : IFile
    {
        public File(string path)
        {
        }

        public Stream GetStream()
        {
            throw new System.NotImplementedException();
        }
    }
}
namespace FourFlagsRPG.Models.IO
{
    using Contracts.IO;
    using System.IO;

    public class FileReader : IFileReader
    {
        public string ReadToEnd(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
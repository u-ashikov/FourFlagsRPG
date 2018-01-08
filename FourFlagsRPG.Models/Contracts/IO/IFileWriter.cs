namespace FourFlagsRPG.Models.Contracts.IO
{
    public interface IFileWriter
    {
        void Write(string content, string directory, string fileName);
    }
}

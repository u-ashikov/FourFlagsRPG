namespace FourFlagsRPG.Models.Contracts.IO
{
    public interface IFileReader
    {
        string ReadToEnd(string path);
    }
}

namespace FourFlagsRPG.Models.Contracts.IO
{
    public interface IReader
    {
        string ReadLine();

        char ReadKey();
    }
}
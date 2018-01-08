namespace FourFlagsRPG.Models.Models.IO
{
    using Contracts.IO;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
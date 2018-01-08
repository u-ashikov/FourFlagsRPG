namespace FourFlagsRPG.Core
{
    using Models.Contracts.Engine;
    using Models.Contracts.IO;
    using Models.Models.IO;

    public class StartUp
    {
        public static void Main()
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
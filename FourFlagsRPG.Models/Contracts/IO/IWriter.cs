namespace FourFlagsRPG.Models.Contracts.IO
{
    public interface IWriter
    {
        void Write(string input);

        void WriteLine(string input);

        void UpdateStats(string name, string heroType, int health, int strength, int dexterity, int damage, int defence, int level, int experience, string hand, string head, string chest, string glove, string feet);

        void Clear();

        void GameOver();
    }
}
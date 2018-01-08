namespace FourFlagsRPG.Models.Models.Enemies
{
    using Contracts.Enemies;

    public class Goblin : Enemy, IEnemy
    {
        public Goblin(int id)
            : base(id) {}
    }
}
namespace FourFlagsRPG.Models.Models.Enemies
{
    using Contracts.Enemies;

    public class Vampire : Enemy, IEnemy
    {
        public Vampire(int id)
            : base(id) {}
    }
}
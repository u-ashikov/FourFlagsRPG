namespace FourFlagsRPG.Models.Models.Enemies
{
    using Contracts.Enemies;

    public class Orc : Enemy, IEnemy
    {
        public Orc(int id)
            : base(id) {}
    }
}
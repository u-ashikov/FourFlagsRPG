namespace FourFlagsRPG.Models.Models.Enemies
{
    using Contracts.Enemies;

    public class BloodElf : Enemy, IEnemy
    {
        public BloodElf(int id)
            : base(id) {}
    }
}
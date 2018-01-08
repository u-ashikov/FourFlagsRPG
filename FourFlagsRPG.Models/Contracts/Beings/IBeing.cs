namespace FourFlagsRPG.Models.Contracts.Beings
{
    public interface IBeing : IAttackable, IVulnerable
    {
        int Damage { get; }

        int Defence { get; }

        int Health { get; }
    }
}
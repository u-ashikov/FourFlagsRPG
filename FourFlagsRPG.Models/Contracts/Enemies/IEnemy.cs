namespace FourFlagsRPG.Models.Contracts.Enemies
{
    using Beings;

    public interface IEnemy : IBeing
    {
        int Id { get; }
    }
}
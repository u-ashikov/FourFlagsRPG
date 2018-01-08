namespace FourFlagsRPG.Models.Contracts.Heroes
{
    using Beings;
    using Items;

    public interface IHero : IBeing, ICollectable, IHealable
    {
        string Name { get; }

        string Description { get; }

        int Experience { get; }

        int Level { get; }

        int Strength { get; }

        int Dexterity { get; }

        IInventory Inventory { get; }

        string ShowStats();
    }
}
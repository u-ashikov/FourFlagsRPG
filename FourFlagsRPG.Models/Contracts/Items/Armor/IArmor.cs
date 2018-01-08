namespace FourFlagsRPG.Models.Contracts.Items
{
    using Enums;

    public interface IArmor : IItem
    {
        int DefenceBonus { get; }

        ArmorType ArmorType { get; }

        int GetAttackBonus();
    }
}
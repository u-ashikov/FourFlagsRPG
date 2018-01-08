namespace FourFlagsRPG.Models.Contracts.Items
{
    public interface IWeapon : IItem
    {
        int StrengthBonus { get; }

        int DamageBonus { get; }

        int GetAttackBonus();
    }
}
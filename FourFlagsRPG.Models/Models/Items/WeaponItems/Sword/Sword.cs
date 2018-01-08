namespace FourFlagsRPG.Models.Models.Items.WeaponItems.Sword
{
    public class Sword : Weapon
    {
        private const int DamageBonusPoints = 10;
        private const int StrengthBonusPoints = 3;
        private const string SwordName = "Simple Sword";

        public Sword(int id)
            : base(id, SwordName, DamageBonusPoints, StrengthBonusPoints) { }
    }
}
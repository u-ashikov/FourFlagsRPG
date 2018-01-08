namespace FourFlagsRPG.Models.Models.Items.WeaponItems.Sword
{
    public class LongSword : Weapon
    {
        private const int DamageBonusPoints = 17;
        private const int StrengthBonusPoints = 11;
        private const string SwordName = "Long Orcs Sword";

        public LongSword(int id)
            : base(id, SwordName, DamageBonusPoints, StrengthBonusPoints)
        {
        }
    }
}
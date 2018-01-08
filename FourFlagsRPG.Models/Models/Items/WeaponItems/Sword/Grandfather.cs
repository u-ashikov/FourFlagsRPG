namespace FourFlagsRPG.Models.Models.Items.WeaponItems.Sword
{
    public class Grandfather : Weapon
    {
        private const int DamageBonusPoints = 30;
        private const int StrengthBonusPoints = 20;
        private const string SwordName = "The Grandfather Sword";

        public Grandfather(int id)
            : base(id, SwordName, DamageBonusPoints, StrengthBonusPoints)
        {
        }
    }
}
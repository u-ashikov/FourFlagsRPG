namespace FourFlagsRPG.Models.Models.Items.WeaponItems
{
    public class AxeOfWrath : Weapon
    {
        private const int DamageBonusPoints = 15;
        private const int StrengthBonusPoints = 10;
        private const string AxeName = "Axe of Wrath";

        public AxeOfWrath(int id)
            : base(id, AxeName, DamageBonusPoints, StrengthBonusPoints) { }
    }
}
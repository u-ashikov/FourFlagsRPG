namespace FourFlagsRPG.Models.Models.Items.WeaponItems.Axes
{
    public class JourneymanBattleAxe : Weapon
    {
        private const int DamageBonusPoints = 21;
        private const int StrengthBonusPoints = 10;
        private const string AxeName = "Journeyman Battle Axe";

        public JourneymanBattleAxe(int id)
            : base(id, AxeName, DamageBonusPoints, StrengthBonusPoints)
        {
        }
    }
}
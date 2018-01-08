namespace FourFlagsRPG.Models.Models.Items.ArmorItems.FeetTypeItems
{
    using Enums;

    public class Gauntlets : ArmorItem
    {
        private const int DefenceBonusPoints = 17;
        private const string FeetArmorName = "Gauntlets";

        public Gauntlets(int id)
            : base(id, FeetArmorName, DefenceBonusPoints, ArmorType.Feet)
        {
        }
    }
}
namespace FourFlagsRPG.Models.Models.Items.ArmorItems.GlovesTypeItems
{
    using Enums;

    public class Baldric : ArmorItem
    {
        private const int DefenceBonusPoints = 13;
        private const string GlovesArmorName = "Baldric";

        public Baldric(int id)
            : base(id, GlovesArmorName, DefenceBonusPoints, ArmorType.Gloves)
        {
        }
    }
}
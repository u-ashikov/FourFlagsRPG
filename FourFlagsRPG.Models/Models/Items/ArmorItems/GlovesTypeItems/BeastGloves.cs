namespace FourFlagsRPG.Models.Models.Items.ArmorItems.GlovesTypeItems
{
    using Enums;

    public class BeastGloves : ArmorItem
    {
        private const int DefenceBonusPoints = 21;
        private const string GlovesArmorName = "Beast gloves";

        public BeastGloves(int id)
            : base(id, GlovesArmorName, DefenceBonusPoints, ArmorType.Gloves)
        {
        }
    }
}
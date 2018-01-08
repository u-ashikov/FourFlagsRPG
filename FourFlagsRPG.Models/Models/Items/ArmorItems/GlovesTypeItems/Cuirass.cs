namespace FourFlagsRPG.Models.Models.Items.ArmorItems.GlovesTypeItems
{
    using Enums;

    public class Cuirass : ArmorItem
    {
        private const int DefenceBonusPoints = 17;
        private const string GlovesArmorName = "Cirass";

        public Cuirass(int id)
            : base(id, GlovesArmorName, DefenceBonusPoints, ArmorType.Gloves)
        {
        }
    }
}
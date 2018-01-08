namespace FourFlagsRPG.Models.Models.Items.ArmorItems
{
    using Enums;

    public class VenomWardBreastPlate : ArmorItem
    {
        private const int DefenceBonusPoints = 34;
        private const string ChestArmorName = "Venom Ward Breast Plate";

        public VenomWardBreastPlate(int id)
            : base(id, ChestArmorName, DefenceBonusPoints, ArmorType.Chest)
        {
        }
    }
}
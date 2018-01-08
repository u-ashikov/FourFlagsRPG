namespace FourFlagsRPG.Models.Models.Items.ArmorItems
{
    using Enums;

    public class HardLeatherArmor : ArmorItem
    {
        private const int DefenceBonusPoints = 22;
        private const string ChestArmorName = "Hard Leather Armor";

        public HardLeatherArmor(int id)
            : base(id, ChestArmorName, DefenceBonusPoints, ArmorType.Chest) { }
    }
}
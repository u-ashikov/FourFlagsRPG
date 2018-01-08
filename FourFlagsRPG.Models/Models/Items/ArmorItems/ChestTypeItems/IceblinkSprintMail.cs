namespace FourFlagsRPG.Models.Models.Items.ArmorItems
{
    using Enums;

    public class IceblinkSprintMail : ArmorItem
    {
        private const int DefenceBonusPoints = 49;
        private const string ChestArmorName = "Iceblink Sprint Mail Armor";

        public IceblinkSprintMail(int id)
            : base(id, ChestArmorName, DefenceBonusPoints, ArmorType.Chest)
        {
        }
    }
}
namespace FourFlagsRPG.Models.Models.Items.ArmorItems.HeadTypeItems
{
    using Enums;

    public class WideBrimmedHat : ArmorItem
    {
        private const int DefenceBonusPoints = 5;
        private const string HeadArmorName = "Wide-brimmed Hat";

        public WideBrimmedHat(int id)
            : base(id, HeadArmorName, DefenceBonusPoints, ArmorType.Head)
        {
        }
    }
}
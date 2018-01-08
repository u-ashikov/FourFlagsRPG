namespace FourFlagsRPG.Models.Models.Items.ArmorItems.HeadTypeItems
{
    using Enums;

    public class MonmouthCap : ArmorItem
    {
        private const int DefenceBonusPoints = 10;
        private const string HeadArmorName = "MonmouthCap";

        public MonmouthCap(int id)
            : base(id, HeadArmorName, DefenceBonusPoints, ArmorType.Head)
        {
        }
    }
}
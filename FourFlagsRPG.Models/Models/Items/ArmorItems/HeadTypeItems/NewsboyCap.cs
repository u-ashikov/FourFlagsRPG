namespace FourFlagsRPG.Models.Models.Items.ArmorItems.HeadTypeItems
{
    using Enums;

    public class NewsboyCap : ArmorItem
    {
        private const int DefenceBonusPoints = 10;
        private const string HeadArmorName = "Newsboy cap";

        public NewsboyCap(int id)
            : base(id, HeadArmorName, DefenceBonusPoints, ArmorType.Head)
        {
        }
    }
}
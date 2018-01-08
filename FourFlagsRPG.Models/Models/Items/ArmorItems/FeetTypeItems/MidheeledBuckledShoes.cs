namespace FourFlagsRPG.Models.Models.Items.ArmorItems.FeetTypeItems
{
    using Enums;

    public class MidheeledBuckledShoes : ArmorItem
    {
        private const int DefenceBonusPoints = 13;
        private const string FeetArmorName = "Mid-heeled buckled shoes";

        public MidheeledBuckledShoes(int id)
            : base(id, FeetArmorName, DefenceBonusPoints, ArmorType.Feet)
        {
        }
    }
}
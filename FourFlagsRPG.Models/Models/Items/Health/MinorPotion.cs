namespace FourFlagsRPG.Models.Models.Items
{
    public class MinorPotion : HealthPotion
    {
        private const int HealthPoints = 30;
        private const string PotionName = "Minor Healing Potion";

        public MinorPotion(int id)
             : base(id, PotionName, HealthPoints)
        {
        }
    }
}
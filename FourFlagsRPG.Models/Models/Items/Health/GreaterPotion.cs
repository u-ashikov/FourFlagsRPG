namespace FourFlagsRPG.Models.Models.Items.Health
{
    public class GreaterPotion : HealthPotion
    {
        private const int HealthPoints = 70;
        private const string PotionName = "Greater Healing Potion";

        public GreaterPotion(int id)
            : base(id, PotionName, HealthPoints)
        {
        }
    }
}
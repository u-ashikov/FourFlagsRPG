namespace FourFlagsRPG.Models.Models.Items.Health
{
    public class LightPotion : HealthPotion
    {
        private const int HealthPoints = 50;
        private const string PotionName = "Light Healing Potion";

        public LightPotion(int id)
            : base(id, PotionName, HealthPoints)
        {
        }
    }
}
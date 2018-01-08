namespace FourFlagsRPG.Models.Models.Items
{
    using Contracts.Items;

    public abstract class HealthPotion : Item, IHeal
    {
        private int healingPoints;

        public HealthPotion(int id, string name, int healingPoints)
            : base(id, name)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints
        {
            get { return this.healingPoints; }
            private set { this.healingPoints = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $", Healing points: {this.HealingPoints}";
        }
    }
}
namespace FourFlagsRPG.Models.Models.Items
{
    using Contracts.Items;

    public abstract class Weapon : Item, IWeapon
    {
        private int damageBonus;
        private int strengthBonus;

        public Weapon(int id, string name, int damageBonus, int strengthBonus)
            : base(id, name)
        {
            this.DamageBonus = damageBonus;
            this.StrengthBonus = strengthBonus;
        }

        public int DamageBonus
        {
            get { return this.damageBonus; }
            private set { this.damageBonus = value; }
        }

        public int StrengthBonus
        {
            get { return this.strengthBonus; }
            private set { this.strengthBonus = value; }
        }

        public int GetAttackBonus()
        {
            return this.DamageBonus + this.StrengthBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Damage: {this.DamageBonus}, Strength: {this.StrengthBonus}";
        }
    }
}
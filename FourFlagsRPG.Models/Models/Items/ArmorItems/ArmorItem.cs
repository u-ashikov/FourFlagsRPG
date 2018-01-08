namespace FourFlagsRPG.Models.Models.Items
{
    using Contracts.Items;
    using Enums;

    public abstract class ArmorItem : Item, IArmor
    {
        private int defenceBonus;
        private ArmorType armorType;

        public ArmorItem(int id, string name, int defenceBonus, ArmorType armorType)
            : base(id, name)
        {
            this.DefenceBonus = defenceBonus;
            this.ArmorType = armorType;
        }

        public int DefenceBonus
        {
            get { return this.defenceBonus; }
            private set { this.defenceBonus = value; }
        }

        public ArmorType ArmorType
        {
            get { return this.armorType; }
            private set { this.armorType = value; }
        }

        public int GetAttackBonus()
        {
            return this.DefenceBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Armor type: {this.ArmorType.ToString()}, Defence: {this.DefenceBonus}";
        }
    }
}
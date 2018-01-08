namespace FourFlagsRPG.Models.Models.Heroes
{
    using Containers;
    using Contracts.Heroes;
    using Contracts.Items;
    using Events;
    using System;
    using System.Linq;
    using Utilities;

    using static Utilities.GameConstants;
    using static Utilities.HeroConstants;
    using static Utilities.ItemConstants;

    public abstract class Hero : IHero
    {
        private string name;

        private string description;

        private int health;

        private int experience;

        private int level;

        private int damage;

        private int strength;

        private int defence;

        private int dexterity;

        private IInventory inventory;

        protected Hero(string name)
        {
            this.Name = name;
            this.Health = DefaultHealth;
            this.Damage = DefaultDamage;
            this.Strength = DefaultStrength;
            this.Defence = DefaultDefence;
            this.Dexterity = DefaultDexterity;
            this.Inventory = new Inventory();
            this.Level = HeroStartingLevel;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.ValidateHeroName(value);

                this.name = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            protected set
            {
                this.description = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            protected set
            {
                Validator.ValidateStats(value, HealthStat, HeroUnit);

                this.health = value;
            }
        }

        public int Experience
        {
            get { return this.experience; }
            private set
            {
                Validator.ValidateStats(value, ExperienceStat, HeroUnit);

                this.experience = value;
            }
        }

        public int Level
        {
            get { return this.level; }
            private set
            {
                Validator.ValidateStats(value, LevelStat, HeroUnit);

                this.level = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            protected set
            {
                Validator.ValidateStats(value, DamageStat, HeroUnit);

                this.damage = value;
            }
        }

        public int Strength
        {
            get { return this.strength; }
            protected set
            {
                Validator.ValidateStats(value, StrengthStat, HeroUnit);

                this.strength = value;
            }
        }

        public int Defence
        {
            get { return this.defence; }
            protected set
            {
                Validator.ValidateStats(value, DefenceStat, HeroUnit);

                this.defence = value;
            }
        }

        public int Dexterity
        {
            get { return this.dexterity; }
            protected set
            {
                Validator.ValidateStats(value, DexterityStat, HeroUnit);

                this.dexterity = value;
            }
        }

        public IInventory Inventory
        {
            get { return this.inventory; }
            private set
            {
                this.inventory = value;
            }
        }

        public int GetAttackDamage()
        {
            return this.Strength + this.Damage + this.Dexterity + this.Inventory.GetBonusDamage();
        }

        public string Heal()
        {
            ISlot healingItemSlot = this.inventory.BackPack.SlotList
                .FirstOrDefault(s => !s.IsEmpty && s.Item.GetType().BaseType.Name == HealthPotion);

            if (healingItemSlot != null)
            {
                IHeal potion = healingItemSlot.Item as IHeal;
                this.health += potion.HealingPoints;
                healingItemSlot.IsEmpty = true;
                healingItemSlot.Item = null;

                return string.Format(Message.SuccessRestoreHealth, potion.HealingPoints);
            }

            return Message.NoHealingItemsLeft;
        }

        public void Collect(object sender, QuestCompletedEventArgs args)
        {
            foreach (IItem item in args.ItemRewards)
            {
                Validator.ValidateItem(item);

                this.inventory.BackPack.LootItem(item);
            }

            this.GainExperience(args.Experience);
        }

        public void TakeDamage(int damagePoints)
        {
            this.health -= damagePoints;
        }

        private void GainExperience(int experience)
        {
            Validator.ValidateStats(experience, ExperienceStat, HeroUnit);

            this.experience += experience;

            if (this.experience >= ExperienceConstant * this.level)
            {
                this.level++;
            }
        }

        public string ShowStats()
        {
            return $"HP ==> {this.Health}{Environment.NewLine}STR ==> {this.Strength}{Environment.NewLine}DEX ==> {this.Dexterity}{Environment.NewLine}DEF ==> {this.Defence}{Environment.NewLine}EXP ==> {this.Experience}";
        }
    }
}
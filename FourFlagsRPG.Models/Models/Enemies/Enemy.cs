namespace FourFlagsRPG.Models.Models.Enemies
{
    using Contracts.Beings;
    using Contracts.Enemies;
    using Utilities;

    public abstract class Enemy : IEnemy
    {
        private int id;
        private int health;
        private int damage;
        private int defence;
        private int experianceReward;

        protected Enemy(int id)
        {
            this.Id = id;
            this.Health = EnemyConstants.EnemyHealth;
            this.Damage = EnemyConstants.EnemyDamage;
            this.Defence = EnemyConstants.EnemyDefence;
            this.ExperianceReward = EnemyConstants.EnemyExperianceReward;
        }

        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                Validator.ValidateEnemyStats(nameof(this.Health), value);

                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            private set
            {
                Validator.ValidateEnemyStats(nameof(this.Damage), value);

                this.damage = value;
            }
        }

        public int Defence
        {
            get { return this.defence; }
            private set
            {
                Validator.ValidateEnemyStats(nameof(this.Defence), value);

                this.defence = value;
            }
        }

        public int ExperianceReward
        {
            get { return this.experianceReward; }
            private set
            {
                Validator.ValidateEnemyStats(nameof(this.ExperianceReward), value);

                this.experianceReward = value;
            }
        }

        public void Attack(IBeing target)
        {
            target.TakeDamage(this.GetAttackDamage());
        }

        public int GetAttackDamage()
        {
            return this.Damage;
        }

        public void TakeDamage(int damagePoints)
        {
            this.health -= damagePoints;
        }
    }
}
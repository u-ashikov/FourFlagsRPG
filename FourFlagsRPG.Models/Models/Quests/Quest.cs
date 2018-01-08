namespace FourFlagsRPG.Models.Models.Quests
{
    using Contracts.Enemies;
    using Contracts.Items;
    using Contracts.Quests;
    using Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities;

    using static Utilities.GameConstants.Message;

    public abstract class Quest : IQuest
    {
        private int id;
        private string name;
        private string description;
        private string destination;
        private string enviroment;
        private int experienceReward;
        private IDictionary<IEnemy, bool> enemiesToKill;
        private readonly List<IItem> itemRewards;

        public event QuestCompletedHandler QuestCompleted;

        public Quest(int id, string name, string description, string destination, string enviroment, int experienceReward, ICollection<IEnemy> enemiesToKill, ICollection<IItem> itemRewards)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Destination = destination;
            this.Enviroment = enviroment;
            this.ExperienceReward = experienceReward;
            this.enemiesToKill = enemiesToKill.ToDictionary(k => k, v => false);
            this.itemRewards = itemRewards.ToList();
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (!Validator.ValidateStringNotNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NotNullOrEmpty);
                }

                this.name = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            private set
            {
                if (!Validator.ValidateStringNotNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NotNullOrEmpty);
                }

                this.description = value;
            }
        }

        public string Destination
        {
            get { return this.destination; }
            private set { this.destination = value; }
        }

        public string Enviroment
        {
            get { return this.enviroment; }
            private set { this.enviroment = value; }
        }

        public int ExperienceReward
        {
            get { return this.experienceReward; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NotZeroOrNegative);
                }

                this.experienceReward = value;
            }
        }

        public IReadOnlyList<IEnemy> Enemies
        {
            get { return this.enemiesToKill.Keys.ToList().AsReadOnly(); }
        }

        public IReadOnlyList<IItem> ItemRewards
        {
            get { return this.itemRewards.AsReadOnly(); }
        }

        public void KilledEnemy(IEnemy enemy)
        {
            this.enemiesToKill[enemy] = true;
        }

        public bool Completed()
        {
            return this.enemiesToKill.Values.All(v => v != false);
        }

        public string ShowRewards()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(ExpereinceGained, this.ExperienceReward));
            result.AppendLine(YouHaveCollected);

            foreach (IItem itemReward in this.ItemRewards)
            {
                result.AppendLine(itemReward.ToString());
            }

            return result.ToString().Trim();
        }

        public void CompleteQuest()
        {
            if (this.Completed())
            {
                this.OnQuestCompleted(new QuestCompletedEventArgs(this.ExperienceReward, this.ItemRewards.ToList()));
            }
        }

        private void OnQuestCompleted(QuestCompletedEventArgs args)
        {
            this.QuestCompleted?.Invoke(this, args);
        }
    }
}
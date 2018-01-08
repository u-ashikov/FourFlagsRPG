namespace FourFlagsRPG.Models.Models.Quests
{
    using Contracts.Enemies;
    using Contracts.Items;
    using System.Collections.Generic;

    public class HuntQuest : Quest
    {
        public HuntQuest(int id, string name, string description, string destination, string enviroment, int experienceReward, ICollection<IEnemy> enemiesToKill, ICollection<IItem> itemRewards)
            : base(id, name, description, destination, enviroment, experienceReward, enemiesToKill, itemRewards)
        {
        }
    }
}
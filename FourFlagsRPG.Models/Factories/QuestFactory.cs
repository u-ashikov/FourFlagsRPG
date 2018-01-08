namespace FourFlagsRPG.Models.Factories
{
    using Contracts.Enemies;
    using Contracts.Items;
    using Contracts.Quests;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using static Utilities.GameConstants;

    public static class QuestFactory
    {
        public static IQuest CreateQuest(int id, string name, string description, string destination, string enviroment, int experienceReward, ICollection<IEnemy> enemiesToKill, ICollection<IItem> itemRewards)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.DefinedTypes
                .FirstOrDefault(t => t.Name == HuntQuestName);

            return (IQuest)Activator.CreateInstance(type, new object[] { id, name, description, description, enviroment, experienceReward, enemiesToKill, itemRewards });
        }
    }
}
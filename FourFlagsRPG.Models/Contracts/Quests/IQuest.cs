namespace FourFlagsRPG.Models.Contracts.Quests
{
    using Enemies;
    using Events;
    using Items;
    using System.Collections.Generic;

    public delegate void QuestCompletedHandler(object sender, QuestCompletedEventArgs args);

    public interface IQuest
    {
        int ID { get; }

        string Name { get; }

        string Description { get; }

        string Destination { get; }

        string Enviroment { get; }

        int ExperienceReward { get; }

        IReadOnlyList<IItem> ItemRewards { get; }

        IReadOnlyList<IEnemy> Enemies { get; }

        void KilledEnemy(IEnemy enemy);

        bool Completed();

        string ShowRewards();

        event QuestCompletedHandler QuestCompleted;

        void CompleteQuest();
    }
}
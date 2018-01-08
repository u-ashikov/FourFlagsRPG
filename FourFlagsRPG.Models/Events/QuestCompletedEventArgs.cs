namespace FourFlagsRPG.Models.Events
{
    using Contracts.Items;
    using System;
    using System.Collections.Generic;

    public class QuestCompletedEventArgs : EventArgs
    {
        public QuestCompletedEventArgs(int experience, IList<IItem> rewards)
        {
            this.Experience = experience;
            this.ItemRewards = rewards;
        }

        public int Experience { get; private set; }

        public IList<IItem> ItemRewards { get; private set; }
    }
}
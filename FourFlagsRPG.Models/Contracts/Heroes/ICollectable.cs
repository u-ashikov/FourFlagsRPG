namespace FourFlagsRPG.Models.Contracts.Heroes
{
    using Events;

    public interface ICollectable
    {
        void Collect(object sender, QuestCompletedEventArgs args);
    }
}
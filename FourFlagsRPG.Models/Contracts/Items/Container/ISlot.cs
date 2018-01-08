namespace FourFlagsRPG.Models.Contracts.Items
{
    public interface ISlot
    {
        IItem Item { get; set; }

        bool IsEmpty { get; set; }

        void ClearSlot();
    }
}
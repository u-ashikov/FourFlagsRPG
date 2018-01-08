namespace FourFlagsRPG.Models.Contracts.Items
{
    using System.Collections.Generic;

    public interface IContainer
    {
        IEnumerable<ISlot> SlotList { get; }

        void LootItem(IItem item);

        void RemoveItem(ISlot slot);

        void ListItems();
    }
}
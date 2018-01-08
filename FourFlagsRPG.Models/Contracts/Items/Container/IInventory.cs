namespace FourFlagsRPG.Models.Contracts.Items
{
    public interface IInventory
    {
        IWeapon MainHandSlot { get; }

        IArmor ChestSlot { get; }

        IArmor HeadSlot { get; }

        IArmor FeetSlot { get; }

        IArmor GlovesSlot { get; }

        IContainer BackPack { get; }

        void EquipItem(int id);

        void StoreItem(IItem item);

        int GetBonusDamage();
    }
}
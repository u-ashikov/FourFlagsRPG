namespace FourFlagsRPG.Models.Models.Containers
{
    using Contracts.Items;
    using Items;
    using System;
    using System.Linq;
    using System.Text;

    using static Utilities.GameConstants.Message;
    using static Utilities.ItemConstants;

    public class Inventory : IInventory
    {
        private IWeapon mainHandSlot;
        private IArmor chestSlot;
        private IArmor headSlot;
        private IArmor feetSlot;
        private IArmor glovesSlot;
        private IContainer backpack;

        public Inventory()
        {
            this.BackPack = new Backpack();
        }

        public IContainer BackPack
        {
            get { return this.backpack; }
            private set { this.backpack = value; }
        }

        public IWeapon MainHandSlot
        {
            get { return this.mainHandSlot; }
            private set { this.mainHandSlot = value; }
        }

        public IArmor ChestSlot
        {
            get { return this.chestSlot; }
            private set { this.chestSlot = value; }
        }

        public IArmor HeadSlot
        {
            get { return this.headSlot; }
            private set { this.headSlot = value; }
        }

        public IArmor FeetSlot
        {
            get { return this.feetSlot; }
            private set { this.feetSlot = value; }
        }

        public IArmor GlovesSlot
        {
            get { return this.glovesSlot; }
            private set { this.glovesSlot = value; }
        }

        public void StoreItem(IItem item)
        {
            this.backpack.LootItem(item);
        }

        public void EquipItem(int id)
        {
            IItem itemToEquip = this.BackPack.SlotList.FirstOrDefault(s => !s.IsEmpty && s.Item.Id == id).Item;

            if (itemToEquip != null)
            {
                if (itemToEquip.GetType().BaseType.Name == WeaponItemName)
                {
                    this.CheckAndReplace(this.MainHandSlot);

                    this.mainHandSlot = itemToEquip as Weapon;
                }
                else if (itemToEquip.GetType().BaseType.Name == ArmorItemName)
                {
                    IArmor armor = itemToEquip as ArmorItem;
                    string armorType = armor.ArmorType.ToString();

                    if (armorType == ArmorTypeChest)
                    {
                        this.CheckAndReplace(this.ChestSlot);

                        this.ChestSlot = armor;
                    }
                    else if (armorType == ArmorTypeHead)
                    {
                        this.CheckAndReplace(this.HeadSlot);

                        this.HeadSlot = armor;
                    }
                    else if (armorType == ArmorTypeFeet)
                    {
                        this.CheckAndReplace(this.FeetSlot);

                        this.FeetSlot = armor;
                    }
                    else if (armorType == ArmorTypeGloves)
                    {
                        this.CheckAndReplace(this.GlovesSlot);

                        this.GlovesSlot = armor;
                    }
                }
                else
                {
                    throw new ArgumentException(ItemCannotBeEquipped);
                }

                ISlot itemToRemove = this.BackPack.SlotList.FirstOrDefault(s => s.Item.Id == id);
                this.BackPack.RemoveItem(itemToRemove);
            }
        }

        private void CheckAndReplace(IItem slot)
        {
            if (slot != null)
            {
                this.BackPack.LootItem(slot);
                slot = null;
            }
        }

        public int GetBonusDamage()
        {
            return (this.HeadSlot == null ? 0 : this.HeadSlot.GetAttackBonus())
                + (this.ChestSlot == null ? 0 : this.ChestSlot.GetAttackBonus())
                + (this.FeetSlot == null ? 0 : this.FeetSlot.GetAttackBonus())
                + (this.GlovesSlot == null ? 0 : this.GlovesSlot.GetAttackBonus())
                + (this.MainHandSlot == null ? 0 : this.MainHandSlot.GetAttackBonus());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Head: {(this.HeadSlot == null ? "No item" : this.HeadSlot.ToString())}");
            result.AppendLine($"Chest: {(this.ChestSlot == null ? "No item" : this.ChestSlot.ToString())}");
            result.AppendLine($"Hand: {(this.MainHandSlot == null ? "No item" : this.MainHandSlot.ToString())}");
            result.AppendLine($"Gloves: {(this.GlovesSlot == null ? "No item" : this.GlovesSlot.ToString())}");
            result.AppendLine($"Feet: {(this.FeetSlot == null ? "No item" : this.FeetSlot.ToString())}");
            result.AppendLine(Environment.NewLine + $"Back pack items:");
            result.AppendLine(this.BackPack.ToString());

            return result.ToString().Trim();
        }
    }
}
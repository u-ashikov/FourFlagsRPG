namespace FourFlagsRPG.Models.Models.Containers
{
    using Contracts.Items;

    public class Slot : ISlot
    {
        private IItem item;
        private bool isEmpty;

        public Slot()
        {
            this.IsEmpty = true;
            this.Item = null;
        }

        public IItem Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        public bool IsEmpty
        {
            get { return this.isEmpty; }
            set { this.isEmpty = value; }
        }

        public void ClearSlot()
        {
            this.Item = null;
            this.IsEmpty = true;
        }
    }
}
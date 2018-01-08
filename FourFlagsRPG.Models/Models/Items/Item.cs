namespace FourFlagsRPG.Models.Models.Items
{
    using FourFlagsRPG.Models.Contracts.Items;
    using FourFlagsRPG.Models.Enums;

    public abstract class Item : IItem
    {
        private int id;
        private string name;

        protected Item(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        private ItemState ItemState { get; set; }

        public override string ToString()
        {
            return $"{this.Id}. Item type: {this.GetType().BaseType.Name}, Name: {this.Name}";
        }
    }
}
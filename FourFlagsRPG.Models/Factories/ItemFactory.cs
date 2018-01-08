namespace FourFlagsRPG.Models.Factories
{
    using Contracts.Items;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ItemFactory
    {
        public static IItem CreateItem(string itemTypeName, int id)
        {
            Type itemType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == itemTypeName);

            return (IItem)Activator.CreateInstance(itemType, new object[] { id });
        }
    }
}
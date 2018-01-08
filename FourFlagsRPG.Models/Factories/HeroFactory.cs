namespace FourFlagsRPG.Models.Factories
{
    using Contracts.Heroes;
    using Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class HeroFactory
    {
        public static IHero CreateHero(int type, string name)
        {
            string heroTypeName = Enum.GetName(typeof(Hero), type);
            Type heroType = Assembly.GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == heroTypeName);

            return (IHero)Activator.CreateInstance(heroType, new object[] { name });
        }
    }
}
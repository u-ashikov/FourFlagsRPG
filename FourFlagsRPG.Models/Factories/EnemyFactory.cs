namespace FourFlags.Models.Factories
{
    using FourFlagsRPG.Models.Contracts.Enemies;
    using FourFlagsRPG.Models.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class EnemyFactory
    {
        public static IEnemy CreateEnemy(Enemies enemyType, int enemyId)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.DefinedTypes
                .FirstOrDefault(t => t.Name == enemyType.ToString());

            return (IEnemy)Activator.CreateInstance(type, new object[] { enemyId });
        }
    }
}
namespace FourFlagsRPG.Models.Utilities
{
    using Contracts.Items;
    using System;

    public static class Validator
    {
        private const string InvalidItem = "Invalid item!";
        private const string InvalidHeroNameEmpty = "Your hero name must be non empty!";
        private const string InvalidHeroNameLength = "Your hero name length must be between 1 and 20 symbols!";
        private const string StatCannotBeNegative = "{0} {1} cannot be negative!";
        private const string EnemyStatCannotBeNegative = "Enemy {0} cannot be Zero or Negative!";
        private const int NameMaxLength = 20;
        private const int NameMinLength = 0;
        public const int EnemyStatMinValue = 0;

        public static void ValidateHeroName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(InvalidHeroNameEmpty);
            }

            if (name.Length > NameMaxLength)
            {
                throw new ArgumentException(InvalidHeroNameLength);
            }
        }

        public static void ValidateStats(int statValue, string statName, string unitType)
        {
            if (statValue < NameMinLength)
            {
                throw new ArgumentException(string.Format(StatCannotBeNegative, unitType, statName));
            }
        }

        public static bool ValidateStringNotNullOrEmpty(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            return true;
        }

        public static void ValidateItem(IItem item)
        {
            if (item == null)
            {
                throw new NullReferenceException(InvalidItem);
            }
        }

        public static void ValidateEnemyStats(string statName, int value)
        {
            if (value <= EnemyStatMinValue)
            {
                throw new ArgumentException(string.Format(EnemyStatCannotBeNegative, statName));
            }
        }
    }
}
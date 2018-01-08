namespace FourFlagsRPG.Models.Utilities
{
    public static class GameConstants
    {
        public const string ConsoleGameTitle = "Four Flags RPG";

        public const string GameTitle = @"
  ______                            ______   _                             _____    _____     _____
 |  ____|                          |  ____| | |                           |  __ \  |  __ \   / ____|
 | |__    ___    _   _   _ __      | |__    | |   __ _    __ _   ___      | |__) | | |__) | | |  __
 |  __|  / _ \  | | | | | '__|     |  __|   | |  / _` |  / _` | / __|     |  _  /  |  ___/  | | |_ |
 | |    | (_) | | |_| | | |        | |      | | | (_| | | (_| | \__ \     | | \ \  | |      | |__| |
 |_|     \___/   \__,_| |_|        |_|      |_|  \__,_|  \__, | |___/     |_|  \_\ |_|       \_____|
                                                          __/ |
                                                         |___/                                      ";

        public const string ChooseHero = @"
 _______           _______  _______  _______  _______                _______           _______       _______  _______  _______  _______
(  ____ \|\     /|(  ___  )(  ___  )(  ____ \(  ____ \     |\     /|(  ___  )|\     /|(  ____ )     (  ____ )(  ___  )(  ____ \(  ____ \
| (    \/| )   ( || (   ) || (   ) || (    \/| (    \/     ( \   / )| (   ) || )   ( || (    )|     | (    )|| (   ) || (    \/| (    \/  _
| |      | (___) || |   | || |   | || (_____ | (__          \ (_) / | |   | || |   | || (____)|     | (____)|| (___) || |      | (__     (_)
| |      |  ___  || |   | || |   | |(_____  )|  __)          \   /  | |   | || |   | ||     __)     |     __)|  ___  || |      |  __)
| |      | (   ) || |   | || |   | |      ) || (              ) (   | |   | || |   | || (\ (        | (\ (   | (   ) || |      | (        _
| (____/\| )   ( || (___) || (___) |/\____) || (____/\        | |   | (___) || (___) || ) \ \__     | ) \ \__| )   ( || (____/\| (____/\ (_)
(_______/|/     \|(_______)(_______)\_______)(_______/        \_/   (_______)(_______)|/   \__/     |/   \__/|/     \|(_______/(_______/    ";

        public const string HeroUnit = "Hero";

        public const string HuntQuestName = "HuntQuest";

        public const int PlayerNameMinLength = 1;

        public const int PlayerNameMaxLength = 20;

        public class Message
        {
            public const string SuccessRestoreHealth = "You have restored {0} health points!";

            public const string NoHealingItemsLeft = "You don't have any healing items!";

            public const string BackpackIsEmpty = "Invalid operation. Your backpack is empty!";

            public const string FullBackPack = "Your backpack is full!";

            public const string EmptySlots = "Empty slots: {0}";

            public const string ItemCannotBeEquipped = "Item cannot be equiped!";

            public const string NotNullOrEmpty = "String cannot be Null or Empty";

            public const string NotZeroOrNegative = "Value cannot be Zero or Negative";

            public const string YouHaveCollected = "You have collected:";

            public const string ExpereinceGained = "You have gained: {0} Experience Points!";
        }
    }
}
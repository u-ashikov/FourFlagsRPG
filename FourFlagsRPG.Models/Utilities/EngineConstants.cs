namespace FourFlagsRPG.Models.Utilities
{
    public static class EngineConstants
    {
        public const char AnswerOne = '1';
        public const char AnswerTwo = '2';

        public const int MinBeingHealth = 0;
        public const int InitialBattleRound = 1;

        public const string ItemToEquipInvalidValue = "0";

        public const char CommandZeroChoice = '0';
        public const char CommandFirstChoice = '1';
        public const char CommandSecondChoice = '2';
        public const char CommandThirdChoice = '3';

        public const string GameStartingMessage = "You have been chosen to clear all the evil in our world!";

        public const string EmptyHeroNameExceptionMessage = "Player name must be between 1 and 20 symbols long!";

        public const string PressAnyKeyToContinue = "Press any key to continue...";

        public const string CreateHeroGreetingMessage = "Hello young master,{0}";

        public const string CreateHeroMesage = "Please enter your epic name:{0}==> ";

        public const string ChooseRaceWrongChoice = "{0}Wrong choice!";

        public const string ChosenHeroRaceMessage = "You have chosen: {0}";

        public const string ChosenHeroRaceStartingStatsMessage = "Your starting stats are as follows:{0}{1}";

        public const string HeroTypeToChooseMessage = "[{0}] {1}";

        public const string FinalMessage = "Congratulations!!! You destroyed all the evil in the world!!!";
    }
}
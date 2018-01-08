namespace FourFlagsRPG.Models.Utilities
{
    using System.Text;

    public static class QuestReaderConstants
    {
        public const string QuestReaderPattern = @"#Type(?:.*)[\r\n]+([\w\W\r\n]+)#Name(?:.*)[\r\n]+([\w\W\r\n]+)#Description(?:.*)[\r\n]+([\w\W\r\n]+)#Destination(?:.*)[\r\n]+([\w\W\r\n]+)#Enviroment(?:.*)[\r\n]+([\w\W\r\n]+)#Progress(?:.*)[\r\n]+([\w\W\r\n]+)#ItemRewards(?:.*)[\r\n]+([\w\W\r\n]+)#ExperienceReward(?:.*)[\r\n]+([\w\W\r\n]+)";

        public const string QuestDirectoryName = "Quest";

        public const string CreateQuestDirectory = "{0}Quests";

        public const string CreateQuestDirectoryPath = "{0}Quests\\";

        public const string EnemiesNamespace = "FourFlagsRPG.Models.Models.Enemies";

        public const string QuestFileNameEnding = ".quest";

        public const string HelpTextFileName = "help.txt";

        public static string CreateHelpTextFile = GetHelpText();

        private static string GetHelpText()
        {
            StringBuilder helpText = new StringBuilder();

            helpText.AppendLine("Quest file must end with .quest and have:")
                    .AppendLine("#Type - HuntQuest")
                    .AppendLine("#Name")
                    .AppendLine("#Description")
                    .AppendLine("#Destination")
                    .AppendLine("#Enviroment")
                    .AppendLine("#Progress")
                    .AppendLine("#ItemRewards (item - id)")
                    .AppendLine("#ExperienceReward");

            return helpText.ToString().Trim();
        }
    }
}
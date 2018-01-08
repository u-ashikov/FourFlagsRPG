namespace FourFlagsRPG.Core
{
    using FourFlags.BusinessLogic.Controllers.Quest;
    using FourFlags.BusinessLogic.Controllers.QuestGamePlay;
    using Models.Contracts.Enemies;
    using Models.Contracts.Engine;
    using Models.Contracts.Heroes;
    using Models.Contracts.IO;
    using Models.Contracts.Items;
    using Models.Contracts.Quests;
    using Models.Enums;
    using Models.Factories;
    using Models.IO;
    using Models.Utilities;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IHero hero;
        private IList<IEnemy> enemies;
        private IList<IItem> items;
        private QuestReaderController questReader;
        private Array heroTypes = Enum.GetValues(typeof(Hero));

        public Engine(IWriter writer, IReader reader)
        {
            this.reader = reader;
            this.writer = writer;
            this.enemies = new List<IEnemy>();
            this.items = new List<IItem>();
        }

        public void Run()
        {
            this.questReader = new QuestReaderController(new FileWriter(), new FileReader());

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.ForegroundColor = ConsoleColor.Yellow;
            this.writer.WriteLine(GameConstants.GameTitle);
            this.CreateHero();
            this.writer.WriteLine(EngineConstants.PressAnyKeyToContinue);
            this.reader.ReadKey();

            this.writer.Clear();
            this.writer.WriteLine(EngineConstants.GameStartingMessage);
            this.writer.WriteLine(EngineConstants.PressAnyKeyToContinue);

            this.reader.ReadKey();
            this.writer.Clear();

            foreach (IQuest questReaderQuest in questReader.Quests)
            {
                QuestGamePlayController questGamePlay = new QuestGamePlayController(questReaderQuest, this.hero, this.writer, this.reader, new QuestEncounters());
                questGamePlay.Start();
            }

            this.writer.WriteLine(EngineConstants.FinalMessage);
        }

        private void CreateHero()
        {
            this.writer.Write(string.Format(EngineConstants.CreateHeroGreetingMessage, Environment.NewLine) + string.Format(EngineConstants.CreateHeroMesage, Environment.NewLine));

            string playerName = this.reader.ReadLine();
            playerName = this.InitHeroName(playerName);

            this.writer.Clear();
            char cki;
            int heroId;

            this.writer.WriteLine(GameConstants.ChooseHero + Environment.NewLine);

            foreach (object heroType in this.heroTypes)
            {
                this.writer.WriteLine(string.Format(EngineConstants.HeroTypeToChooseMessage, Array.IndexOf(this.heroTypes, heroType) + 1, heroType));
            }

            cki = this.reader.ReadKey();

            while (!char.IsNumber(cki) || !Enum.IsDefined(typeof(Hero), int.Parse(cki.ToString())))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                this.writer.WriteLine(string.Format(EngineConstants.ChooseRaceWrongChoice, Environment.NewLine));
                Console.ForegroundColor = ConsoleColor.Yellow;

                cki = this.reader.ReadKey();
            }

            heroId = int.Parse(cki.ToString());

            this.hero = HeroFactory.CreateHero(heroId, playerName);
            this.ShowHeroStartingInfo();
        }

        private void ShowHeroStartingInfo()
        {
            this.writer.Clear();
            this.writer.WriteLine(string.Format(EngineConstants.ChosenHeroRaceMessage, this.hero.GetType().Name));
            this.writer.Write(Environment.NewLine);
            this.writer.WriteLine(this.hero.Description);
            Console.ForegroundColor = ConsoleColor.Magenta;
            this.writer.Write(new string('=', Console.BufferWidth));
            this.writer.WriteLine(string.Format(EngineConstants.ChosenHeroRaceStartingStatsMessage, Environment.NewLine, this.hero.ShowStats()));
            this.writer.Write(new string('=', Console.BufferWidth));
            Console.ResetColor();
        }

        private string InitHeroName(string playerName)
        {
            while (playerName.Length < GameConstants.PlayerNameMinLength || playerName.Length > GameConstants.PlayerNameMaxLength || string.IsNullOrWhiteSpace(playerName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                this.writer.WriteLine(EngineConstants.EmptyHeroNameExceptionMessage);
                this.writer.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Yellow;
                this.writer.Write(string.Format(EngineConstants.CreateHeroMesage, Environment.NewLine));
                playerName = this.reader.ReadLine();
            }

            return playerName;
        }
    }
}
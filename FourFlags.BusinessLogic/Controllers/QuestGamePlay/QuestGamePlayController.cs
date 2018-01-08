namespace FourFlags.BusinessLogic.Controllers.QuestGamePlay
{
    using FourFlagsRPG.Models.Contracts.Enemies;
    using FourFlagsRPG.Models.Contracts.Heroes;
    using FourFlagsRPG.Models.Contracts.IO;
    using FourFlagsRPG.Models.Contracts.Quests;
    using FourFlagsRPG.Models.Exceptions.QuestExceptions;
    using FourFlagsRPG.Models.IO;
    using FourFlagsRPG.Models.Utilities;
    using System;
    using System.Linq;

    using static FourFlagsRPG.Models.Utilities.EngineConstants;

    public class QuestGamePlayController
    {
        private IQuest quest;
        private IHero hero;
        private IWriter consoleWriter;
        private IReader consoleReader;
        private QuestEncounters questEncounters;

        public QuestGamePlayController(IQuest quest, IHero hero, IWriter consoleWriter, IReader consoleReader, QuestEncounters questEncounters)
        {
            this.quest = quest;
            this.hero = hero;
            this.consoleWriter = consoleWriter;
            this.consoleReader = consoleReader;
            this.questEncounters = questEncounters;
        }

        public void Start()
        {
            this.WriteStory();
            this.PressAny();
            this.StartRotation();
        }

        private void WriteStory()
        {
            this.consoleWriter.WriteLine(this.quest.Name);
            this.consoleWriter.WriteLine(this.quest.Description);
        }

        private bool Continue()
        {
            this.consoleWriter.Write(Environment.NewLine);
            this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.TwoChoiceToContinue);

            char answer = default(char);

            while (answer != AnswerOne && answer != AnswerTwo)
            {
                answer = this.consoleReader.ReadKey();

                switch (answer)
                {
                    case AnswerOne:
                        this.consoleWriter.WriteLine(Environment.NewLine);
                        this.consoleWriter.Clear();
                        return true;

                    case AnswerTwo:
                        this.consoleWriter.Clear();
                        this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.QuitMessage);
                        this.consoleWriter.GameOver();
                        return false;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        this.consoleWriter.Write(Environment.NewLine);
                        this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.WrongCommand);
                        Console.ResetColor();
                        break;
                }
            }

            return false;
        }

        private void PressAny()
        {
            this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.PressAnyKeyToContinue);
            this.consoleReader.ReadKey();
            this.consoleWriter.Clear();
        }

        private void UpdateStats()
        {
            int strengthFromItems = this.hero.Inventory.MainHandSlot == null ? 0 : this.hero.Inventory.MainHandSlot.StrengthBonus;
            int damageFromItems = this.hero.Inventory.MainHandSlot == null ? 0 : this.hero.Inventory.MainHandSlot.DamageBonus;
            int defenceFromItems = (this.hero.Inventory.HeadSlot == null ? 0 : this.hero.Inventory.HeadSlot.DefenceBonus) +
                                   (this.hero.Inventory.GlovesSlot == null ? 0 : this.hero.Inventory.GlovesSlot.DefenceBonus) +
                                   (this.hero.Inventory.ChestSlot == null ? 0 : this.hero.Inventory.ChestSlot.DefenceBonus) +
                                   (this.hero.Inventory.FeetSlot == null ? 0 : this.hero.Inventory.FeetSlot.DefenceBonus);

            this.consoleWriter.UpdateStats(this.hero.Name, this.hero.GetType().Name, this.hero.Health, this.hero.Strength + strengthFromItems, this.hero.Dexterity, this.hero.Damage + damageFromItems, this.hero.Defence + defenceFromItems, this.hero.Level, this.hero.Experience, this.hero.Inventory.MainHandSlot?.Name, this.hero.Inventory.HeadSlot?.Name, this.hero.Inventory.ChestSlot?.Name, this.hero.Inventory.GlovesSlot?.Name, this.hero.Inventory.FeetSlot?.Name);
        }

        private void StartRotation()
        {
            this.UpdateStats();

            foreach (IEnemy questEnemy in this.quest.Enemies)
            {
                this.consoleWriter.WriteLine(this.questEncounters.GetRandom());

                if (this.Continue())
                {
                    this.StartFight(questEnemy);
                }
            }

            this.ChooseNextMove();
        }

        private void ChooseNextMove()
        {
            this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ChooseYourNextMove);
            this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ShowInventoryOrContinue);

            char command = this.consoleReader.ReadKey();

            while (command != CommandZeroChoice)
            {
                switch (command)
                {
                    case CommandFirstChoice:
                        this.consoleWriter.WriteLine(Environment.NewLine);
                        this.ShowInventory();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.WrongCommand);
                        Console.ResetColor();
                        break;
                }

                this.consoleWriter.Write(Environment.NewLine);
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ChooseYourNextMove);
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ShowInventoryOrContinue);

                command = this.consoleReader.ReadKey();
            }

            this.consoleWriter.Write(Environment.NewLine);
            this.Continue();
        }

        private void StartFight(IEnemy questEnemy)
        {
            this.quest.QuestCompleted += this.hero.Collect;

            this.consoleWriter.WriteLine(string.Format(QuestGamePlayControllerConstants.EncounterEnemy, questEnemy.GetType().Name));

            int battleRound = InitialBattleRound;

            while (this.hero.Health > MinBeingHealth && questEnemy.Health > MinBeingHealth)
            {
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ChooseYourNextMove);
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.NextMoveInBattle);

                char command = this.consoleReader.ReadKey();
                this.consoleWriter.Clear();

                this.consoleWriter.WriteLine(string.Format(QuestGamePlayControllerConstants.BattleRound, battleRound++));
                this.consoleWriter.Write(Environment.NewLine);

                switch (command)
                {
                    case CommandFirstChoice:
                        this.Attack(questEnemy);
                        break;

                    case CommandSecondChoice:
                        this.consoleWriter.WriteLine(this.hero.Heal());
                        this.hero.TakeDamage(questEnemy.GetAttackDamage());
                        break;

                    case CommandThirdChoice:
                        this.UpdateStats();
                        this.consoleWriter.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ResetColor();
                        return;

                    default:
                        battleRound--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.WrongCommand);
                        Console.ResetColor();
                        break;
                }

                this.UpdateStats();
                this.consoleWriter.Write(Environment.NewLine);
            }

            this.consoleWriter.Clear();

            if (this.hero.Health > MinBeingHealth)
            {
                this.quest.KilledEnemy(questEnemy);

                this.consoleWriter.WriteLine(string.Format(QuestGamePlayControllerConstants.CongratulationForKillingAnEnemy, this.hero.GetType().Name, questEnemy.GetType().Name));
                this.consoleWriter.Write(Environment.NewLine);

                this.quest.CompleteQuest();

                Console.ForegroundColor = ConsoleColor.Green;
                this.consoleWriter.WriteLine(this.quest.ShowRewards());
                this.consoleWriter.Write(Environment.NewLine);
                Console.ResetColor();

                this.UpdateStats();
            }
            else
            {
                this.consoleWriter.WriteLine(string.Format(QuestGamePlayControllerConstants.DiedMessage, questEnemy.GetType().Name));
                this.consoleWriter.GameOver();
            }
        }

        private void ShowInventory()
        {
            this.consoleWriter.Clear();
            this.UpdateStats();

            if (this.hero.Inventory.BackPack.SlotList.All(s => s.IsEmpty))
            {
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.HeroHasNoItems);
                return;
            }

            this.consoleWriter.WriteLine(this.hero.Inventory.ToString());
            this.consoleWriter.Write(Environment.NewLine);

            this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ChooseItemToEquip);

            string itemToEquip = this.consoleReader.ReadLine();

            if (string.IsNullOrEmpty(itemToEquip) || itemToEquip == ItemToEquipInvalidValue)
            {
                return;
            }

            int itemId;
            int[] itemsIds = this.hero.Inventory.BackPack.SlotList
                .Where(s => !s.IsEmpty)
                .Select(s => s.Item.Id)
                .ToArray();

            bool isItemIdParsed = int.TryParse(itemToEquip, out itemId);

            while (!isItemIdParsed || itemsIds.All(i => i != itemId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.WrongCommand);
                this.consoleWriter.Write(Environment.NewLine);
                Console.ResetColor();
                this.consoleWriter.WriteLine(QuestGamePlayControllerConstants.ChooseItemToEquip);
                itemToEquip = this.consoleReader.ReadLine();
                isItemIdParsed = int.TryParse(itemToEquip, out itemId);
            }

            this.EquipItem(itemId);
            this.UpdateStats();
            this.RefreshInventory();
        }

        private void EquipItem(int itemId)
        {
            try
            {
                this.hero.Inventory.EquipItem(itemId);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                this.consoleWriter.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        private void RefreshInventory()
        {
            this.hero.Inventory.ToString();
        }

        private void Attack(IEnemy questEnemy)
        {
            if (questEnemy == null)
            {
                throw new InvalidEnemyException();
            }

            int heroDamage = this.hero.GetAttackDamage();
            int enemyDamage = questEnemy.GetAttackDamage();

            questEnemy.TakeDamage(heroDamage);
            Console.ForegroundColor = ConsoleColor.Green;
            this.consoleWriter.WriteLine(string.Format(QuestGamePlayControllerConstants.HeroHitEnemy, questEnemy.GetType().Name, heroDamage));

            this.hero.TakeDamage(questEnemy.GetAttackDamage());
            Console.ForegroundColor = ConsoleColor.Red;
            this.consoleWriter.WriteLine(string.Format(QuestGamePlayControllerConstants.EnemyHitHero, questEnemy.GetType().Name, enemyDamage));
            Console.ResetColor();
        }
    }
}
namespace FourFlagsRPG.Models.Models.IO
{
    using Contracts.IO;
    using System;

    using static Utilities.GameConstants;

    public class ConsoleWriter : IWriter
    {
        private int X;
        private int Y;

        public ConsoleWriter()
        {
            Console.Title = ConsoleGameTitle;
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void UpdateStats(string name, string heroType, int health, int strength, int dexterity, int damage, int defence, int level, int experience, string hand, string head, string chest, string glove, string feet)
        {
            this.X = Console.CursorLeft;
            this.Y = Console.CursorTop;

            int maxWindowWidth = Console.LargestWindowWidth;

            Console.SetCursorPosition(maxWindowWidth - 60, 0);
            Console.WriteLine($"{name} - {heroType}");
            Console.SetCursorPosition(maxWindowWidth - 60, 1);
            Console.WriteLine($"Level - {level}");
            Console.SetCursorPosition(maxWindowWidth - 60, 2);
            Console.WriteLine($"EXP - {experience}");
            Console.SetCursorPosition(maxWindowWidth - 60, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health: {health}");
            Console.SetCursorPosition(maxWindowWidth - 60, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Damage: {damage}");
            Console.SetCursorPosition(maxWindowWidth - 60, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"STR: {strength}");
            Console.SetCursorPosition(maxWindowWidth - 60, 6);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"DEF: {defence}");
            Console.SetCursorPosition(maxWindowWidth - 60, 7);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"DEX: {dexterity}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(maxWindowWidth - 60, 8);
            Console.WriteLine(new string('*', 25));
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(maxWindowWidth - 60, 9);
            Console.WriteLine($"Head: {(head == null ? "No item" : head)}");
            Console.SetCursorPosition(maxWindowWidth - 60, 10);
            Console.WriteLine($"Hand: {(hand == null ? "No item" : hand)}");
            Console.SetCursorPosition(maxWindowWidth - 60, 11);
            Console.WriteLine($"Chest: {(chest == null ? "No item" : chest)}");
            Console.SetCursorPosition(maxWindowWidth - 60, 12);
            Console.WriteLine($"Gloves: {(glove == null ? "No item" : glove)}");
            Console.SetCursorPosition(maxWindowWidth - 60, 13);
            Console.WriteLine($"Feet: {(feet == null ? "No item" : feet)}");
            Console.ResetColor();

            Console.SetCursorPosition(this.X, this.Y);
        }

        public void GameOver()
        {
            Environment.Exit(0);
        }
    }
}
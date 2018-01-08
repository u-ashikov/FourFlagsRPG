namespace FourFlagsRPG.Models.IO
{
    using System;
    using System.Collections.Generic;

    public class QuestEncounters
    {
        private const string firstEncounter = "You hear something.. Investigate?";
        private const string secondEncounter = "You see someone in the distance.. Investigate?";
        private const string thirdEncounter = "You hear strange whispers in the air.. Follow them?";
        private const string fourthEncounter = "Something runs behind you.. Fight?";
        private const string fifthEncounter = "You are attacked.. Fight?";

        private IList<string> encounters;

        public QuestEncounters()
        {
            this.encounters = new List<string>()
            {
                firstEncounter,
                secondEncounter,
                thirdEncounter,
                fourthEncounter,
                fifthEncounter
            };
        }

        public string GetEncounter(int id)
        {
            return this.encounters[id];
        }

        public string GetRandom()
        {
            Random rnd = new Random();

            return this.encounters[rnd.Next(0, this.encounters.Count)];
        }
    }
}
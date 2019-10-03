using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        //Properties
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImageName { get; set; }

        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();
        //Methods
        public void AddMonster(int monsterId, int chanceOfEncountering)
        {
            if(MonstersHere.Exists(m => m.MonsterId == monsterId))
            {
                MonstersHere.FirstOrDefault(m => m.MonsterId == monsterId).ChanceOfEncountering = chanceOfEncountering;
            }

            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterId, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
                return null ;
            else
            {
                int randomPercentage = RandomNumberGenerator.NumberBetween(1, 100);

                foreach(MonsterEncounter encounter in MonstersHere)
                {
                    if (randomPercentage <= encounter.ChanceOfEncountering)
                    {
                        return (MonsterFactory.Clone(encounter.MonsterId));
                    }
                }
            }

            return null;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterId { get; set; }
        public int ChanceOfEncountering { get; set; }

        //constructor

        public MonsterEncounter( int monsterId, int chanceOfEncountering )
        {
            MonsterId = monsterId;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    class Player
    { 
        String Name { get; set; }
        String CharacterClass { get; set; }
        int HitPoints { get; set; }
        int ExperiencePoints { get; set; }
        int Level { get; set; }
        int Gold { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        //Properties
        public string ImageName { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }

        //constructor

        public Monster (string name, string imageName, int hitPoints, int maximumHitPoints, 
            int minimumDamaage, int maximumDamage, int rewardExperiencePoints , int rewardGold)
        {
            Name = name;
            ImageName = $"Monsters/{imageName}";
            CurrentHitPoints = hitPoints;
            MaximumHitPoints = maximumHitPoints;
            MinimumDamage = minimumDamaage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            Gold = rewardGold;
        }

    }
}

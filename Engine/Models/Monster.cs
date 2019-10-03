using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;
        //Properties
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int HitPoints
        {
            get { return _hitPoints; }

            set {_hitPoints = value;  OnPropertyChanged(nameof(HitPoints)); }
        }               
        public int MaximumHitPoints { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        //constructor

        public Monster (string name, string imageName, int hitPoints, int maximumHitPoints, 
            int minimumDamaage, int maximumDamage, int rewardExperiencePoints , int rewardGold)
        {
            Name = name;
            ImageName = $"Monsters/{imageName}";
            HitPoints = hitPoints;
            MaximumHitPoints = maximumHitPoints;
            MinimumDamage = minimumDamaage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            Inventory = new ObservableCollection<ItemQuantity>();
        }

    }
}

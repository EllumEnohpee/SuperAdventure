using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int HitPoints
        {
            get { return _hitPoints; }

            private set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
            
               
        public int MaximumHitPoints { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        //constructor

        public Monster (string name, string imageName, int hitPoints, int maximumHitPoints, int rewardExperiencePoints,
            int rewardGold)
        {
            Name = name;
            ImageName = $"Monsters/{imageName}";
            HitPoints = hitPoints;
            MaximumHitPoints = maximumHitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = RewardGold;
            Inventory = new ObservableCollection<ItemQuantity>();
        }

    }
}

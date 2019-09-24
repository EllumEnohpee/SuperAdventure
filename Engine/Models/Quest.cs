using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Quest
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int QuestId { get; set; }
        public List<ItemQuantity> ItemsToComplete { get; set; }
        public List<GameItem> RewardItems { get; set; }
        public int RewardGold { get; set; }
        public int RewardExperiencePoints { get; set; }

        public Quest(String name, String description, int questId, List<ItemQuantity> itemsToComplete, List<GameItem> rewardItems, 
            int rewardGold, int rewardExperiencePoints)
        {
            Name = name;
            Description = description;
            QuestId = questId;
            ItemsToComplete = ItemsToComplete;
            RewardItems = rewardItems;
            RewardGold = rewardGold;
            RewardExperiencePoints = rewardExperiencePoints;
        }

    }
}

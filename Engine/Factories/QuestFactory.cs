using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Factories
{
    public static class QuestFactory
    {
        static List<Quest> Quests { get; set; } = new List<Quest>();

        static QuestFactory()
        {
            Quests.Add(new Quest("Clear the herb garden", "Defeat the snakes in the herbalist's garden", 1, new List<ItemQuantity> { new ItemQuantity(9001, 5) },
                new List<GameItem> { ItemFactory.CreateGameItem(1002) }, 5, 1));
        }

        public static Quest ReturnQuestById(int questId)
        {
            return Quests.Find( quest => quest.QuestId == questId);
        }

    }
}

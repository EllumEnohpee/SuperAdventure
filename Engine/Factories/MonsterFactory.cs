using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster Clone(int monsterId)
        {
            switch(monsterId)
            {
                case 1:
                    Monster Snake = new Monster("Snake", "Snake.png", 4, 4, 1, 2, 5, 1);

                    AddLootItem(Snake, 9001, 25);
                    AddLootItem(Snake, 9002, 75);

                    return Snake;

                case 2:
                    Monster Rat = new Monster("Rat", "Rat.png", 5, 5, 1, 2, 5, 1);

                    AddLootItem(Rat, 9003, 25);
                    AddLootItem(Rat, 9004, 75);

                    return Rat;

                case 3:
                    Monster GiantSpider = new Monster("Giant Spider", "GiantSpider.png", 10, 10, 1, 4, 10, 3);

                    AddLootItem(GiantSpider, 9005, 25);
                    AddLootItem(GiantSpider, 9006, 75);

                    return GiantSpider;

                default:
                    throw new ArgumentException(string.Format("No such MonsterId '{0}' found", monsterId));


            }

            
        }

        private static void AddLootItem(Monster monster, int itemId, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
				monster.Inventory.Add(ItemFactory.CreateGameItem(itemId));
            }
        }
    }
}

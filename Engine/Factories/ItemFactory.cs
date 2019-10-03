using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Engine.Models;
namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardItems;

         static ItemFactory ()
        {
            _standardItems = new List<GameItem>();
            _standardItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
            _standardItems.Add(new GameItem(9001, "Snake Fang", 1));
            _standardItems.Add(new GameItem(9002, "Snakeskin", 2));
            _standardItems.Add(new GameItem(9003, "Rat Tail", 1));
            _standardItems.Add(new GameItem(9004, "Rat Fur", 2));
            _standardItems.Add(new GameItem(9005, "Spider Fang", 1));
            _standardItems.Add(new GameItem(9006, "Spider Silk", 2));
            
        } 

        public static GameItem CreateGameItem(int itemId)
        {
            GameItem standardItem = _standardItems.FirstOrDefault(item => item.ItemId == itemId);
            if (standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();

                }

                return standardItem.Clone();
            }
            return null;
        }
    }
}

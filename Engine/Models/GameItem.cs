using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemId { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }

        public GameItem (int itemId, String name, int price)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemId, Name, Price);
        }
    }
}

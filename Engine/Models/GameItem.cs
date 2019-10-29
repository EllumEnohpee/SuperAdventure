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
		public bool IsUnique { get; internal set; }

		public GameItem (int itemId, String name, int price, bool isUnique = false)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
			IsUnique = isUnique;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemId, Name, Price);
        }
    }
}

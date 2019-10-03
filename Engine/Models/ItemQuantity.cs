using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class ItemQuantity
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public ItemQuantity(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}

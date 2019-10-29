using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int itemId, String name, int price, int minimumDamage, int maximumDamage)
            : base(itemId, name, price, true)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemId, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}

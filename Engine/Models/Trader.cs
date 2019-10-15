using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace Engine.Models
{
	public class Trader
	{
		public String Name { get; set; }
		public ObservableCollection<GameItem> Inventory { get; set; } = new ObservableCollection<GameItem>();

		//constructor

		public Trader(String name)
		{
			Name = name;
			
		}

		//mehtods
		public void AddItemToInventory(GameItem item)
		{
			Inventory.Add(item);
		}
		public void RemoveItemFromInventory(GameItem item)
		{
			Inventory.Remove(item);
		}

	}
}

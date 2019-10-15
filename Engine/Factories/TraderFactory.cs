using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using System.Linq;

namespace Engine.Factories
{
	public static class TraderFactory
	{
		static List<Trader> Traders { get; set; } = new List<Trader>();
		//methods
		static TraderFactory()
		{
			Trader Ted = new Trader("Farmer Ted");
			Ted.AddItemToInventory(ItemFactory.CreateGameItem(1001));
			Trader Susan = new Trader("Susan the Trader");
			Susan.AddItemToInventory(ItemFactory.CreateGameItem(1001));
			Trader Pete = new Trader("Pete the Herbalist");
			Pete.AddItemToInventory(ItemFactory.CreateGameItem(1001));
			Traders.Add(Ted);
			Traders.Add(Susan);
			Traders.Add(Pete);
		}
		public static Trader GetTraderByName(string name)
		{
			return Traders.FirstOrDefault(trader => trader.Name == name);
		}

	}


}

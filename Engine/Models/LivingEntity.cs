using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Engine.Factories;

namespace Engine.Models
{
	public abstract class LivingEntity : BaseNotificationClass
	{
		private String _name;
		private int _currentHitPoints;
		private int _gold;

		//Properties
		public String Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		public int CurrentHitPoints
		{
			get { return _currentHitPoints; }
			set
			{
				_currentHitPoints = value;
				OnPropertyChanged(nameof(CurrentHitPoints));
			}
		}
		public int MaximumHitPoints { get; set; }

		public int Gold
		{
			get { return _gold; }
			set
			{
				_gold = value;
				OnPropertyChanged(nameof(Gold));
			}
		}

		public ObservableCollection<GameItem> Inventory { get; set; } = new ObservableCollection<GameItem>();

		public List<GameItem> Weapons =>
			Inventory.Where(item => item is Weapon).ToList();

		//Constructors
		protected LivingEntity() { }


		//methods

		public void AddItemToInventory(GameItem item)
		{
			Inventory.Add(item);
			OnPropertyChanged(nameof(Weapons));
		}

		public void RemoveItemQuantity(ItemQuantity itemQuantity)
		{
			for (int i = 0; i < itemQuantity.Quantity; i++)
			{
				Inventory.Remove(ItemFactory.CreateGameItem(itemQuantity.ItemId));
			}
			OnPropertyChanged(nameof(Weapons));
		}
		public void RemoveItemFromInventory(GameItem item)
		{
			Inventory.Remove(item);
		}
	}
}

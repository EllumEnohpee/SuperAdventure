using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Engine.Factories;

namespace Engine.Models
{
	public class Player : LivingEntity
	{
		private String _characterClass;
		private int _experiencePoints;
		private int _level;

		//Properties

		public String CharacterClass
		{
			get { return _characterClass; }
			set
			{
				_characterClass = value;
				OnPropertyChanged(nameof(CharacterClass));
			}
		}

		public int ExperiencePoints
		{
			get { return _experiencePoints; }
			set
			{
				_experiencePoints = value;
				OnPropertyChanged(nameof(ExperiencePoints));
			}
		}
		public int Level
		{
			get { return _level; }
			set
			{
				_level = value;
				OnPropertyChanged(nameof(Level));
			}
		}

		public ObservableCollection<QuestStatus> Quests
		{
			get;
			set;
		}

		//constructors

		public Player()
		{
			Quests = new ObservableCollection<QuestStatus>();
		}

		//methods

		public bool HasAllTheseItems(List<ItemQuantity> itemQuantities)
		{
			foreach (ItemQuantity itemQuantity in itemQuantities)
			{
				if (Inventory.Count(i => i.Name == ItemFactory.CreateGameItem(itemQuantity.ItemId).Name) < itemQuantity.Quantity)
					return false;
			}
			return true;
		}
	}


    
}

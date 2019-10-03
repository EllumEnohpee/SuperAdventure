using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Engine.Factories;

namespace Engine.Models
{
    public class Player : BaseNotificationClass
    {
        private String _name;
        private String _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
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
        public String CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
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
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public ObservableCollection<GameItem> Inventory
        {
            get;
            set;
        }

        public List<GameItem> Weapons => 
            Inventory.Where(item => item is Weapon).ToList();

        public ObservableCollection<QuestStatus> Quests
        {
            get;
            set;
        }
       
        //constructors

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        //methods

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);
            OnPropertyChanged(nameof(Weapons));
        }

		public bool HasAllTheseItems(List<ItemQuantity> itemQuantities)
		{			
			foreach(ItemQuantity itemQuantity in itemQuantities)
			{
				if (Inventory.Count(i => i.Name == ItemFactory.CreateGameItem(itemQuantity.ItemId).Name) < itemQuantity.Quantity)
					return false;
			}
			return true;
		}
		public void RemoveItemQuantity(ItemQuantity itemQuantity)
		{
			for(int i = 0; i < itemQuantity.Quantity; i++)
			{
				Inventory.Remove(ItemFactory.CreateGameItem(itemQuantity.ItemId));
			}
		}
    }


    
}

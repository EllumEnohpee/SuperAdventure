using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using Engine.Models;
using Engine.EventArgs;
using Engine;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Monster _currentMonster;
        private Location _currentLocation;
        //Properties
        public Player CurrentPlayer { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToSouth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                GivePlayerQuestAtLocation();
                GetMonsterAtLocation();
            }
        }

        public Monster CurrentMonster
        {
            get
            {
                return _currentMonster;
            }

            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"You see a {CurrentMonster.Name} here!");
                }
            }
        }
        public World CurrentWorld { get; set; }
        public bool HasLocationToNorth => 
            CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
        public bool HasLocationToSouth =>
            CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        public bool HasLocationToEast =>
            CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
        public bool HasLocationToWest =>
            CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
        public bool HasMonster => CurrentMonster != null;
        //Constructors
        public GameSession()
        {            
            //Initialize World
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            //Initialize starting Player 
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Ellum";
            CurrentPlayer.CharacterClass = "Fighter";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.Gold = 1000000;
            
            if(!CurrentPlayer.Weapons.Any())
            {
               CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }
                       
        }

        //Methods
        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        public void GivePlayerQuestAtLocation()
        {
            foreach ( Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.QuestId == quest.QuestId))
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
            }
        }

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

        public void AttackCurrentMonster()
        {
            if(CurrentWeapon == null)
            {
                RaiseMessage("Select a weapon to attack!");
                return;                           
            }

            //Determine damage to monster
            int damageToMonster = 
                RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);
            if (damageToMonster == 0)
            {
                RaiseMessage("Your attack missed!");
            }
            else
            {
                CurrentMonster.HitPoints -= damageToMonster;
                RaiseMessage($"You dealt {damageToMonster} points of damage to the {CurrentMonster.Name}");
            }

            //Is the monster defeated?  Collect rewards
            if(CurrentMonster.HitPoints <= 0)
            {
                RaiseMessage($"You defeated the {CurrentMonster.Name}!");
                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"You received {CurrentMonster.RewardGold} gold.");
                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExperiencePoints;
                RaiseMessage($"You received {CurrentMonster.RewardExperiencePoints} experience points.");
                foreach(ItemQuantity rewardItem in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(rewardItem.ItemId);
                    for (int i = 0; i <  rewardItem.Quantity; i++)
                    {
                        CurrentPlayer.AddItemToInventory(item);
                    }
                    RaiseMessage($"You received {rewardItem.Quantity} {item.Name}s.");
                }
                CurrentMonster = null;
            }
            //If still alive, let the monster fight back
            else
            {
                int damageToPlayer = 
                    RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);
                CurrentPlayer.HitPoints -= damageToPlayer;
                RaiseMessage($"The {CurrentMonster.Name} attacks you for {damageToPlayer} damage!");
            }
            //If player is defeated return to home and heal to maximum
            if(CurrentPlayer.HitPoints <= 0)
            {
                RaiseMessage($"You were defeated by the {CurrentMonster.Name}!");
                CurrentLocation = CurrentWorld.LocationAt(0, -1);
                CurrentPlayer.HitPoints = 10 * CurrentPlayer.Level;
                
            }
        }

    }
}

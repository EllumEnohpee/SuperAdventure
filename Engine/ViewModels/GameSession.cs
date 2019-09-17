using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }
        public World CurrentWorld { get; set; }
        

        //Constructors
        public GameSession()
        {
            //Initialize starting Player info
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Ellum";
            CurrentPlayer.CharacterClass = "Fighter";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.Gold = 1000000;

            //Initialize World
            WorldFactory Factory = new WorldFactory();
            CurrentWorld = Factory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);


            //Initialize starting Location info
            /*
            CurrentLocation = new Location();
            CurrentLocation.XCoordinate = 0;
            CurrentLocation.YCoordinate = 1;
            CurrentLocation.Name = "Home";
            CurrentLocation.Description = "This is your House";
            CurrentLocation.ImageName = "Locations/Home.png";
            */

        }

    }
}

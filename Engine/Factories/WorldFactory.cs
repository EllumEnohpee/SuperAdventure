﻿using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Factories
{
    public static class WorldFactory
    {
        public static World CreateWorld()
        {
            World newWorld = new World();
            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "Locations/FarmFields.png");
            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "Locations/Farmhouse.png");
			newWorld.LocationAt(-1, -1).TraderHere = TraderFactory.GetTraderByName("Farmer Ted");

            newWorld.AddLocation(0, -1, "Home",
                "This is your house",
                "Locations/Home.png");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Susan, the trader.",
                "Locations/Trader.png");
			newWorld.LocationAt(-1, 0).TraderHere = TraderFactory.GetTraderByName("Susan the Trader");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here.",
                "Locations/TownSquare.png");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "Locations/TownGate.png");

            newWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "Locations/SpiderForest.png");
            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "Locations/HerbalistsHut.png");
            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.ReturnQuestById(1));
			newWorld.LocationAt(0, 1).TraderHere = TraderFactory.GetTraderByName("Pete the Herbalist");

            newWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "Locations/HerbalistsGarden.png");
            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}

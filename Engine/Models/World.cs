using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        public void AddLocation(int xCoordinate, int yCoordinate, String name, String description, string imageName)
        {
            Location loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imageName;

            _locations.Add(loc);
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (Location Loc in _locations)
            {
                if (Loc.XCoordinate == xCoordinate && Loc.YCoordinate == yCoordinate)
                    return Loc;
            }
            return null;
        }
    }
}

using System.Runtime.InteropServices;

namespace Engine.models;

public class World
{
    private List<Location> _locations = new List<Location>();

    internal void AddLocation(int xCoord, int yCoord, string name, string description, string imageName)
    {
        Location loc = new Location();
        loc.xCoordinate = xCoord;
        loc.yCoordinate = yCoord;
        loc.name = name;
        loc.description = description;
        loc.imageName = $"/WPFUI;component/images/locations/{imageName}";
        
        _locations.Add(loc);
    }

    public Location LocationAt(int xCoord, int yCoord)
    {
        foreach (Location loc in _locations)
        {
            if (loc.xCoordinate == xCoord && loc.yCoordinate == yCoord)
            {
                return loc;
            }
        }
        return null;
    }
}
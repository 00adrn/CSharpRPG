using System.ComponentModel;

namespace Engine.viewModels;
using Engine.models;
using Engine.factories;

public class GameSession:INotifyPropertyChanged
{
    private Location _currentLocation;
    public Player currentPlayer { get; set; }
    public World currentWorld { get; set; }

    public Location currentLocation
    {
        get { return _currentLocation; }
        set
        {
            _currentLocation = value;
            OnPropertyChanged("currentLocation");
            OnPropertyChanged("hasLocationNorth");
            OnPropertyChanged("hasLocationWest");
            OnPropertyChanged("hasLocationEast");
            OnPropertyChanged("hasLocationSouth");
        }
    }

    public bool hasLocationNorth
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate + 1) != null;
        }
    }
    public bool hasLocationWest
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate - 1, currentLocation.yCoordinate) != null;
        }
    }
    public bool hasLocationEast
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate + 1, currentLocation.yCoordinate) != null;
        }
    }
    public bool hasLocationSouth
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate - 1) != null;
        }
    }

    public GameSession()
    {
        currentPlayer = new Player();
        currentPlayer.name = "Altria";
        currentPlayer.characterClass = "Saber";
        currentPlayer.hitPoints = 100;
        currentPlayer.experiencePoints = 0;
        currentPlayer.level = 1;
        currentPlayer.gold = 100000;
        
        WorldFactory factory = new WorldFactory();
        currentWorld = factory.CreateWorld();

        currentLocation = currentWorld.LocationAt(0, -1);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void MoveDirection(string direction)
    {
        switch (direction)
        {
            case "north":
                currentLocation = currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate+1);
                break;
            case "east":
                currentLocation = currentWorld.LocationAt(currentLocation.xCoordinate+1, currentLocation.yCoordinate);
                break;
            case "south":
                currentLocation = currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate-1);
                break;
            case "west":
                currentLocation = currentWorld.LocationAt(currentLocation.xCoordinate-1, currentLocation.yCoordinate);
                break;
        }
    }
}
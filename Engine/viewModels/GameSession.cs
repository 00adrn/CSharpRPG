namespace Engine.viewModels;
using Engine.models;

public class GameSession
{
    public Player currentPlayer { get; set; }
    public Location currentLocation { get; set; }

    public GameSession()
    {
        currentPlayer = new Player();
        currentPlayer.name = "Arthur";
        currentPlayer.characterClass = "Saber";
        currentPlayer.hitPoints = 100;
        currentPlayer.experiencePoints = 0;
        currentPlayer.level = 1;
        currentPlayer.gold = 100000;
        
        currentLocation = new Location();
        currentLocation.name = "Home";
        currentLocation.xCoordinate = 0;
        currentLocation.yCoordinate = 0;
        currentLocation.description = "Home, sweet home.";
        currentLocation.imageName = "Engine/images/locations/Home.png";
    }
}
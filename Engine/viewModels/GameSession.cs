namespace Engine.viewModels;
using Engine.models;

public class GameSession
{
    public Player currentPlayer { get; set; }

    public GameSession()
    {
        currentPlayer = new Player();
        currentPlayer.name = "Arthur";
        currentPlayer.characterClass = "Saber";
        currentPlayer.hitPoints = 100;
        currentPlayer.experiencePoints = 0;
        currentPlayer.level = 1;
        currentPlayer.gold = 100000;
    }
}
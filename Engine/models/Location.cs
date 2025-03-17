namespace Engine.models;

public class Location
{
    public int xCoordinate { get; set; }
    public int yCoordinate { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string imageName { get; set; }
    public List<Quest> QuestAvailableHere { get; set; } = new List<Quest>();
}
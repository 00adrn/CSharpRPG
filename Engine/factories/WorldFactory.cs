using Engine.models;
namespace Engine.factories;

internal static class WorldFactory
{
    internal static World CreateWorld()
    {
        World newWorld = new World();
        newWorld.AddLocation(0, -1, "Home", "Home, sweet home!", "/WPFUI;component/images/locations/csharptestgamehome.png");
        newWorld.AddLocation(0, 0, "Road1", "Road leadinng to Town1", "null");
        newWorld.AddLocation(0, 1, "Town1", "Town1, home of things!", "null");
        newWorld.AddLocation(1 , 1, "Cave", "Dark, but full of riches!", "null");
        newWorld.AddLocation(2, 1, "Road2", "Road leading to Town2", "null");
        newWorld.AddLocation(3, 1, "Town2", "Town2, home of more things!", "null");
        newWorld.AddLocation(3, 0, "Mountaintops of Something", "Watch your step!", "null");
        newWorld.AddLocation(3, -1, "Wolf's Forest", "Dominion of Wolf and wolves!", "null");
        newWorld.AddLocation(2, -1, "Fields", "Fertile lands with nightly disasters.", "null");
        newWorld.AddLocation(1, -1, "Farmer's Farm", "Home of the Farmer!", "null");
        newWorld.LocationAt(0, 1).QuestAvailableHere.Add(QuestFactory.GetQuestByID(1));
        newWorld.AddLocation(0, 2, "Spider Forest", "Beware of the creepy crawlies.", "/WPFUI;component/images/locations/csharptestgamespiderforest.png");
        newWorld.AddLocation(-1, 0 , "City Gate", "Gate leading to the citadel!", "null");
        newWorld.AddLocation(-2, 0, "City", "Citadel of the things!", "null");
        return newWorld;
    }
}
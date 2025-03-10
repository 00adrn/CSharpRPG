using Engine.models;
namespace Engine.factories;

public static class ItemFactory
{
    private static List<GameItem> _standardGameItems;

    static ItemFactory()
    {
        _standardGameItems = new List<GameItem>();
        
        _standardGameItems.Add(new Weapon(1001, "Wooden Spoon", 1, 1, 2));
        _standardGameItems.Add(new Weapon(1002, "Wooden Sword", 5, 2 , 3));
    }

    public static GameItem CreateGameItem(int itemTypeID)
    {
        foreach (GameItem gameItem in _standardGameItems)
        {
            if (gameItem.itemTypeID == itemTypeID)
            {
                if (gameItem != null)
                {
                    return gameItem.Clone();
                }
            }

            return null;
        }
    }
}
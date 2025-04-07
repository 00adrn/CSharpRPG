using Engine.models;
namespace Engine.factories;

public static class ItemFactory
{
    private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

    static ItemFactory()
    {
        _standardGameItems.Add(new Weapon(1001, "Wooden Spoon", 1, 1, 2));
        _standardGameItems.Add(new Weapon(1002, "Wooden Sword", 5, 2 , 3));
        _standardGameItems.Add(new GameItem(6001, "Wheat", 2));
        _standardGameItems.Add(new GameItem(6002, "Wood", 3));
        _standardGameItems.Add(new GameItem(6003, "Wolf Hide", 5));
        _standardGameItems.Add(new GameItem(6004, "Spider Fang", 4));
    }

    public static GameItem CreateGameItem(int itemTypeID)
    {
        foreach (GameItem gameItem in _standardGameItems)
        {
            if (gameItem.itemTypeID == itemTypeID)
            {
                if (gameItem != null)
                {
                    if (gameItem is Weapon)
                    {
                        return (gameItem as Weapon).Clone();
                    }
                    return gameItem.Clone();
                }
            }
        }
        return null;
    }
    public static Weapon CreateWeapon(int itemTypeID)
    {
        foreach (GameItem gameItem in _standardGameItems)
        {
            if (gameItem is Weapon)
            {
                if (gameItem.itemTypeID == itemTypeID)
                {
                    return (gameItem as Weapon).Clone();
                }
            }
        }
        return null;
    }
}
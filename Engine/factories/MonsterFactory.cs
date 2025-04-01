using Engine.models;

namespace Engine.factories;

public static class MonsterFactory
{
    public static Monster GetMonster(int monsterID)
    {
        switch (monsterID)
        {
            case 1:
                Monster wolf = new Monster("Wolf", "/WPFUI;component/images/monsters/wolf.png", 10, 10, 5, 3, 6, 8);
                AddLootItem(wolf, 6003, 30);
                return wolf;
            case 2:
                Monster spider = new Monster("Spider", "null", 8, 8, 3, 2, 5, 6);
                AddLootItem(spider, 6004, 30);
                return spider;
            default:
                throw new ArgumentException("Invalid monster ID");
        }
    }

    private static void AddLootItem(Monster monster, int itemID, int percentage)
    {
        if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
        {
            monster.inventory.Add(new ItemQuantity(itemID, 1));
        }
    }
    
}
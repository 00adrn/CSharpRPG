using Engine.models;

namespace Engine.factories;

internal static class QuestFactory
{
    private static readonly List<Quest> quests = new List<Quest>();

    static QuestFactory()
    {
        List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
        List<ItemQuantity> rewardItems = new List<ItemQuantity>();
        
        itemsToComplete.Add(new ItemQuantity(6003, 5));
        itemsToComplete.Add(new ItemQuantity(1002, 1));
        
        quests.Add(new Quest(1, "Clear Wolf's Forest", "Defeat all 5 Wolves in Wolf's Forest", itemsToComplete, 25, 10, rewardItems));
    }

    internal static Quest GetQuestByID(int id)
    {
        foreach (Quest quest in quests)
        {
            if (quest.questID == id)  //quests.FirstOrDefault(quest => quest.questID == id); completes the same functionality as this for loop, i just prefer to use a for loop since I am not super familiar with this function's functionality
            {
                return quest;
            }
        }
        return null;
    }
}

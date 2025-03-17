namespace Engine.models;

public class Quest
{
    public int questID { get; set; }
    public string questName { get; set; }
    public string description { get; set; }
    public List<ItemQuantity> itemsToComplete { get; set; }
    
    public int rewardExp {get; set;}
    public int rewardGold {get; set;}
    public List<ItemQuantity> rewardItems { get; set; }

    public Quest(int _questID, string _questName, string _description, List<ItemQuantity> _itemsToComplete,
                 int _rewardExp, int _rewardGold, List<ItemQuantity> _rewardItems)
    {
        questID = _questID;
        questName = _questName;
        description = _description;
        itemsToComplete = _itemsToComplete;
        rewardExp = _rewardExp;
        rewardGold = _rewardGold;
        rewardItems = _rewardItems;
    }
}
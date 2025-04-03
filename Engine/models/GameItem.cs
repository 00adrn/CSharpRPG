namespace Engine.models;

public class GameItem
{
    public int itemTypeID { get; set; }
    public string itemName { get; private set; }
    public int itemPrice { get; private set; }

    public GameItem(int _itemTypeID, string _itemName, int _itemPrice)
    {
        itemTypeID = _itemTypeID;
        itemName = _itemName;
        itemPrice = _itemPrice;
    }

    public GameItem Clone()
    {
        return new GameItem(itemTypeID, itemName, itemPrice);
    }
}
namespace Engine.models;

public class ItemQuantity
{
    public int itemID { get; set; }
    public int quantity { get; set; }

    public ItemQuantity(int _itemID, int _quantity)
    {
        itemID = _itemID;
        quantity = _quantity;
    }
    
}
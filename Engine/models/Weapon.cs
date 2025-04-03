namespace Engine.models;

public class Weapon : GameItem
{
    public int minimumDamage{get; private set;}
    public int maximumDamage{get; private set;}
    public bool isEquipped { get; set; }

    public Weapon(int _itemTypeID, string _itemName, int _itemPrice, int _minimumDamage, int _maximumDamage) 
        : base(_itemTypeID, _itemName, _itemPrice)
    {
        minimumDamage = _minimumDamage;
        maximumDamage = _maximumDamage;
        isEquipped = false;
    }

    public new Weapon Clone()
    {
        return new Weapon(itemTypeID, itemName,  itemPrice,  minimumDamage,  maximumDamage);
    }
}
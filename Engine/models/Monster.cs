using System.Collections.ObjectModel;

namespace Engine.models;

public class Monster : BaseNotification
{
    private int _hitPoints;
    
    public string name { get; private set; }
    public string imageName { get; set; }
    public int maxHitPoints { get; private set; }
    public int rewardExp { get; private set; }
    public int rewardGold { get; private set; }
    public ObservableCollection<ItemQuantity> inventory { get; set; }
    public int hitPoints
    {
        get { return _hitPoints; }
        private set
        {
            _hitPoints = value;
            OnPropertyChanged(nameof(hitPoints));
        }
    }

    public Monster(string _name, string _imageName, int _maxHitPoints,
        int hp, int rewardExp, int rewardGold)
    {
        name = _name;
        imageName = _imageName;
        maxHitPoints = _maxHitPoints;
        hitPoints = hp;
        rewardExp = rewardExp;
        rewardGold = rewardGold;
        inventory = new ObservableCollection<ItemQuantity>();
    }
    
}
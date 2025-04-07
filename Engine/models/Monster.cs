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
        set
        {
            _hitPoints = value;
            OnPropertyChanged(nameof(hitPoints));
        }
    }
    
    public int minDamage { get; set; }
    public int maxDamage { get; set; }
    
    public Monster(string _name, string _imageName, int _maxHitPoints,
        int hp, int _rewardExp, int _rewardGold, int _minDamage, int _maxDamage)
    {
        name = _name;
        imageName = $"/WPFUI;component/images/monsters/{_imageName}";
        maxHitPoints = _maxHitPoints;
        hitPoints = hp;
        rewardExp = _rewardExp;
        rewardGold = _rewardGold;
        minDamage = _minDamage;
        maxDamage = _maxDamage;
        inventory = new ObservableCollection<ItemQuantity>();
    }
    
}
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Engine.models;

public class Player: BaseNotification
{
    private string _name;
    private string _characterClass;
    private int _hitpoints;
    private int _experiencePoints;
    private int _level;
    private int _gold;


    public string name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(name));
        }
    }
    public string characterClass
    {
        get { return _characterClass; }
        set
        {
            _characterClass = value;
            OnPropertyChanged(nameof(characterClass));
        }
    }
    public int hitPoints
    {
        get { return _hitpoints; }
        set
        {
            _hitpoints = value;
            OnPropertyChanged(nameof(hitPoints));
        }
    }
    public int experiencePoints
    {
        get { return _experiencePoints; }
        set
        {
            _experiencePoints = value;
            OnPropertyChanged(nameof(experiencePoints));
        }
    }
    public int level
    {
        get { return _level; }
        set
        {
            _level = value;
            OnPropertyChanged(nameof(level));
        }
    }

    public int gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            OnPropertyChanged(nameof(gold));
        }
    }
    
    public ObservableCollection<GameItem> inventory { get; set; }
    public List<GameItem> weapons => inventory.Where(i => i is Weapon).ToList();
    public List<GameItem> items => inventory.Where(i => i is not Weapon).ToList();
    public ObservableCollection<QuestStatus> quests { get; set; }
    

    public Player()
    {
        inventory = new ObservableCollection<GameItem>();
        quests = new ObservableCollection<QuestStatus>();
    }

    public void AddItemToInventory(GameItem item)
    {
        inventory.Add(item);
        
        OnPropertyChanged(nameof(inventory));
        OnPropertyChanged(nameof(items));
        OnPropertyChanged(nameof(weapons));
    }
    
}
using System.ComponentModel;
namespace Engine.models;

public class Player : INotifyPropertyChanged
{
    private string _name;
    private string _characterClass;
    private int _hitpoints;
    private int _experiencePoints;
    private int _level;
    public int _gold;


    public string name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged("name");
        }
    }

    public string characterClass
    {
        get { return _characterClass; }
        set
        {
            _characterClass = value;
            OnPropertyChanged("characterClass");
        }
    }

    public int hitPoints
    {
        get { return _hitpoints; }
        set
        {
            _hitpoints = value;
            OnPropertyChanged("hitPoints");
        }
    }
    public int experiencePoints
    {
        get { return _experiencePoints; }
        set
        {
            _experiencePoints = value;
            OnPropertyChanged("experiencePoints");
        }
    }
    public int level
    {
        get { return _level; }
        set
        {
            _level = value;
            OnPropertyChanged("level");
        }
    }

    public int gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            OnPropertyChanged("gold");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
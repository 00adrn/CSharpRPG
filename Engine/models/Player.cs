using System.ComponentModel;
namespace Engine.models;

public class Player : INotifyPropertyChanged
{
    private int _experiencePoints;

    public string name { get; set; }
    public string characterClass { get; set; }
    public int hitPoints { get; set; }

    public int experiencePoints
    {
        get { return _experiencePoints; }
        set
        {
            _experiencePoints = value;
            OnPropertyChanged("experiencePoints");
        }
    }
    public int level { get; set; }
    public int gold { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
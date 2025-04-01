using System.ComponentModel;
using System.Linq;
using Engine.EventArgs;

namespace Engine.viewModels;
using Engine.models;
using Engine.factories;

public class GameSession : BaseNotification
{
    public event EventHandler<GameMessageEventArgs> OnMessageRaised; 
    private Location _currentLocation;
    public Player currentPlayer { get; set; }
    public World currentWorld { get; set; }
    private Monster _currentMonster;
    public bool hasMonster => currentMonster != null;
    public Weapon currentWeapon { get; set; }
    public Monster currentMonster
    {
        get { return _currentMonster; }
        set
        {
            _currentMonster = value;
            
            OnPropertyChanged(nameof(currentMonster));
            OnPropertyChanged(nameof(hasMonster));

            if (currentMonster != null)
            {
                RaiseMessage("");
                RaiseMessage($"You see a {currentMonster.name} here!");
            }
        }
    }

    public Location currentLocation
    {
        get { return _currentLocation; }
        set
        {
            _currentLocation = value;
            OnPropertyChanged(nameof(currentLocation));
            OnPropertyChanged(nameof(hasLocationNorth));
            OnPropertyChanged(nameof(hasLocationWest));
            OnPropertyChanged(nameof(hasLocationEast));
            OnPropertyChanged(nameof(hasLocationSouth));

            GivePlayerQuestsAtLocation();
            GetMonsterAtLocation();
        }
    }

    public bool hasLocationNorth
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate + 1) != null;
        }
    }
    public bool hasLocationWest
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate - 1, currentLocation.yCoordinate) != null;
        }
    }
    public bool hasLocationEast
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate + 1, currentLocation.yCoordinate) != null;
        }
    }
    public bool hasLocationSouth
    {
        get
        {
            return currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate - 1) != null;
        }
    }
    public GameSession()
    {
        currentPlayer = new Player {name="Altria", characterClass = "Saber", hitPoints = 100, experiencePoints = 0, gold = 10};

        if (!currentPlayer.weapons.Any())
        {
            currentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
        }
        
        currentWorld = WorldFactory.CreateWorld();
        
        currentLocation = currentWorld.LocationAt(0, -1);
        
    }
    public void MoveDirection(string direction)
    {
        switch (direction)
        {
            case "north":
                if (hasLocationNorth)
                {
                    currentLocation =
                        currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate + 1);
                }
                break;
            case "east":
                if (hasLocationEast)
                {
                    currentLocation =
                        currentWorld.LocationAt(currentLocation.xCoordinate + 1, currentLocation.yCoordinate);
                }
                break;
            case "south":
                if (hasLocationSouth)
                {
                    currentLocation =
                        currentWorld.LocationAt(currentLocation.xCoordinate, currentLocation.yCoordinate - 1);
                }
                break;
            case "west":
                if (hasLocationWest)
                {
                    currentLocation =
                        currentWorld.LocationAt(currentLocation.xCoordinate - 1, currentLocation.yCoordinate);
                }

                break;
        }
    }
    
    private void GivePlayerQuestsAtLocation()
    {
        foreach (Quest quest in currentLocation.QuestsAvailableHere)
        {
            if (!currentPlayer.quests.Any(q => q.playerQuest.questID == quest.questID))
            {
                currentPlayer.quests.Add(new QuestStatus(quest));
            }
        }
    }
    
    private void GetMonsterAtLocation()
    {
        currentMonster = currentLocation.GetMonster();
    }

    public void AttackCurrentMonster()
    {
        if (currentWeapon == null)
        {
            RaiseMessage($"");
            RaiseMessage("Select a weapon before attacking!");
            return;
        }
        int damageDealt = RandomNumberGenerator.NumberBetween(currentWeapon.minimumDamage, currentWeapon.maximumDamage);

        if (damageDealt == 0)
        {
            RaiseMessage($"");
            RaiseMessage($"The {currentMonster.name} dodged the attack!");
        }
        else
        {
            currentMonster.hitPoints -= damageDealt;
            RaiseMessage($"");
            RaiseMessage($"You hit the {currentMonster.name} for {damageDealt} damage!");
        }

        if (currentMonster.hitPoints <= 0)
        {
            RaiseMessage($"The {currentMonster.name} has been defeated!\n" +
                         $"You earned {currentMonster.rewardExp} experience points!\n"
                         + $"You also found {currentMonster.rewardGold} gold.");
            currentPlayer.experiencePoints += currentMonster.rewardExp;
            currentPlayer.gold += currentMonster.rewardGold;
            
            foreach (ItemQuantity loot in currentMonster.inventory)
            {
                GameItem item = ItemFactory.CreateGameItem(loot.itemID);
                currentPlayer.AddItemToInventory(item);
                RaiseMessage($"{loot.quantity} {item.itemName}(s) has been added to your inventory.");
            }
            
            GetMonsterAtLocation();
        }
        else
        {
            int damageRecieved = RandomNumberGenerator.NumberBetween(currentMonster.minDamage, currentMonster.maxDamage);
            if (damageRecieved == 0)
            {
                RaiseMessage($"");
                RaiseMessage($"The {currentMonster.name}'s attack missed!");
            }
            else
            {
                currentPlayer.hitPoints -= damageRecieved;
                RaiseMessage($"");
                RaiseMessage($"The {currentMonster.name} hit you for {damageRecieved} damage!");
            }

            if (currentPlayer.hitPoints <= 0)
            {
                RaiseMessage($"");
                RaiseMessage($"The {currentMonster.name} has defeated you!");

                currentLocation = currentWorld.LocationAt(0, -1);
                currentPlayer.hitPoints = 100;
                RaiseMessage($"");
                RaiseMessage($"");
                RaiseMessage($"A magical force has brought you back home and has healed your wounds...");
            }
        }
        
    }

    private void RaiseMessage(string message)
    {
        OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
    }
}
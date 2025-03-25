using Engine.factories;

namespace Engine.models;

public class Location
{
    public int xCoordinate { get; set; }
    public int yCoordinate { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string imageName { get; set; }
    public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
    public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

    public void AddMonster(int monsterID, int encounterOdds)
    {
        if (MonstersHere.Exists(m => m.monsterID == monsterID))
        {
            MonstersHere.First(m => m.monsterID == monsterID).encounterOdds = encounterOdds;
        }
        else
        {
            MonstersHere.Add(new MonsterEncounter(monsterID, encounterOdds)); 
        }
    }

    public Monster GetMonster()
    {
        if (!MonstersHere.Any())
        {
            return null;
        }
        int totalChances = MonstersHere.Sum(m => m.encounterOdds);
        int randNum = RandomNumberGenerator.NumberBetween(1, totalChances);
        int runningTotal = 0;

        foreach (MonsterEncounter monsterEncounter in MonstersHere)
        {
            runningTotal += monsterEncounter.encounterOdds;

            if (randNum <= runningTotal)
            {
                return MonsterFactory.GetMonster(monsterEncounter.monsterID);
            }
        }
        
        return MonsterFactory.GetMonster(MonstersHere.First().monsterID);
    }
}
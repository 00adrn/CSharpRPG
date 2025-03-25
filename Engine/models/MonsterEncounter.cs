namespace Engine.models;

public class MonsterEncounter
{
    public int monsterID { get; set; }
    public int encounterOdds { get; set; }

    public MonsterEncounter(int _monsterID, int _encounterOdds)
    {
        monsterID = _monsterID;
        encounterOdds = _encounterOdds;
    }
}
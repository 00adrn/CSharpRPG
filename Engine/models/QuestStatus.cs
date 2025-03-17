namespace Engine.models;

public class QuestStatus
{
    public Quest playerQuest { get; set; }
    public bool completed { get; set; }

    public QuestStatus(Quest quest)
    {
        playerQuest = quest;
        completed = false;
    }
}
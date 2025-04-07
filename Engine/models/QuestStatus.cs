namespace Engine.models;

public class QuestStatus
{
    public Quest playerQuest { get; set; }
    public bool completed { get; set; }
    private string _status;
    public string status
    {
        get
        {
            if (completed)
            {
                return "Completed";
            }

            return "IP";
        }
        set
        {
            _status = value;
        }
    }

    public QuestStatus(Quest quest)
    {
        playerQuest = quest;
        completed = false;
    }
}


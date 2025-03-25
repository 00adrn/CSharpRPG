namespace Engine.EventArgs;

public class GameMessageEventArgs : System.EventArgs
{
    public string message {get; set;}

    public GameMessageEventArgs(string _message)
    {
        message = _message;
    }
}
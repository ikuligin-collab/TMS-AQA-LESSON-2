namespace TMS_1;

public class Player
{
    public string Name { get;}
    public int Score {get; set;}
    public Player(string name)
    {
        Name = name;
        Score = 0;
    }
}
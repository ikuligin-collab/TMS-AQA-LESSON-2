namespace TMS_1;

public class Player
{
    public string Name { get; }
    public int Score { get; set; }

    // Пункт 1: Конструктор принимает имя
    public Player(string name)
    {
        Name = name;
        Score = 0;
    }
}
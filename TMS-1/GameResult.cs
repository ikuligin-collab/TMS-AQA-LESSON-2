namespace TMS_1;

public class GameResult
{
    //Объекты ходов и текст результата
    public Move PlayerMove { get; }
    public Move ComputerMove { get; }
    public string ResultMessage { get; }

    public GameResult(Move playerMove, Move computerMove, string resultMessage)
    {
        PlayerMove = playerMove;
        ComputerMove = computerMove;
        ResultMessage = resultMessage;
    }

    // Базовый метод вывода результата
    public void Print()
    {
        Console.WriteLine($"Ход игрока: {PlayerMove.Name} | Ход компьютера: {ComputerMove.Name}");
        Console.WriteLine($"Результат: {ResultMessage}");
        Console.WriteLine(new string('-', 30));
    }

    //Перегруженная версия с номером раунда
    public void Print(int roundNumber)
    {
        Console.WriteLine($"\n=== РАУНД {roundNumber} ===");
        Print(); // Вызываем базовый метод, чтобы не дублировать код
    }
}
namespace TMS_1;

class Game
{
    // Модифик доступа: свойства нужны снаружи, внутренние счётчики скрыты
    public Player HumanPlayer { get; }
    public Player ComputerPlayer { get; }
    
    private int _roundsPlayed = 0;
    private int _roundsToPlay;
    
    public int RoundsToPlay
    {
        get => _roundsToPlay;
        private set
        {
            if (value > 0 && value < 100)
            {
                _roundsToPlay = value;
            }
            else
            {
                _roundsToPlay = 3; // Значение по умолчанию, если что-то пошло не так
            }
        }
    }

    // Пункт 1: Конструктор принимает игроков и количество раундов
    public Game(Player humanPlayer, Player computerPlayer, int roundsToPlay)
    {
        HumanPlayer = humanPlayer;
        ComputerPlayer = computerPlayer;
        RoundsToPlay = roundsToPlay;
    }

    // Пункт 7: Основной игровой цикл
    public void Play()
    {
        Console.WriteLine($"Играют: {HumanPlayer.Name} против {ComputerPlayer.Name}");
        Console.WriteLine($"Игра до {RoundsToPlay} раундов.\n");

        while (_roundsPlayed < RoundsToPlay)
        {
            Move playerMove = ReadFromConsole();

            // Пункт 3: Если ход невалидный, он не засчитывается, раунд не увеличивается
            if (!playerMove.IsValid())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Некорректный ход! Выберите число от 1 до 3.");
                Console.ResetColor();
                continue; // Возвращаемся в начало цикла, не меняя счётчики
            }

            // Ход компьютера генерируется ТОЛЬКО если ход игрока верный
            Move computerMove = GenerateRandom();

            _roundsPlayed++;

            // Пункт 5: Обработка результатов раунда отдельным методом
            GameResult result = ProcessRound(playerMove, computerMove);

            // Пункт 8: Вывод информации после каждого раунда
            result.Print(_roundsPlayed);
            Console.WriteLine($"Текущий счёт: {HumanPlayer.Name} [{HumanPlayer.Score}] : [{ComputerPlayer.Score}] {ComputerPlayer.Name}");
        }

        // Пункт 8: Итоги всей игры после завершения цикла
        PrintFinalResults();
    }

    // Внутренний метод для чтения хода человека (скрыт через private)
    private Move ReadFromConsole()
    {
        Console.WriteLine("\nСделайте ваш ход:");
        Console.WriteLine("1 - Камень");
        Console.WriteLine("2 - Бумага");
        Console.WriteLine("3 - Ножницы");
        Console.Write("Ваш выбор: ");

        int.TryParse(Console.ReadLine(), out int choice);
        return new Move(choice);
    }

    // Внутренний метод для генерации хода компьютера (скрыт через private)
    private Move GenerateRandom()
    {
        Random random = new Random();
        return new Move(random.Next(1, 4)); // генерация от 1 до 3
    }

    // Пункт 5: Метод определяет победителя раунда, начисляет очки и возвращает GameResult
    private GameResult ProcessRound(Move playerMove, Move computerMove)
    {
        string resultMessage;

        if (playerMove.Value == computerMove.Value)
        {
            resultMessage = "Ничья в раунде!";
        }
        // Условия победы игрока (1-Камень бьет 3-Ножницы, 2-Бумага бьет 1-Камень, 3-Ножницы бьют 2-Бумагу)
        else if ((playerMove.Value == 1 && computerMove.Value == 3) ||
                 (playerMove.Value == 2 && computerMove.Value == 1) ||
                 (playerMove.Value == 3 && computerMove.Value == 2))
        {
            HumanPlayer.Score++;
            resultMessage = $"{HumanPlayer.Name} выиграл(а) раунд!";
        }
        else
        {
            ComputerPlayer.Score++;
            resultMessage = $"{ComputerPlayer.Name} выиграл раунд!";
        }

        return new GameResult(playerMove, computerMove, resultMessage);
    }

    // Пункт 8: Печать итогового результата игры
    private void PrintFinalResults()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("===        ИГРА ОКОНЧЕНА      ===");
        Console.WriteLine("=================================");
        Console.WriteLine($"Итоговый счёт: {HumanPlayer.Name} [{HumanPlayer.Score}] : [{ComputerPlayer.Score}] {ComputerPlayer.Name}");

        if (HumanPlayer.Score > ComputerPlayer.Score)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Победитель игры: {HumanPlayer.Name}! Поздравляем!");
        }
        else if (ComputerPlayer.Score > HumanPlayer.Score)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Победитель игры: {ComputerPlayer.Name}!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Общий результат игры: Ничья!");
        }
        Console.ResetColor();
    }
}
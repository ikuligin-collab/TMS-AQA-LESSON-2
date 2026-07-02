namespace TMS_1;


class Game
{
    public Player HumanPlayer { get; private set; }
    public Player ComputerPlayer { get; private set; }
    
    private int _roundsPlayed = 0;
    private int _roundsToPlay;
    
    public int RoundsToPlay
    {
        get { return _roundsToPlay; }
        set
        {
            if (value > 0 && value < 100)
            {
                _roundsToPlay = value;
            }
        }
    }

    public bool UserWon { get; private set; }
    public bool ComputerWon { get; private set; }
    
    // Конструктор, который принимает игроков и количество раундов при создании игры
    public Game(Player humanPlayer, Player computerPlayer, int roundsToPlay)
    {
        HumanPlayer = humanPlayer;
        ComputerPlayer = computerPlayer;
        RoundsToPlay = roundsToPlay; // Используем свойство, чтобы сработала проверка (value > 0 && value < 100)
    }

    public void Play()
    {
        Console.WriteLine($"{HumanPlayer.Name} VS {ComputerPlayer.Name}");
        Console.WriteLine("Сделайте ход");

        UserWon = false;

        do
        {
            Console.WriteLine("1 - Камень");
            Console.WriteLine("2 - Бумага");
            Console.WriteLine("3 - Ножницы");
            Console.WriteLine("0 - Выход");

            _roundsPlayed++;

            var userInput = Console.ReadLine(); // "5"

            int userChoice; // there is no value

            // parse user input = string into int 
            // put result to out result param
            // return if parse was successful

            if (!int.TryParse(userInput, out userChoice) || !(userChoice >= 0 && userChoice <= 3))
            {
                Console.WriteLine(userChoice);
                Console.WriteLine("Invalid input");
                continue;
            }

            if (userChoice == 0)
            {
                return;
            }

            var random = new Random();
            var computerChoice = random.Next(1, 4); // generate random number 1-3

            string userChoiceString;
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Камень");
                    userChoiceString = "Камень";
                    break;
                case 2:
                    userChoiceString = "Бумага";
                    break;
                default:
                    userChoiceString = "Ножницы";
                    break;
            }

            Console.WriteLine($"{HumanPlayer.Name} выбрал/а {userChoiceString}");

            string computerChoiceString = computerChoice switch { 1 => "Rock", 2 => "Paper", _ => "Scissors" };

            Console.WriteLine($"{ComputerPlayer.Name} выбрал {computerChoiceString}");

            if (computerChoice == userChoice)
            {
                Console.WriteLine("Ничья!");
            }
            else if (userChoice == 1 && computerChoice == 3 || userChoice == 2 && computerChoice == 1 ||
                     userChoice == 3 && computerChoice == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{HumanPlayer.Name} выиграл/а раунд");
                UserWon = true;
                Console.ResetColor();
            }
            
        } while (_roundsPlayed < RoundsToPlay);
    }
}
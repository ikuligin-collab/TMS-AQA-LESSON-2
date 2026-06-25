Console.WriteLine("Приветствую тебя в игрк КАМЕНЬ-НОЖНИЦЫ_БУМАГА");
Console.WriteLine("Введите количество раундов, которое хотите сыграть");

// Запрашиваем количество раундов
int roundsCount; // Создаем переменную для хранения количества раундов введённого пользователем


// Создаём цикл для того чтоб при невалидном импуте программа не стопилась
while (true)
{
    Console.WriteLine("Введите количество раундов, которое хотите сыграть:");
    string? input = Console.ReadLine();

    // Конверт сроки в число
    if (int.TryParse(input, out roundsCount) && roundsCount > 0)
    {
        // Если конвертация успешна (и число больше нуля), выходим из цикла
        break;
    }

    // Вывод ошибки
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Ошибка! Пожалуйста, введите целое число больше 0.");
    Console.ResetColor();
}
int currentRound = 0; // Создаем переменную для хранения общего количества раундов
// Выводим 
Console.WriteLine($"Игра начнется! Текущий раунд: {currentRound}  Всего раундов: {roundsCount}");

var userWon = false;

while (userWon == false)
{
    Console.WriteLine("1 - Rock");
    Console.WriteLine("2 - Paper");
    Console.WriteLine("3 - Scissors");
    Console.WriteLine("0 - Exit");
    
    var userInput = Console.ReadLine(); // "5"

    int userChoice;

    // parse user input = string into int 
    // put result to out result param
    // return if parse was successful

    if (!int.TryParse(userInput, out userChoice) || !(userChoice >= 0 && userChoice <= 3))
    {
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
            Console.WriteLine("Rock");
            userChoiceString = "Rock";
            break;
        case 2:
            userChoiceString = "Paper";
            break;
        default:
            userChoiceString = "Scissors";
            break;
    }

    Console.WriteLine($"You chose {userChoiceString}");

    string computerChoiceString = computerChoice switch
    {
        1 => "Rock",
        2 => "Paper",
        _ => "Scissors"
    };

    Console.WriteLine($"Computer chose {computerChoiceString}");

    if (computerChoice == userChoice)
    {
        Console.WriteLine("Draw");
    }
    else if (userChoice == 1 && computerChoice == 3 || userChoice == 2 && computerChoice == 1 ||
             userChoice == 3 && computerChoice == 2)
    {
        Console.WriteLine("You win");
        userWon = true;
    }
    else
    {
        Console.WriteLine("You lose");
    }

    // Ctrl + K + D 
}


//data in C# 
//  int, long 5 10 11
//  float, double, decimal 56.132
//  chars - 'a'
//  strings - "text"
//  bool - true / false
//  class
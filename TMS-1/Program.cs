Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Приветствую тебя в игре КАМЕНЬ-НОЖНИЦЫ-БУМАГА");

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
int countWinsComputer = 0; // Создаем переменную для хранения количества выигранных раундов компьюьера
int countWinsUser = 0; // Создаем переменную для хранения количества выигранных раундов юзера

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Игра начинается!"); // вывод информации о старте игры
Console.ResetColor();
Console.WriteLine($"Текущий раунд: {currentRound + 1}.  Всего раундов: {roundsCount}.");
Console.WriteLine($"Количество ваших побед: {countWinsUser}. Количество побед компьютера: {countWinsComputer}.");

//Тело игры

while ((currentRound < roundsCount))
{
    Console.WriteLine("1 - Камень");
    Console.WriteLine("2 - Бумага");
    Console.WriteLine("3 - Ножницы");
    Console.WriteLine("4 - Колодец");
    Console.WriteLine("0 - Выход");
    
    var userInput = Console.ReadLine(); // "5"

    int userChoice;

    // parse user input = string into int 
    // put result to out result param
    // return if parse was successful

    if (!int.TryParse(userInput, out userChoice) || !(userChoice >= 0 && userChoice <= 4))
    {
        Console.WriteLine("Invalid input");
        continue;
    }

    if (userChoice == 0)
    {
        return;
    }

    var random = new Random();
    var computerChoice = random.Next(1, 5); // generate random number 1-4

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
        case 3 :
            userChoiceString = "Ножницы";
            break;
        default:
            userChoiceString = "Колодец";
            break;
    }

    Console.WriteLine($"Ты выбрал {userChoiceString}");

    string computerChoiceString = computerChoice switch
    {
        1 => "Камень",
        2 => "Бумага",
        3 => "Ножницы",
        _ => "Колодец"
    };

    Console.WriteLine($"Компьютер выбрал {computerChoiceString}");
    
    // Условия ничьи
    if (computerChoice == userChoice) 
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Ничья! Раунд не считается сыгранным!"); // currentRound НЕ увеличиваем, очки НЕ добавляем.
        Console.ResetColor();
        continue; // скипываеь проверку на досрочное завершение раунда
    }
    // Условия победы пользователя
    else if 
        ((userChoice == 1 && computerChoice == 3) || // Камень бьет Ножницы
         (userChoice == 2 && (computerChoice == 1 || computerChoice == 4)) || // Бумага бьет Камень и Колодец
         (userChoice == 3 && computerChoice == 2) || // Ножницы бьют Бумагу
         (userChoice == 4 && (computerChoice == 1 || computerChoice == 3)))   // Колодец бьет Камень и Ножницы
        
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ты выиграл =)");
        Console.ResetColor();
        currentRound++; //  закрываем раунд победой пользователя
        countWinsUser++; // Увеличиваем счётчик побед пользователя
    }
    
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ты проиграл =(");
        Console.ResetColor();
        currentRound++; //  "Засчитываем раунд сыгранным при победе компьтера
        countWinsComputer++; // Увеличиваем счётчик побед компьютера
    }
    // Проверка на досрочное завершение игры
    
    int remainingRounds = roundsCount - currentRound;

    // Проверяем, победил ли компьютер досрочно
    if ((remainingRounds > 0) & (countWinsComputer > countWinsUser + remainingRounds))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Досрочный проигрыш со счетом {countWinsComputer}:{countWinsUser}!");
        Console.ResetColor();
        break; // Выход из цикла
    }

    // Проверяем, победил ли юзер досрочно
    if ((remainingRounds > 0) & (countWinsUser > countWinsComputer + remainingRounds))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Досрочный выигрыш со счетом {countWinsUser}:{countWinsComputer}!");
        Console.ResetColor();
        break; // Выход из цикла
    }
    
    Console.WriteLine($"Текущий счет: Вы {countWinsUser} - {countWinsComputer} Компьютер. Оставшихся раундов: {remainingRounds}\n");

  
}


//data in C# 
//  int, long 5 10 11
//  float, double, decimal 56.132
//  chars - 'a'
//  strings - "text"
//  bool - true / false
//  class
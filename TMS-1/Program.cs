using System.Text;
using TMS_1;
Console.OutputEncoding = Encoding.UTF8; 
Console.InputEncoding = Encoding.UTF8;
Console.WriteLine("=== ДОБРО ПОЖАЛОВАТЬ В ИГРУ ===");

// Ввод имени игрока
Console.Write("Введите ваше имя: ");
string userName = Console.ReadLine();

// Если пользователь ничего не ввел, даем дефолтное имя
if (string.IsNullOrWhiteSpace(userName))
{
    userName = "Игрок";
}

//Console.Write(userName);
// Запрашиваем количество раундов
Console.Write("Сколько раундов хотите сыграть? ");
if (!int.TryParse(Console.ReadLine(), out int rounds) || rounds <= 0 || rounds >= 100)
{
    Console.WriteLine("Некорректный ввод. Установлено стандартное количество раундов: 3");
    rounds = 3;
}

Console.Clear(); // Очищаем консоль перед началом игры

// Создаём объекты игроков
Player human = new Player(userName);
Player computer = new Player("Компьютер");

Game game = new Game(human, computer, rounds);
game.Play();

if (game.UserWon)
{
    Console.WriteLine("You won");
}
else
{
    Console.WriteLine("You lost");
}

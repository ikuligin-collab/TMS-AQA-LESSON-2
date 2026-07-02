using System.Text;
using TMS_1;

Console.OutputEncoding = Encoding.UTF8; 
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("=== ДОБРО ПОЖАЛОВАТЬ В ИГРУ ===");

// Ввод имени игрока
Console.Write("Введите ваше имя: ");
string userName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(userName))
{
    userName = "Игрок";
}

// Запрашиваем количество раундов
Console.Write("Сколько раундов хотите сыграть? ");
if (!int.TryParse(Console.ReadLine(), out int rounds) || rounds <= 0 || rounds >= 100)
{
    Console.WriteLine("Некорректный ввод. Установлено стандартное количество раундов: 3");
    rounds = 3;
}

Console.Clear();

// Создаём объекты игроков
Player human = new Player(userName);
Player computer = new Player("Компьютер");

// Конструирование и запуск игры (всё строго по условию)
Game game = new Game(human, computer, rounds);
game.Play();
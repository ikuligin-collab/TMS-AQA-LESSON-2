namespace TMS_1;

public class Move
{
    public int Value { get; }

    public Move(int value)
    {
        Value = value;
    }

    // Проверка диапазона с параметрами по умолчанию
    public bool IsValid(int min = 1, int max = 3)
    {
        return Value >= min && Value <= max;
    }

    // Name через switch expression
    public string Name => Value switch
    {
        1 => "Камень",
        2 => "Бумага",
        3 => "Ножницы",
        _ => "Неизвестный ход"
    };
}
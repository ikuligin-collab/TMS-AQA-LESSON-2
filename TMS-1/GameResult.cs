namespace TMS_1;

public class GameResult
{
    public string PlayerMove { get; set; }
    public string ComputerMove { get; set; }
    public string ResultMessage { get; set; }

    public GameResult(string playerMove, string computerMove, string resultMessage)
    {
        PlayerMove = playerMove;
        ComputerMove = computerMove;
        ResultMessage = resultMessage;
    }
}
namespace BaseballScoreboard;

public class ScoreboardModel
{
    public int Inning { get; set; } = 1;

    public bool IsTopInning { get; set; } = true;

    public int Team1Score { get; set; } = 0;

    public int Team2Score { get; set; } = 0;

    public bool IsFirstBaseOccupied { get; set; } = false;

    public bool IsSecondBaseOccupied { get; set; } = false;

    public bool IsThirdBaseOccupied { get; set; } = false;
}
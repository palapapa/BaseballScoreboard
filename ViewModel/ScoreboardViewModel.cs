using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BaseballScoreboard;

public class ScoreboardViewModel : INotifyPropertyChanged
{
    private Scoreboard scoreboard { get; set; } = new();

    public int Inning
    {
        get => scoreboard.Inning;
        set
        {
            scoreboard.Inning = value;
            OnPropertyChanged();
        }
    }

    public bool IsTopInning
    {
        get => scoreboard.IsTopInning;
        set
        {
            scoreboard.IsTopInning = value;
            OnPropertyChanged();
        }
    }

    public int Team1Score
    {
        get => scoreboard.Team1Score;
        set
        {
            scoreboard.Team1Score = value;
            OnPropertyChanged();
        }
    }

    public int Team2Score
    {
        get => scoreboard.Team2Score;
        set
        {
            scoreboard.Team2Score = value;
            OnPropertyChanged();
        }
    }

    public ICommand IncreaseInningCounter { get; set; }

    public ICommand DecreaseInningCounter { get; set; }

    public ICommand SetTeamLogoSource { get; set; }

    public ICommand IncreaseTeam1Score { get; set; }

    public ICommand DecreaseTeam1Score { get; set; }

    public ICommand IncreaseTeam2Score { get; set; }

    public ICommand DecreaseTeam2Score { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ScoreboardViewModel()
    {
        IncreaseInningCounter = new RelayCommand(
            (parameter) =>
            {
                if (!IsTopInning)
                {
                    Inning++;
                }
                IsTopInning = !IsTopInning;
            }
        );
        DecreaseInningCounter = new RelayCommand(
            (parameter) =>
            {
                if (IsTopInning)
                {
                    Inning--;
                }
                IsTopInning = !IsTopInning;
            },
            (parameter) => Inning > 1 || (Inning is 1 && !IsTopInning)
        );
        SetTeamLogoSource = new RelayCommand(
            (parameter) =>
            {
                EventHandlerArgPack<DragEventArgs> args = (EventHandlerArgPack<DragEventArgs>)parameter;
                Image image = (Image)args.Sender;
                DragEventArgs e = args.EventArgs;
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    try
                    {
                        image.Source = new BitmapImage(new(path, UriKind.Absolute));
                    }
                    catch (NotSupportedException)
                    {

                    }
                }
            }
        );
        IncreaseTeam1Score = new RelayCommand((parameter) => Team1Score++);
        DecreaseTeam1Score = new RelayCommand((parameter) => Team1Score--, (parameter) => Team1Score > 0);
        IncreaseTeam2Score = new RelayCommand((parameter) => Team2Score++);
        DecreaseTeam2Score = new RelayCommand((parameter) => Team2Score--, (parameter) => Team2Score > 0);
    }
}
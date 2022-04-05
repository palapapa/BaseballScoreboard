using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace BaseballScoreboard;

public partial class ScoreboardView : Window
{
    private readonly ScoreboardViewModel viewModel;
    
    public ScoreboardView()
    {
        InitializeComponent();
        viewModel = (ScoreboardViewModel)DataContext;
    }

    private void TeamLogo_Drop(object sender, DragEventArgs e)
    {
        EventHandlerArgPack<DragEventArgs> args = new(sender, e);
        if (viewModel.SetTeamLogoSource.CanExecute(args))
        {
            viewModel.SetTeamLogoSource.Execute(args);
        }
    }
}

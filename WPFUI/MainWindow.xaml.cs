using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.viewModels;

namespace WPFUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private GameSession _gameSession;
    public MainWindow()
    {
        InitializeComponent();
        _gameSession = new GameSession();
        DataContext = _gameSession;
    }

    private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
    {
        _gameSession.MoveDirection("north");
    }
    private void OnClick_MoveWest(object sender, RoutedEventArgs e)
    {
        _gameSession.MoveDirection("west");
    }
    private void OnClick_MoveEast(object sender, RoutedEventArgs e)
    {
        _gameSession.MoveDirection("east");
    }
    private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
    {
        _gameSession.MoveDirection("south");
    }
    
}
using System.Windows;
using System.Windows.Controls;

namespace PokedexAPI
{
    /// <summary>
    /// Interaction logic for GameInfo.xaml
    /// </summary>
    public partial class GameInfo : Page
    {
        public GameInfo()
        {
            InitializeComponent();
        }
        private void Button_Main_Game_Redirection_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow window = new MainWindow();
            // for some reason there must be instatiation of the ticktaktoe object?
            // Instantiate the MainWindow
            // This creates an instance of the MainWindow class, which serves as
            // the main window of the application.
            // Instantiating the MainWindow allows us to interact with the user
            // interface elements defined in that class.
            // It provides the visual representation of the Tic Tac Toe game to the user.

            //  window.ShowDialog();
            // Show the MainWindow as a dialog
        }

        private void Button_Start_Game_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

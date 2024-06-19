using System.Windows;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        public LandingWindow()
        {
            InitializeComponent();
            // LandingWindow1.Content = new GameInfo();
            //GameInfoButton.Visibility = Visibility.Hidden;

        }


        private void Button_Start_Game_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // LandingWindow1.Content = new MainWindow();
            //    StartGameButton.Visibility = Visibility.Hidden;
            //   GameInfoButton.Visibility = Visibility.Visible;
            MainWindow window = new MainWindow();

            window.ShowDialog();

        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

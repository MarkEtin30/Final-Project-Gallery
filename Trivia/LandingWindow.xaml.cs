using System.Windows;

namespace Trivia
{
    /// <summary>
    /// Interaction logic for LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        public LandingWindow()
        {
            InitializeComponent();


        }
        private void Button_Start_Game_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            MainWindow window = new MainWindow();

            window.ShowDialog();

        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

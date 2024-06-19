using System.Windows;
using Common;
using Final_Project_Gallery.Controls;

namespace Final_Project_Gallery
{

    public partial class MainWindow : Window
    {
        private IProjectMeta[] projects = new IProjectMeta[] {
            new  MemoryGame.Project1(),
            new  PokedexAPI.Project1(),
            new  PongGame.Project1(),
            new  SnakeGame.Project1(),
            new  Trivia.Project1(),
            new  WeatherAPI.Project1()

        };


        public MainWindow()
        {
            InitializeComponent();
            InitializeButtonOfProject();
        }
        private void InitializeButtonOfProject()
        {
            int i = 0;
            foreach (var project in projects)
            {


                ButtonOfProject button1 = new ButtonOfProject(project)


                {
                    Margin = new Thickness(10),
                    Width = 100,
                    Height = 130
                };

                ProjectsPanel1.Children.Add(button1);

            }
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {

            // Example data
            string name = "Mark Etin";
            string email = "godmars20@gmail.com";
            string phone = "054-762-5856";

            // Show the information in a MessageBox
            MessageBox.Show($"Name: {name}\nEmail: {email}\nPhone: {phone}", "Creator Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}

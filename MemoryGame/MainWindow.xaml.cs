using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MemoryGame
{
    public partial class MainWindow : Window
    {


        string[] imagePaths = {
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image1.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image2.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image3.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image4.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image5.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image6.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image1.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image2.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image3.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image4.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image5.jpg",
            "pack://application:,,,/MemoryGame;component/Resources/memory_game_image6.jpg",
        };

        string imageBackPath = "pack://application:,,,/MemoryGame;component/Resources/Color-white.jpeg";

        Button[,] buttons = new Button[3, 4];
        string[,] buttonImagePaths = new string[3, 4];
        bool[,] isFlipped = new bool[3, 4];

        Button firstButton = null;
        Button secondButton = null;


        public MainWindow()
        {

            InitializeComponent();

            //  MainFrame.NavigationService.Navigate(new LandingPage1());

            CreateButtons();
        }

        private void CreateButtons()
        {
            Random random = new Random();

            // Shuffle the image paths
            for (int i = imagePaths.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (imagePaths[i], imagePaths[j]) = (imagePaths[j], imagePaths[i]);
            }

            int index = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    // Create the button and set the back image as its content
                    Button newButton = new Button
                    {
                        Content = new Image
                        {
                            Source = new BitmapImage(new Uri(imageBackPath, UriKind.Absolute)),
                            Width = 150,
                            Height = 100,
                            Margin = new Thickness(10)
                        },
                        Tag = new Tuple<int, int>(row, col) // Store the row and column in the Tag property
                    };

                    // Attach the click event handler
                    newButton.Click += Button_Click;

                    buttons[row, col] = newButton;
                    buttonImagePaths[row, col] = imagePaths[index];
                    isFlipped[row, col] = false;

                    // Set the position of the button in the grid
                    Grid.SetRow(newButton, row);
                    Grid.SetColumn(newButton, col);

                    // Add the button to the grid
                    GameGrid1.Children.Add(newButton);

                    index++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender is Button button) && (secondButton == null))
            {
                var position = (Tuple<int, int>)button.Tag;
                int row = position.Item1;
                int col = position.Item2;

                if (isFlipped[row, col] == false)
                {
                    // Flip the button to show the front image
                    button.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(buttonImagePaths[row, col], UriKind.Absolute)),
                        Width = 150,
                        Height = 100,
                        Margin = new Thickness(10)
                    };

                    isFlipped[row, col] = true;

                    if (firstButton == null)
                    {
                        firstButton = button;
                    }
                    else
                    {
                        secondButton = button;

                        // Check if the two flipped buttons match
                        CheckForMatch();
                    }
                }
            }
        }

        private async void CheckForMatch()
        {
            var firstPosition = (Tuple<int, int>)firstButton.Tag;
            var secondPosition = (Tuple<int, int>)secondButton.Tag;

            if (buttonImagePaths[firstPosition.Item1, firstPosition.Item2] ==
                buttonImagePaths[secondPosition.Item1, secondPosition.Item2])
            {
                // The buttons match, do nothing or add your match logic here
                firstButton = null;
                secondButton = null;
            }
            else
            {
                // The buttons do not match, flip them back after a short delay
                await Task.Delay(1000);

                firstButton.Content = new Image
                {
                    Source = new BitmapImage(new Uri(imageBackPath, UriKind.Absolute)),
                    Width = 150,
                    Height = 100,
                    Margin = new Thickness(10)
                };

                secondButton.Content = new Image
                {
                    Source = new BitmapImage(new Uri(imageBackPath, UriKind.Absolute)),
                    Width = 150,
                    Height = 100,
                    Margin = new Thickness(10)
                };

                isFlipped[firstPosition.Item1, firstPosition.Item2] = false;
                isFlipped[secondPosition.Item1, secondPosition.Item2] = false;

                firstButton = null;
                secondButton = null;
            }
        }

        private void Button_Click_Restart_Game(object sender, RoutedEventArgs e)
        {
            CreateButtons();
        }
    }
}

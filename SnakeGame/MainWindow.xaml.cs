using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Snake;

namespace SnakeGame
{

    public partial class MainWindow : Window
    {


        MainGameState mainGameState;

        private readonly int gridRows = 15;
        private readonly int gridColumns = 15;

        private Image[,] gridImagesGridXAML;


        private readonly Dictionary<SnakeEnumValues, ImageSource> convertGridValueEnumToImageDictionary = new()
        {
            { SnakeEnumValues.Empty, SnakeGameImages.Empty},
            { SnakeEnumValues.Snake, SnakeGameImages.Body},
            { SnakeEnumValues.Food, SnakeGameImages.Food}
        };


        public int gameSpeedLevel;




        public MainWindow()
        {

            InitializeComponent();
            gridImagesGridXAML = SetupGrid();

            mainGameState = new MainGameState();
            GameOverlay.Visibility = Visibility.Visible;
        }

        private Image[,] SetupGrid()
        {


            GameGrid.Rows = gridRows;
            GameGrid.Columns = gridColumns;



            Image[,] gridImages = new Image[gridRows, gridColumns];

            for (int r = 0; r < gridRows; r++)
            {
                for (int c = 0; c < gridRows; c++)
                {
                    Image image1 = new Image
                    {
                        Source = SnakeGameImages.Empty,




                    };
                    gridImages[r, c] = image1; //this will insert image to the grid


                    GameGrid.Children.Add(image1);


                }
            }
            return gridImages;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)

        {


        }

        public void DrawGridXAML()
        {
            ScoreTextBlock.Text = "SCORE: " + mainGameState.score;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    SnakeEnumValues snakeEnumValues1 = mainGameState.arrayOfSnakeEnumValues[i, j];



                    gridImagesGridXAML[j, i].Source = convertGridValueEnumToImageDictionary[snakeEnumValues1];

                }
            }
        }

        private void InitializeGameOnGridXAML()
        {

        }

        public async Task GameLoop()
        {

            int i = 0;
            while (mainGameState.IsGameOver == false)

            {
                await Task.Delay(gameSpeedLevel);
                mainGameState.MoveSnakeInDirection();
                DrawGridXAML();

            }
            GameOverlay.Visibility = Visibility.Visible;

        }




        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {


            if (mainGameState.IsGameOver == true)
            {
                return;
            }


            switch (e.Key)
            {
                case Key.Left:

                    if ((mainGameState.SnakeHeadCurrentDirectionX == 1) && (mainGameState.SnakeHeadCurrentDirectionY == 0))
                    {
                        return;
                    }

                    //{
                    // }
                    //This if check if the previous direction is indded not the opposite, if it is then, 
                    // the move is igonred, inorder to not make the sanke eat itself!


                    mainGameState.SnakeHeadCurrentDirectionX = -1;
                    mainGameState.SnakeHeadCurrentDirectionY = 0;

                    break;

                case Key.Right:

                    if ((mainGameState.SnakeHeadCurrentDirectionX == -1) && (mainGameState.SnakeHeadCurrentDirectionY == 0))
                    {
                        return;
                    }
                    mainGameState.SnakeHeadCurrentDirectionX = 1;
                    mainGameState.SnakeHeadCurrentDirectionY = 0;
                    break;

                case Key.Up:

                    if ((mainGameState.SnakeHeadCurrentDirectionX == 0) && (mainGameState.SnakeHeadCurrentDirectionY == 1))
                    {
                        return;
                    }
                    mainGameState.SnakeHeadCurrentDirectionX = 0;
                    mainGameState.SnakeHeadCurrentDirectionY = -1;

                    break;

                case Key.Down:
                    if ((mainGameState.SnakeHeadCurrentDirectionX == 0) && (mainGameState.SnakeHeadCurrentDirectionY == -1))
                    {
                        return;
                    }
                    mainGameState.SnakeHeadCurrentDirectionX = 0;
                    mainGameState.SnakeHeadCurrentDirectionY = 1;
                    break;
            }
        }


        private async void RestartGameButton_Click_1(object sender, RoutedEventArgs e)
        {
            GameOverlay.Visibility = Visibility.Collapsed;

            this.mainGameState = new MainGameState(); // Reset game state

            // Clear the grid
            for (int r = 0; r < gridRows; r++)
            {
                for (int c = 0; c < gridColumns; c++)
                {
                    gridImagesGridXAML[r, c].Source = SnakeGameImages.Empty;
                }
            }

            DrawGridXAML(); // Redraw the grid
            gameSpeedLevel = 300;
            await GameLoop(); // Restart the game loop
            GameOverlay.Visibility = Visibility.Collapsed;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameOverlay.Visibility = Visibility.Collapsed;

            this.mainGameState = new MainGameState(); // Reset game state

            // Clear the grid
            for (int r = 0; r < gridRows; r++)
            {
                for (int c = 0; c < gridColumns; c++)
                {
                    gridImagesGridXAML[r, c].Source = SnakeGameImages.Empty;
                }
            }

            DrawGridXAML(); // Redraw the grid
            GameLoop(); // Restart the game loop
            GameOverlay.Visibility = Visibility.Collapsed;

        }

        private void EasyGameLevel_Click(object sender, RoutedEventArgs e)
        {
            gameSpeedLevel = 300;
            StartGameButton_Click(this, e);
        }

        private void MediumGameLevel_Click(object sender, RoutedEventArgs e)
        {
            gameSpeedLevel = 200;
            StartGameButton_Click(this, e);
        }

        private void HardGameLevel_Click(object sender, RoutedEventArgs e)
        {
            gameSpeedLevel = 100;
            StartGameButton_Click(this, e);
        }


    }
}
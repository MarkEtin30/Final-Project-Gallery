using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PongGame
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double paddleSpeed = 15; // Speed at which paddles move
        private Rectangle paddle1; // Player 1 paddle
        private Rectangle paddle2; // Player 2 paddle
        private Rectangle ball; // Ball for the game

        private Rectangle dividerRectangle; // Divider rectangle for the game

        private DispatcherTimer gameDispatcherTimer; // Timer to control game loop

        private double ballSpeedX; // Horizontal speed of the ball
        private double ballSpeedY; // Vertical speed of the ball

        Random random1;

        private int player1Score; // Score for Player 1
        public int Player1Score
        {
            get { return player1Score; }
            set
            {
                player1Score = value;
                OnPropertyChanged("Player1Score");
            }
        }

        private int player2Score; // Score for Player 2
        public int Player2Score
        {
            get { return player2Score; }
            set
            {
                player2Score = value;
                OnPropertyChanged("Player2Score");
            }
        }
        List<Rectangle> listOfRectangle1 = new List<Rectangle>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Set the DataContext to this window

            random1 = new Random();


            // Initialize scores
            Player1Score = 0;
            Player2Score = 0;

            // Initialize ball speed
            ballSpeedX = 5;
            ballSpeedY = 5;

            // Create paddles
            paddle1 = CreatePlayerRectangle();
            paddle2 = CreatePlayerRectangle();

            // Create ball
            ball = new Rectangle
            {
                Height = 15,
                Width = 15,
                Fill = Brushes.White
            };

            dividerRectangle = new Rectangle
            {
                Height = 10,
                Width = 5,
                Fill = Brushes.White
            };



            for (int i = 0; i < 100; i++)
            {
                Rectangle dividerRectangle1 = new Rectangle()
                {
                    Height = 10,
                    Width = 5,
                    Fill = Brushes.White
                };
                listOfRectangle1.Add(dividerRectangle1); // Add the rectangle to the list
            }


            // Event handlers
            Loaded += new RoutedEventHandler(WindowLoaded); // Window loaded event
            SizeChanged += new SizeChangedEventHandler(HandleWindowSizeChange); // Window size changed event
            KeyDown += new KeyEventHandler(HandleKeyDown); // Key down event for paddle movement

            // Initialize game timer
            gameDispatcherTimer = new DispatcherTimer();
            gameDispatcherTimer.Interval = TimeSpan.FromMilliseconds(16); // Approximately 60 FPS
            gameDispatcherTimer.Tick += new EventHandler(GameLoop); // Game loop event
            gameDispatcherTimer.Start(); // Start the timer
        }

        // Main game loop
        private void GameLoop(object? sender, EventArgs e)
        {
            // Move the ball
            Canvas.SetLeft(ball, Canvas.GetLeft(ball) + ballSpeedX);
            Canvas.SetTop(ball, Canvas.GetTop(ball) + ballSpeedY);

            // Ball collision with top and bottom walls
            if ((Canvas.GetTop(ball) <= 0) || (Canvas.GetTop(ball) >= GameCanvas.ActualHeight - ball.Height))
            {
                ballSpeedY = -ballSpeedY;
            }

            // Ball collision with paddle 1
            if ((Canvas.GetLeft(ball) <= Canvas.GetLeft(paddle1) + paddle1.Width) &&
                (Canvas.GetLeft(ball) + ball.Width - 5 > Canvas.GetLeft(paddle1) + 4) &&
                (Canvas.GetTop(ball) + ball.Height > Canvas.GetTop(paddle1)) &&
                (Canvas.GetTop(ball) <= Canvas.GetTop(paddle1) + paddle1.Height))
            {
                ballSpeedX = -ballSpeedX;

            }





            // Ball collision with paddle 2
            if ((Canvas.GetLeft(ball) + ball.Width >= Canvas.GetLeft(paddle2)) &&
               (Canvas.GetLeft(ball) + ball.Width - 5 < Canvas.GetLeft(paddle2)) &&
               (Canvas.GetTop(ball) + ball.Height > Canvas.GetTop(paddle2)) &&
               (Canvas.GetTop(ball) <= Canvas.GetTop(paddle2) + paddle2.Height))
            {

                ballSpeedX = ((random1.Next(0, 10) / 10) + 1) * ballSpeedX;
                ballSpeedX = -ballSpeedX;

            }

            // Ball goes out of bounds on the right side
            if ((Canvas.GetLeft(ball) + ball.Width > GameCanvas.ActualWidth))
            {
                ResetBall();
                Player1Score++;
            }

            // Ball goes out of bounds on the left side
            if ((Canvas.GetLeft(ball) <= 0))
            {
                ResetBall();
                Player2Score++;
            }
        }

        // Reset ball to the initial position and speed
        private void ResetBall()
        {
            ballSpeedX = 5;
            ballSpeedY = 5;
            InititalizeStartingGamePositions();
        }

        // Handle window size changes to reset positions
        private void HandleWindowSizeChange(object sender, SizeChangedEventArgs e)
        {
            InititalizeStartingGamePositions();
            PositionScoreTextBlocks(); // Reposition the score texts
        }

        // Initial setup when the window is loaded
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {


            GameCanvas.Children.Add(paddle1); // Add paddle 1 to canvas
            GameCanvas.Children.Add(paddle2); // Add paddle 2 to canvas
            GameCanvas.Children.Add(ball); // Add ball to canvas
            GameCanvas.Children.Add(dividerRectangle); // add dividerRectangle to canvas

            foreach (Rectangle r1 in listOfRectangle1)
            {
                GameCanvas.Children.Add(r1);
            }

            InititalizeStartingGamePositions(); // Initialize positions
        }

        // Handle key down events for paddle movement
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            double p1Top = Canvas.GetTop(paddle1); // Top position of paddle 1
            double p2Top = Canvas.GetTop(paddle2); // Top position of paddle 2

            // Move paddle 1 up
            if (e.Key == Key.W && p1Top > 0)
            {
                Canvas.SetTop(paddle1, p1Top - paddleSpeed);
            }
            // Move paddle 1 down
            if (e.Key == Key.S && p1Top < (GameCanvas.ActualHeight - 1.1 * paddle1.ActualHeight))
            {
                Canvas.SetTop(paddle1, p1Top + paddleSpeed);
            }

            // Move paddle 2 up
            if (e.Key == Key.Up && p2Top > 0)
            {
                Canvas.SetTop(paddle2, p2Top - paddleSpeed);
            }
            // Move paddle 2 down
            if (e.Key == Key.Down && p2Top < (GameCanvas.ActualHeight - 1.1 * paddle1.ActualHeight))
            {
                Canvas.SetTop(paddle2, p2Top + paddleSpeed);
            }
        }

        // Create a rectangle to represent a player paddle
        private Rectangle CreatePlayerRectangle()
        {
            return new Rectangle() { Height = 100, Width = 10, Fill = Brushes.White };
        }

        // Initialize starting positions for paddles and ball
        private void InititalizeStartingGamePositions()
        {
            Canvas.SetLeft(paddle1, 50);
            Canvas.SetTop(paddle1, (GameCanvas.ActualHeight / 2) - (paddle1.Height / 2));

            Canvas.SetLeft(paddle2, GameCanvas.ActualWidth - 50);
            Canvas.SetTop(paddle2, (GameCanvas.ActualHeight / 2) - (paddle2.Height / 2));

            Canvas.SetLeft(ball, GameCanvas.ActualWidth / 2);
            Canvas.SetTop(ball, (GameCanvas.ActualHeight / 2));


            Canvas.SetLeft(dividerRectangle, GameCanvas.ActualWidth / 2);
            Canvas.SetTop(dividerRectangle, 0);
            int i = 1;
            foreach (Rectangle r1 in listOfRectangle1)
            {
                Canvas.SetLeft(r1, GameCanvas.ActualWidth / 2);
                Canvas.SetTop(r1, ((40 * i)));
                i++;
            }


        }

        // Center the score TextBlocks horizontally
        private void PositionScoreTextBlocks()
        {
            // Position Player 1's score
            TextBlock textBlockPlayer1 = scorePlayer1TextBlock; // Get the TextBlock
            Canvas canvas = GameCanvas; // Get the Canvas

            textBlockPlayer1.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity)); // Measure the TextBlock
            double textBlockWidth1 = textBlockPlayer1.DesiredSize.Width; // Get the width of the TextBlock

            double left1 = (canvas.ActualWidth / 4) - (textBlockWidth1 / 2); // Calculate the position for Player 1

            Canvas.SetLeft(textBlockPlayer1, left1); // Set the left position of the TextBlock
            Canvas.SetTop(textBlockPlayer1, 0); // Set the top position of the TextBlock to 0 (top of the Canvas)

            // Position Player 2's score
            TextBlock textBlockPlayer2 = scorePlayer2TextBlock; // Get the TextBlock

            textBlockPlayer2.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity)); // Measure the TextBlock
            double textBlockWidth2 = textBlockPlayer2.DesiredSize.Width; // Get the width of the TextBlock

            double left2 = (3 * canvas.ActualWidth / 4) - (textBlockWidth2 / 2); // Calculate the position for Player 2

            Canvas.SetLeft(textBlockPlayer2, left2); // Set the left position of the TextBlock
            Canvas.SetTop(textBlockPlayer2, 0); // Set the top position of the TextBlock to 0 (top of the Canvas)
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TextBlock_Loaded1(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; // Get the TextBlock
            Canvas canvas = GameCanvas; // Get the Canvas

            textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity)); // Measure the TextBlock
            double textBlockWidth = textBlock.DesiredSize.Width; // Get the width of the TextBlock

            double canvasWidth = canvas.ActualWidth; // Get the width of the Canvas
            double left = ((canvasWidth - textBlockWidth) / 2) - 200; // Calculate the center position

            Canvas.SetLeft(textBlock, left); // Set the position of the TextBlock
            Canvas.SetTop(textBlock, 0); // Top position is 0 for the top of the Canvas
        }


        private void TextBlock_Loaded2(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; // Get the TextBlock
            Canvas canvas = GameCanvas; // Get the Canvas

            textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity)); // Measure the TextBlock
            double textBlockWidth = textBlock.DesiredSize.Width; // Get the width of the TextBlock

            double canvasWidth = canvas.ActualWidth; // Get the width of the Canvas
            double left = ((canvasWidth - textBlockWidth) / 2) + 200; // Calculate the center position

            Canvas.SetLeft(textBlock, left); // Set the position of the TextBlock
            Canvas.SetTop(textBlock, 0); // Top position is 0 for the top of the Canvas
        }
    }
}

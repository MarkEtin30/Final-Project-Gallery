using System.Windows;

namespace SnakeGame
{
    public class MainGameState
    {
        public bool IsGameOver
        {
            get;
            set;
        }


        public int SnakeHeadCurrentDirectionX
        {
            get;
            set;
        }
        public int SnakeHeadCurrentDirectionY
        {
            get;
            set;
        }


        public Random random1;

        public int score;

        public SnakeEnumValues[,] arrayOfSnakeEnumValues;

        public List<SnakeSingleCell> listOfSnakeSingleCell;


        public MainGameState()
        {


            InitializeGame();
        }


        public void InitializeGame()
        {
            arrayOfSnakeEnumValues = new SnakeEnumValues[15, 15];

            listOfSnakeSingleCell = new List<SnakeSingleCell>();


            SnakeHeadCurrentDirectionX = 1;
            SnakeHeadCurrentDirectionY = 0;

            random1 = new Random();

            score = -1;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    arrayOfSnakeEnumValues[i, j] = SnakeEnumValues.Empty; // Initiiallize all the grid to be empty at first!
                }
            } // forech way doesn't work because it only uses copies  of he values and them themselves!!!


            for (int i = 1; i < 4; i++)
            {

                SnakeSingleCell snakeCell1 = new SnakeSingleCell(1, 0) // constructor asks for direction x and y
                {
                    PositionOn2DArrayX = i,
                    PositionOn2DArrayY = arrayOfSnakeEnumValues.GetLength(0) / 2

                };

                arrayOfSnakeEnumValues[i, arrayOfSnakeEnumValues.GetLength(0) / 2] = SnakeEnumValues.Snake;
                // Creates the intialie 3 cell'd new snake in the 2d array of the game


                listOfSnakeSingleCell.Add(snakeCell1); // Creates the intialie 3 cell'd new snake in a seperate List that
                                                       // will hold information on position on each cell!!
            }
            GenerateFood();
        }

        public void MoveSnakeInDirection()
        {



            if ((listOfSnakeSingleCell.Last().PositionOn2DArrayX + SnakeHeadCurrentDirectionX > 14) ||
                (listOfSnakeSingleCell.Last().PositionOn2DArrayX + SnakeHeadCurrentDirectionX < 0) ||
                (listOfSnakeSingleCell.Last().PositionOn2DArrayY + SnakeHeadCurrentDirectionY < 0)
                || (listOfSnakeSingleCell.Last().PositionOn2DArrayY + SnakeHeadCurrentDirectionY > 14))
            {
                IsGameOver = true;
                // MessageBox.Show("Game Over");
                return;
            }

            try
            {
                SnakeSingleCell snakeCell1 =
                    new SnakeSingleCell(listOfSnakeSingleCell.Last().directionX, listOfSnakeSingleCell.Last().directionY)
                    // constructor asks for direction x and y
                    {
                        PositionOn2DArrayX = (listOfSnakeSingleCell.Last().PositionOn2DArrayX +
                        SnakeHeadCurrentDirectionX),

                        PositionOn2DArrayY = (listOfSnakeSingleCell.Last().PositionOn2DArrayY +
                        SnakeHeadCurrentDirectionY)

                    };


                if ((arrayOfSnakeEnumValues[snakeCell1.PositionOn2DArrayX, snakeCell1.PositionOn2DArrayY]
                    == SnakeEnumValues.Snake))
                {
                    IsGameOver = true;
                    //  MessageBox.Show("Game Over");

                    return;
                }


                if (arrayOfSnakeEnumValues[snakeCell1.PositionOn2DArrayX, snakeCell1.PositionOn2DArrayY] == SnakeEnumValues.Food)
                {
                    arrayOfSnakeEnumValues[snakeCell1.PositionOn2DArrayX, snakeCell1.PositionOn2DArrayY] = SnakeEnumValues.Snake;
                    listOfSnakeSingleCell.Add(snakeCell1); // snake in a seperate List that
                                                           // will hold information on position on each cell!!

                    GenerateFood();
                }
                else
                {

                    arrayOfSnakeEnumValues[snakeCell1.PositionOn2DArrayX, snakeCell1.PositionOn2DArrayY] = SnakeEnumValues.Snake;
                    // adds new head snake in the 2d array of the game


                    listOfSnakeSingleCell.Add(snakeCell1); // snake in a seperate List that
                                                           // will hold information on position on each cell!!




                    arrayOfSnakeEnumValues[listOfSnakeSingleCell.First().PositionOn2DArrayX,
                        listOfSnakeSingleCell.First().PositionOn2DArrayY] = SnakeEnumValues.Empty;
                    // remove last tail snake in the 2d array of the game


                    listOfSnakeSingleCell.Remove(listOfSnakeSingleCell.First());// Creates the intialie 3 cell'd new snake in a seperate List that
                                                                                // will hold information on position on each cell!!
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + (listOfSnakeSingleCell.Last().PositionOn2DArrayY));
            }
        }


        public void GenerateFood()
        {
            score++;

            if (listOfSnakeSingleCell.Count == (15 * 15) - 1)// check if the snake is the length of all the cells on the grid
                                                             // if it does than game is over, and the player won!
            {

                IsGameOver = true;
                MessageBox.Show("Congratulations, you won!");
                return;

            }

            // bool flag = false;
            int valueX = random1.Next(0, 15);
            int valueY = random1.Next(0, 15);

            int i = 0;

            while (IsGameOver == false)
            {
                try
                {

                    if (arrayOfSnakeEnumValues[valueX, valueY] == SnakeEnumValues.Empty)
                    {
                        arrayOfSnakeEnumValues[valueX, valueY] = SnakeEnumValues.Food;

                        return;

                    }

                    valueX = random1.Next(0, 15);
                    valueY = random1.Next(0, 15);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " X " + valueX + " Y " + valueY);
                }
            }



        }


    }
}

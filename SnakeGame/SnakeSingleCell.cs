namespace SnakeGame
{
    public class SnakeSingleCell
    // This calss will hold fields with information ion the snake, its X and Y on the main 2d Array!
    {
        public bool isHead;


        public int PositionOn2DArrayX
        {
            get;
            set;
        }

        public int PositionOn2DArrayY
        {
            get;
            set;
        }


        public int directionX
        {
            get;
            set;
        }

        public int directionY
        {
            get;
            set;
        }


        public SnakeSingleCell(int directionX, int directionY)
        {
            isHead = true;
            this.directionX = directionX;

            this.directionY = directionY;
        }



    }
}

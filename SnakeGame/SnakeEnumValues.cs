namespace SnakeGame
{

    public enum SnakeEnumValues


    {
        Empty = 0, // this represents empty values in the grid where the snake can move freely on!

        Snake = 1, // represantion of the snake on the grid, these values will continusly change as the game
                   //progress! 

        Food = 2,  // food that increases the length of the snake

        Outside = 3 // outside the grid
    }
}


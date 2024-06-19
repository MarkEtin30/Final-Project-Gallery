using System.Windows.Media;
using System.Windows.Shapes;

namespace PongGame
{
    public class DividerRectangle
    {

        public Rectangle DividerRectangle1
        {
            get
            {
                return new Rectangle
                {
                    Height = 50,
                    Width = 5,
                    Fill = Brushes.White
                };
            }

        }

    }
}
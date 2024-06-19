using System.Reflection;
using System.Windows.Media.Imaging;
using Common;

namespace SnakeGame
{
    public class Project1 : IProjectMeta
    {
        public string Name { get; set; } = "Snake Game";


        public BitmapImage Icon1
        {
            get
            {

                string? assemblyName1 = Assembly.GetExecutingAssembly().GetName().Name;


                Uri uri1 = new Uri($"pack://application:,,,/{assemblyName1};component" +
                    $"/Resources/Snake_icon.png");




                return new BitmapImage(uri1);

            }
        }


        public void Run()
        {
            LandingWindow window = new LandingWindow();


            window.ShowDialog();
            // Show the MainWindow as a dialog

        }
    }
}

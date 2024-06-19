using System.Windows.Media.Imaging;

namespace Common
{

    public interface IProjectMeta
    {
        public string Name { get; }

        public BitmapImage Icon1 { get; }



        public void Run();


    }
}

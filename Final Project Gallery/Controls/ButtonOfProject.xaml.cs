using System.Windows.Controls;
using Common;

namespace Final_Project_Gallery.Controls

// UserControls are used as for when an outside class is needed in WPF, 
// its, for some reason needed instead of regular class???
//main reason is the UserControil includes User Intterface graphic and reguilar clll
// includes only regular code and logic!!!!!!!!!!!!!!!

//UserControls in WPF are indeed used when you need to encapsulate a reusable
//piece of UI functionality. They allow you to create custom controls with
//associated logic and behavior that can be easily reused across different
//parts of your application.

//The comment appears to express a bit of uncertainty about why UserControls are
//used instead of regular classes.While regular classes can certainly be used in
//WPF applications, UserControls offer several advantages:

//Reusability: UserControls can be easily reused across different parts of your
//application or even in different projects.Once you've defined a UserControl, you
//can simply drop it onto any WPF window or page.
//Encapsulation: UserControls encapsulate both the UI elements and the associated
//logic, making your code more organized and easier to maintain.
//Design-time Support: UserControls provide design-time support in visual designers
//like Visual Studio's XAML designer. This allows you to design the control visually
//and see how it will appear without running the application.
//XAML Integration: UserControls integrate seamlessly with XAML, allowing you to define
//the control's appearance and behavior declaratively.

{
    /// <summary>
    /// Interaction logic for ProjectButtonUserControl.xaml
    /// </summary>
    public partial class ButtonOfProject : UserControl
    {
        public string Text1
        {
            get; set;
        }

        public ButtonOfProject(IProjectMeta project1)
        {
            InitializeComponent();

            DataContext = project1;


            // Text1 = project1.Name; //This will not be shown in the grid because 
            // DataContext is not come from the object class Final_Project_Gallery.Controls
            // but it come from the object class project1!!!

            // Text1 = project1.Name; //This will not be shown in the grid because 
            // DataContext is not come from the object class Final_Project_Gallery.Controls
            // but it come from the object class project1!!!
            //MainProjectButton1.Click += Handle_Click1;


            MainProjectButton1.Click += (sender, e) => project1.Run();


        }
        //private void Handle_Click1(object sender, RoutedEventArgs e1)
        //{

        // }
    }
}

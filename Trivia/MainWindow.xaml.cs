using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Trivia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;

        int usersAnswerChoice = -2;
        int currentQuestionNumber = 0;
        int score = 0;
        string categoryApiAddress = "";

        ListOfTriviaQuestionClassObjects triviaListFromAPI1 = new ListOfTriviaQuestionClassObjects();
        Random random1 = new Random();

        int numberA;
        int numberB;
        int numberC;
        int numberD;

        List<TextBlock> ListOf4OptionsTextBlocks = new List<TextBlock>();


        private Button lastClickedButton = null;


        private HttpClient client1 = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();

            client1.BaseAddress = new Uri(" https://opentdb.com/");


            ListOf4OptionsTextBlocks = new List<TextBlock>
            {
                TextBlockTriviaAnswer1,
                TextBlockTriviaAnswer2,
                TextBlockTriviaAnswer3,
                TextBlockTriviaAnswer4
            };

        }




        private async void Button_Click_Start_New_Trivia_Game(object sender, RoutedEventArgs e)
        {
            StartTriviaGameButton.IsEnabled = false;
            score = 0;
            count = 0;

            TextBlockScore.Text = score + " / 10";

            currentQuestionNumber = 0;

            TextBlockQuestionNumber.Text = "Question Number " + (currentQuestionNumber + 1);


            usersAnswerChoice = -1;



            triviaListFromAPI1 = await GetTriviaQuestionListFromAPIAsync();
            // this line assigns value to triviaListFromAPI1 of triviaListFromAPI1 class instance,
            //  UsersListFromAPI which contains User List that was converted from Json to C# objects!




            ShaffleRandomNumbers();

            TextBlockQuestion1.Text = DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[0].QuestionOfTriviaQuestion);

            ListOf4OptionsTextBlocks[numberA].Text =
                DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[0].IncorrectAnswersOfTriviaQuestion[0]);

            ListOf4OptionsTextBlocks[numberB].Text =
                  DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[0].IncorrectAnswersOfTriviaQuestion[1]);

            ListOf4OptionsTextBlocks[numberC].Text =
                 DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[0].IncorrectAnswersOfTriviaQuestion[2]);


            ListOf4OptionsTextBlocks[numberD].Text =
                 DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[0].CorrectAnswerOfTriviaQuestion);


            List<TriviaQuestionClass> triviaQustionList1 = new List<TriviaQuestionClass>();




            StartTriviaGameButton.IsEnabled = false;

        }


        public void ShaffleRandomNumbers()
        {
            numberA = random1.Next(0, 4);

            numberB = random1.Next(0, 4);

            while (numberB == numberA)
            {
                numberB = random1.Next(0, 4);
            }


            numberC = random1.Next(0, 4);

            while ((numberC == numberA) || (numberC == numberB))
            {
                numberC = random1.Next(0, 3);
            }



            numberD = random1.Next(0, 4);

            while ((numberD == numberA) || (numberD == numberB) || (numberD == numberC))
            {
                numberD = random1.Next(0, 4);
            }

            CategoryScienceButton.IsEnabled = false;
            CategoryHistoryButton.IsEnabled = false;
            GeneralKnowledgeButton.IsEnabled = false;

            StartTriviaGameButton.IsEnabled = false;


            Option1Button.IsEnabled = true;
            Option2Button.IsEnabled = true;
            Option3Button.IsEnabled = true;
            Option4Button.IsEnabled = true;


            SubmitButton.IsEnabled = true;


        }


        private async Task<ListOfTriviaQuestionClassObjects> GetTriviaQuestionListFromAPIAsync()
        {

            HttpResponseMessage response1 =
                await client1.GetAsync(categoryApiAddress);


            response1.EnsureSuccessStatusCode();


            ListOfTriviaQuestionClassObjects data1 = await response1.Content.ReadFromJsonAsync<ListOfTriviaQuestionClassObjects>();


            return data1;
        }






        private void Button_Click_Trivia_Answer1(object sender, RoutedEventArgs e)
        {

            if (usersAnswerChoice == -2)
            {
                MessageBox.Show("Please start the game by clicking the top left button");
                return;
            }
            HighlightButton((Button)sender);

            usersAnswerChoice = 0;
        }

        private void Button_Click_Trivia_Answer2(object sender, RoutedEventArgs e)
        {

            if (usersAnswerChoice == -2)
            {
                MessageBox.Show("Please start the game by clicking the top left button");
                return;
            }

            HighlightButton((Button)sender);

            usersAnswerChoice = 1;

        }

        private void Button_Click_Trivia_Answer3(object sender, RoutedEventArgs e)
        {

            if (usersAnswerChoice == -2)
            {
                MessageBox.Show("Please start the game by clicking the top left button");
                return;
            }

            HighlightButton((Button)sender);


            usersAnswerChoice = 2;

        }

        private void Button_Click_Trivia_Answer4(object sender, RoutedEventArgs e)
        {

            if (usersAnswerChoice == -2)
            {
                MessageBox.Show("Please start the game by clicking the top left button");
                return;
            }

            HighlightButton((Button)sender);

            usersAnswerChoice = 3;
        }


        private void Button_Click_Submit_Selected_Answer(object sender, RoutedEventArgs e)
        {
            try
            {


                count++;





                if (usersAnswerChoice == -2)
                {
                    MessageBox.Show("Please start the game by clicking the top left button");
                    return;
                }

                if (usersAnswerChoice == -1)
                {
                    MessageBox.Show("Please select one of the four optional answers");
                    return;
                }

                if (count > 9)
                {


                    CategoryScienceButton.IsEnabled = true;
                    CategoryHistoryButton.IsEnabled = true;
                    GeneralKnowledgeButton.IsEnabled = true;

                    //StartTriviaGameButton.IsEnabled = false;


                    Option1Button.IsEnabled = false;
                    Option2Button.IsEnabled = false;
                    Option3Button.IsEnabled = false;
                    Option4Button.IsEnabled = false;


                    SubmitButton.IsEnabled = false;
                }


                if ((ListOf4OptionsTextBlocks[usersAnswerChoice].Text) ==
                    triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].CorrectAnswerOfTriviaQuestion)

                {
                    MessageBox.Show("Correct answer");
                    score++;
                    TextBlockScore.Text = score + " / 10";
                }

                else
                {
                    MessageBox.Show($"Incorrect answer, the correct answer is " +
                       triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].CorrectAnswerOfTriviaQuestion);

                }
                currentQuestionNumber++;

                lastClickedButton.ClearValue(Button.BackgroundProperty);


                if (currentQuestionNumber > 9)
                {
                    MessageBox.Show($"Game Over. Your score is: {score} / 10");


                    usersAnswerChoice = -2;
                    return;
                }

                TextBlockQuestionNumber.Text = "Question Number " + (currentQuestionNumber + 1);


                ShaffleRandomNumbers();





                TextBlockQuestion1.Text = DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].QuestionOfTriviaQuestion);

                ListOf4OptionsTextBlocks[numberA].Text =
                   DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].IncorrectAnswersOfTriviaQuestion[0]);

                ListOf4OptionsTextBlocks[numberB].Text =
                    DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].IncorrectAnswersOfTriviaQuestion[1]);

                ListOf4OptionsTextBlocks[numberC].Text =
                   DecodeHtml(triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].IncorrectAnswersOfTriviaQuestion[2]);


                ListOf4OptionsTextBlocks[numberD].Text =
                    triviaListFromAPI1.TriviaQuestionList1[currentQuestionNumber].CorrectAnswerOfTriviaQuestion;


                usersAnswerChoice = -1; // zeros the users choice of answer!
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private string DecodeHtml(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value
                .Replace("&#039;", "'")
                .Replace("&quot;", "\"")
                .Replace("&apos;", "'")
                .Replace("&#039;", "'")  // Include the numeric entity for apostrophe
                .Replace("&amp;", "&")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&ocirc;", "ô")
                .Replace("&rsquo;", "’")
                .Replace("&deg;", "°");
        }


        private void HighlightButton(Button button)
        {
            if (lastClickedButton != null)
            {
                lastClickedButton.ClearValue(Button.BackgroundProperty);
            }
            button.Background = new SolidColorBrush(Colors.Yellow);
            lastClickedButton = button;
        }

        private void CategoryHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            categoryApiAddress = "api.php?amount=100&category=23&difficulty=easy&type=multiple";


            StartTriviaGameButton.IsEnabled = true;

        }

        private void CategoryScienceButton_Click(object sender, RoutedEventArgs e)
        {
            categoryApiAddress = "api.php?amount=10&category=17&type=multiple";

            StartTriviaGameButton.IsEnabled = true;

        }

        private void GeneralKnowledgeButton_Click(object sender, RoutedEventArgs e)
        {
            categoryApiAddress = "api.php?amount=10&category=9&difficulty=easy&type=multiple";

            StartTriviaGameButton.IsEnabled = true;
        }
    }





}
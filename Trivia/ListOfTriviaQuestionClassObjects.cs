using System.Text.Json.Serialization;

namespace Trivia
{
    public class ListOfTriviaQuestionClassObjects

    {

        // In the Property List all the Trivia will be stored!
        [JsonPropertyName("results")]

        public List<TriviaQuestionClass> TriviaQuestionList1 { get; set; }






    }
}

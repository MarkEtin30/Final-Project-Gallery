using System.Text.Json.Serialization;

namespace Trivia
{
    public class TriviaQuestionClass
    {

        // This is a simple one level of getting this field from JSON into C#, and
        // [JsonPropertyName("type")]
        // helps with the conversion!!!
        [JsonPropertyName("type")]
        public string TypeOfTriviaQuestion { get; set; }




        [JsonPropertyName("difficulty")]
        public string DifficultyLevelOfTriviaQuestion { get; set; }



        [JsonPropertyName("category")]
        public string CategoryOfTriviaQuestion { get; set; }




        [JsonPropertyName("question")]
        public string QuestionOfTriviaQuestion { get; set; }




        [JsonPropertyName("correct_answer")]
        public string CorrectAnswerOfTriviaQuestion { get; set; }





        [JsonPropertyName("incorrect_answers")]
        public string[] IncorrectAnswersOfTriviaQuestion { get; set; }


    }

}


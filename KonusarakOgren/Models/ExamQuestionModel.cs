using KonusarakOgren.Infrastructure.Enum;

namespace KonusarakOgren.Models
{
    public class ExamQuestionModel
    {
        public string Content { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public QuestionOptionsType CorrectAnswer { get; set; }
    }
}

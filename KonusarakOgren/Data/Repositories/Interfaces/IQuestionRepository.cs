using KonusarakOgren.Models;

namespace KonusarakOgren.Data.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        QuestionAnswerResponse CheckQuestionAnswer(QuestionAnswerRequest request);
    }
}

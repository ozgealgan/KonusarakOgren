using KonusarakOgren.Data.Entities;
using System.Collections.Generic;

namespace KonusarakOgren.Data.Repositories
{
    public interface IExamRepository
    {
        List<Exam> GetExams();
        Exam GetExam(int examId);
        void CreateExam(Exam exam);
        void DeleteExam(int examId);
    }
}

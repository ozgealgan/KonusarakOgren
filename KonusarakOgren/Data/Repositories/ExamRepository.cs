using System.Collections.Generic;
using System.Linq;
using KonusarakOgren.Data.DataContext;
using KonusarakOgren.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KonusarakOgren.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private DatabaseContext _database;

        public ExamRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void CreateExam(Exam exam)
        {
            _database.Exams.Add(exam);
            _database.SaveChanges();
        }

        public void DeleteExam(int examId)
        {
            var exam = _database.Exams.FirstOrDefault(x => x.Id == examId);
            _database.Exams.Remove(exam);
            _database.SaveChanges();
        }

        public Exam GetExam(int examId)
        {
            return _database.Exams.Include("Questions").
                Include("Questions.Options").
                FirstOrDefault(exam => exam.Id == examId);
        }

        public List<Exam> GetExams()
        {
            return _database.Exams.ToList();
        }


    }
}

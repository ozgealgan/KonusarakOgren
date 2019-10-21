using KonusarakOgren.Infrastructure.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonusarakOgren.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public string QuestionContent { get; set; }
        [ForeignKey("QuestionId")]
        public ICollection<Option> Options { get; set; }

        public Question()
        {
            Options = new List<Option>();
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonusarakOgren.Data.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
        [ForeignKey("ExamId")]
        public ICollection<Question> Questions { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }
    }
}

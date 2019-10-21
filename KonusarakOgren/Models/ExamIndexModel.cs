using KonusarakOgren.Data.Entities;
using System;
using System.Collections.Generic;

namespace KonusarakOgren.Models
{
    public class ExamIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}

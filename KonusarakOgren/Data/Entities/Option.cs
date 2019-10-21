using KonusarakOgren.Infrastructure.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonusarakOgren.Data.Entities
{
    public class Option
    {
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string OptionContent { get; set; }
        public QuestionOptionsType OptionType{ get; set; }
        public bool IsCorrectOption { get; set; }
    }
}

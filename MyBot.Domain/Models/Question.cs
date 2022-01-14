using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot.Domain.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }

    }
}

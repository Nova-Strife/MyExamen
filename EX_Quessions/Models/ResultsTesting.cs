using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EX_Quessions.Models
{
    [Table("ResultsTesting")]
    public class ResultTesting
    {
        public int Id { get; set; }
        [DisplayName("Всего")]
        public int CountQuessions { get; set; }
        [DisplayName("Время")]
        public TimeSpan EllapsedTime { get; set; }
        [DisplayName("Правильных")]
        public int CountCorrectAnswers { get; set; }
        [DisplayName("Правильных(%)")]
        public int PercentageOfCompletion { get; set; }
    }
}

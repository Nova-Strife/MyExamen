using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EX_Quessions.Models
{
    [Table("Report")]
    public class Report
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Дата тестирования")]
        public DateTime DateTesting { get; set; }
        [DisplayName("Результат(%)")]
        public int Result { get; set; }
    }
}

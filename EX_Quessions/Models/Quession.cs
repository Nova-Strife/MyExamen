using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EX_Quessions.Models
{
    [Table("Quessions")]
    public class Quession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
    }
}

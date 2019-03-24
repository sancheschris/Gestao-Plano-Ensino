using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PlanoDeAula
    {
        [Key]
        public int PlanoAulaId { get; set; }
        public string descricao { get; set; }
    }
}

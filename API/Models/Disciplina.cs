using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string nome { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }
    }
}

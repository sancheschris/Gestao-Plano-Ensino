using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CursoDisciplina
    {
        public int CursoDisciplinaId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }
    }
}

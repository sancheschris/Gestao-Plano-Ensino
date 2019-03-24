using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        [ForeignKey("UsuarioId")]
        public Professor Professor_id { get; set; }
        [ForeignKey("CursoDisciplinaId")]
        public CursoDisciplina CursoDisciplina { get; set; }
    }
}

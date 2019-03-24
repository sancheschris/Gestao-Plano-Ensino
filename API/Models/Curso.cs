using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string nome { get; set; }
        [ForeignKey("UsuarioId")]
        public Coordenador Coordenador { get; set; }
    }
}

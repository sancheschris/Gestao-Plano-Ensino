using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Coordenador : Usuario
    {
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
    }
}

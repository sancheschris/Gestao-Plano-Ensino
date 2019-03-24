using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Professor : Usuario
    {
        public string titulacao { get; set; }
        public Turma Turma { get; set; }
    }
}

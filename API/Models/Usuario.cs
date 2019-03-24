using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    //public enum Privilegio { professor, coordenador, adm }

    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        //public Privilegio? Tipo { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Models
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<API.Models.Usuario> Usuario { get; set; }

        public DbSet<API.Models.Administrador> Administrador { get; set; }

        public DbSet<API.Models.Coordenador> Coordenador { get; set; }

        public DbSet<API.Models.Professor> Professor { get; set; }

        public DbSet<API.Models.Curso> Curso { get; set; }

        public DbSet<API.Models.CursoDisciplina> CursoDisciplina { get; set; }

        public DbSet<API.Models.Disciplina> Disciplina { get; set; }

        public DbSet<API.Models.PlanoDeAula> PlanoDeAula { get; set; }

        public DbSet<API.Models.PlanoDeEnsino> PlanoDeEnsino { get; set; }

        public DbSet<API.Models.Turma> Turma { get; set; }
    }
}

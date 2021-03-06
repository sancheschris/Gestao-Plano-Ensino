﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20190324222821_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UsuarioId");

                    b.Property<string>("nome");

                    b.HasKey("CursoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("API.Models.CursoDisciplina", b =>
                {
                    b.Property<int>("CursoDisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoId");

                    b.Property<int?>("DisciplinaId");

                    b.HasKey("CursoDisciplinaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("CursoDisciplina");
                });

            modelBuilder.Entity("API.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProfessorId");

                    b.Property<string>("nome");

                    b.HasKey("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("API.Models.PlanoDeAula", b =>
                {
                    b.Property<int>("PlanoAulaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao");

                    b.HasKey("PlanoAulaId");

                    b.ToTable("PlanoDeAula");
                });

            modelBuilder.Entity("API.Models.PlanoDeEnsino", b =>
                {
                    b.Property<int>("PlanoEnsinoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao");

                    b.HasKey("PlanoEnsinoId");

                    b.ToTable("PlanoDeEnsino");
                });

            modelBuilder.Entity("API.Models.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoDisciplinaId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("TurmaId");

                    b.HasIndex("CursoDisciplinaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[UsuarioId] IS NOT NULL");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("Tipo");

                    b.Property<string>("email");

                    b.Property<string>("nome");

                    b.Property<string>("senha");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("API.Models.Administrador", b =>
                {
                    b.HasBaseType("API.Models.Usuario");


                    b.ToTable("Administrador");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("API.Models.Coordenador", b =>
                {
                    b.HasBaseType("API.Models.Usuario");

                    b.Property<int?>("CursoId");

                    b.HasIndex("CursoId")
                        .IsUnique()
                        .HasFilter("[CursoId] IS NOT NULL");

                    b.ToTable("Coordenador");

                    b.HasDiscriminator().HasValue("Coordenador");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.HasBaseType("API.Models.Usuario");

                    b.Property<string>("titulacao");

                    b.ToTable("Professor");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("API.Models.Curso", b =>
                {
                    b.HasOne("API.Models.Coordenador", "Coordenador")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("API.Models.CursoDisciplina", b =>
                {
                    b.HasOne("API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.HasOne("API.Models.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");
                });

            modelBuilder.Entity("API.Models.Disciplina", b =>
                {
                    b.HasOne("API.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");
                });

            modelBuilder.Entity("API.Models.Turma", b =>
                {
                    b.HasOne("API.Models.CursoDisciplina", "CursoDisciplina")
                        .WithMany()
                        .HasForeignKey("CursoDisciplinaId");

                    b.HasOne("API.Models.Professor", "Professor_id")
                        .WithOne("Turma")
                        .HasForeignKey("API.Models.Turma", "UsuarioId");
                });

            modelBuilder.Entity("API.Models.Coordenador", b =>
                {
                    b.HasOne("API.Models.Curso", "Curso")
                        .WithOne()
                        .HasForeignKey("API.Models.Coordenador", "CursoId");
                });
#pragma warning restore 612, 618
        }
    }
}

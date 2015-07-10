using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Model.Shared
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<animal> animal { get; set; }
        public virtual DbSet<consulta> consulta { get; set; }
        public virtual DbSet<especie> especie { get; set; }
        public virtual DbSet<historico_vacina> historico_vacina { get; set; }
        public virtual DbSet<perfil_acesso> perfil_acesso { get; set; }
        public virtual DbSet<pagamento> pagamento { get; set; }
        public virtual DbSet<raca> raca { get; set; }
        public virtual DbSet<responsavel> responsavel { get; set; }
        public virtual DbSet<tratamento> tratamento { get; set; }
        public virtual DbSet<vacina> vacina { get; set; }
        public virtual DbSet<funcionario> funcionario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<animal>()
                .Property(e => e.nm_animal)
                .IsUnicode(false);

            modelBuilder.Entity<animal>()
                .Property(e => e.cor)
                .IsUnicode(false);

            modelBuilder.Entity<animal>()
                .Property(e => e.peso)
                .IsUnicode(false);

            modelBuilder.Entity<animal>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<animal>()
                .Property(e => e.inf_animal)
                .IsUnicode(false);

            modelBuilder.Entity<animal>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<consulta>()
                .Property(e => e.ds_consulta)
                .IsUnicode(false);

            modelBuilder.Entity<especie>()
                .Property(e => e.nm_especie)
                .IsUnicode(false);

            modelBuilder.Entity<especie>()
                .Property(e => e.st_especie)
                .IsUnicode(false);

            modelBuilder.Entity<especie>()
                .HasMany(e => e.animal)
                .WithOptional(e => e.especie)
                .HasForeignKey(e => e.cd_especie);

            modelBuilder.Entity<pagamento>()
                .Property(e => e.forma_pagamento)
                .IsUnicode(false);

            modelBuilder.Entity<pagamento>()
                .Property(e => e.valor)
                .HasPrecision(19, 4);

            modelBuilder.Entity<perfil_acesso>()
                .Property(e => e.nm_tela)
                .IsFixedLength();

            modelBuilder.Entity<raca>()
                .Property(e => e.nm_raca)
                .IsUnicode(false);

            modelBuilder.Entity<raca>()
                .Property(e => e.st_raca)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.nm_responsavel)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<responsavel>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<tratamento>()
                .Property(e => e.ds_tratamento)
                .IsUnicode(false);

            modelBuilder.Entity<vacina>()
                .Property(e => e.nm_vacina)
                .IsFixedLength();

            modelBuilder.Entity<vacina>()
                .Property(e => e.st_vacina)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.nm_funcionario)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.tipo)
                .IsUnicode(false);
        }
    }
}

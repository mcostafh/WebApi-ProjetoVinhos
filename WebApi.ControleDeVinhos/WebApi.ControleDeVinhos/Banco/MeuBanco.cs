using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.ControleDeVinhos.Models;

namespace WebApi.ControleDeVinhos.Banco
{
    public class MeuBanco : DbContext
    {
        public MeuBanco() : base("BancoDados")
        {

        }

        public DbSet<Vinhos> vinhos { get; set; }

        // fluent API - modelagem do banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vinhos>().HasKey(c => c.Cod_vinho);
            modelBuilder.Entity<Vinhos>().Property(c => c.Nome_vinho).
                IsRequired().
                HasMaxLength(100).
                HasColumnType("varchar");
        }
    }
}
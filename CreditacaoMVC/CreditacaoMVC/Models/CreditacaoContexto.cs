using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CreditacaoMVC.Models
{
    //Nossa classe que representa o Banco de Dados
    public class CreditacaoContexto : DbContext
    {
        public CreditacaoContexto()
            //O nome do Banco de Dados
            : base("CreditacaoDB")
        {
        }

        //Todas as classes que representam as tabelas do seu banco, devem ser inseridas aqui
        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<UnidadeCurricular> UnidadeCurricular { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Autenticacao> Autenticacao { get; set; }

        //Configura o Entity Framework
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove os nomes das tabelas no Plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //So para funcionar no AppHb
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CreditacaoContexto, Migrations.Configuration>());
        }
    }
}
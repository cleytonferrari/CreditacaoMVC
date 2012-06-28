namespace CreditacaoMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CreditacaoMVC.Models.CreditacaoContexto>
    {
        public Configuration()
        {
            //Diz para o Entity Framework automaticamente corrigir as mudanças no Banco de Dados
            AutomaticMigrationsEnabled = true;
            //Diz para o EF que se preciso for, apague meus dados
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CreditacaoMVC.Models.CreditacaoContexto context)
        {
        }
    }
}
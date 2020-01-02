namespace WebApi.ControleDeVinhos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vinhos",
                c => new
                    {
                        Cod_vinho = c.Int(nullable: false, identity: true),
                        Nome_vinho = c.String(nullable: false, maxLength: 100, unicode: false),
                        Idade_vinho = c.Int(nullable: false),
                        Preco_vinho = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Cod_vinho);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vinhos");
        }
    }
}

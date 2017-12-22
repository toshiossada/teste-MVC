namespace PokemonGOCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                        CurrentHave = c.Boolean(nullable: false),
                        PokemonTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PokemonType", t => t.PokemonTypeId, cascadeDelete: true)
                .Index(t => t.PokemonTypeId);
            
            CreateTable(
                "dbo.PokemonType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pokemon", "PokemonTypeId", "dbo.PokemonType");
            DropIndex("dbo.Pokemon", new[] { "PokemonTypeId" });
            DropTable("dbo.PokemonType");
            DropTable("dbo.Pokemon");
        }
    }
}

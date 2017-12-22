namespace PokemonGOCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createpokemontypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PokemonType ([Description]) VALUES ('Água')");
            Sql("INSERT INTO PokemonType ([Description]) VALUES ('Inseto')");
            Sql("INSERT INTO PokemonType ([Description]) VALUES ('Grama')");
            Sql("INSERT INTO PokemonType ([Description]) VALUES ('Fogo')");
            Sql("INSERT INTO PokemonType ([Description]) VALUES ('Pedra')");

        }

        public override void Down()
        {
            Sql("DELETE FROM PokemonType");
        }
    }
}

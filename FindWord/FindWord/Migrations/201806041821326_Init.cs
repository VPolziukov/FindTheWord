namespace FindWord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sentences",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sentence = c.String(),
                        number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sentences");
        }
    }
}

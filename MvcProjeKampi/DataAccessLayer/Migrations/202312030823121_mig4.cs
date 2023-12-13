namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "Status");
            DropColumn("dbo.Contents", "Status");
        }
    }
}

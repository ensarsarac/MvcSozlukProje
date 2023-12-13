namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_create_admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    UserName = c.String(maxLength:50),
                    Password = c.String(maxLength:50),
                    Role = c.String(maxLength:1),
                    
                })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "UserName");
        }
    }
}

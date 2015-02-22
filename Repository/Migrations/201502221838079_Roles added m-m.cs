namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rolesaddedmm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Roles_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Roles_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Roles_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Roles_Id);
            
            DropColumn("dbo.Users", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            DropForeignKey("dbo.UsersRoles", "Roles_Id", "dbo.Roles");
            DropForeignKey("dbo.UsersRoles", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersRoles", new[] { "Roles_Id" });
            DropIndex("dbo.UsersRoles", new[] { "Users_Id" });
            DropTable("dbo.UsersRoles");
            CreateIndex("dbo.Users", "Role_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
        }
    }
}

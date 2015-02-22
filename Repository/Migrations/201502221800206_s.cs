namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersRoles", "Users_UserId", "dbo.Users");
            RenameColumn(table: "dbo.UsersRoles", name: "Users_UserId", newName: "Users_Id");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_Users_UserId", newName: "IX_Users_Id");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.UsersRoles", "Users_Id", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UsersRoles", "Users_Id", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Id");
            AddPrimaryKey("dbo.Users", "UserId");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_Users_Id", newName: "IX_Users_UserId");
            RenameColumn(table: "dbo.UsersRoles", name: "Users_Id", newName: "Users_UserId");
            AddForeignKey("dbo.UsersRoles", "Users_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storedprocedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Users_Insert",
                p => new
                    {
                        FirstName = p.String(),
                        LastName = p.String(),
                        UserName = p.String(),
                        Password = p.String(),
                        Email = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Users]([FirstName], [LastName], [UserName], [Password], [Email])
                      VALUES (@FirstName, @LastName, @UserName, @Password, @Email)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Users]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Users] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Users_Update",
                p => new
                    {
                        Id = p.Int(),
                        FirstName = p.String(),
                        LastName = p.String(),
                        UserName = p.String(),
                        Password = p.String(),
                        Email = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Users]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [UserName] = @UserName, [Password] = @Password, [Email] = @Email
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Users_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Users]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Users_Delete");
            DropStoredProcedure("dbo.Users_Update");
            DropStoredProcedure("dbo.Users_Insert");
        }
    }
}

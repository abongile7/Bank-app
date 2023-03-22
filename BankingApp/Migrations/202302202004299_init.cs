namespace BankingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        Deposit = c.Double(nullable: false),
                        Withdraw = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckingAccts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Balance = c.Double(nullable: false),
                        AccountNo = c.String(nullable: false, maxLength: 10, unicode: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        CheckingAcctId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckingAccts", t => t.CheckingAcctId, cascadeDelete: true)
                .Index(t => t.CheckingAcctId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckingAccts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "CheckingAcctId", "dbo.CheckingAccts");
            DropIndex("dbo.Transactions", new[] { "CheckingAcctId" });
            DropIndex("dbo.CheckingAccts", new[] { "ApplicationUserId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.CheckingAccts");
            DropTable("dbo.BankAccounts");
        }
    }
}

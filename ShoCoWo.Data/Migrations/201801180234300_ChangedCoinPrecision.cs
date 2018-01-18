namespace ShoCoWo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCoinPrecision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Holding", "CryptoHoldingBalance", c => c.Decimal(nullable: false, precision: 16, scale: 8));
            AlterColumn("dbo.HoldingTransaction", "CryptoTransactionAmount", c => c.Decimal(nullable: false, precision: 16, scale: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoldingTransaction", "CryptoTransactionAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Holding", "CryptoHoldingBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

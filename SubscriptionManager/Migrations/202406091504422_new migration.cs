namespace SubscriptionManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscriptions", "amount", c => c.Single(nullable: false));
            AlterColumn("dbo.Subscriptions", "length", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriptions", "length", c => c.String());
            AlterColumn("dbo.Subscriptions", "amount", c => c.Int(nullable: false));
        }
    }
}

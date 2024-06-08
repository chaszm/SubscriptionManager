namespace SubscriptionManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscriptions", "length", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriptions", "length", c => c.DateTime(nullable: false));
        }
    }
}

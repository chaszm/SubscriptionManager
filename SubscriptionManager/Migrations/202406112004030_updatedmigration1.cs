namespace SubscriptionManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "category", c => c.String());
            AddColumn("dbo.Subscriptions", "length", c => c.String());
            AddColumn("dbo.Subscriptions", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "status");
            DropColumn("dbo.Subscriptions", "length");
            DropColumn("dbo.Subscriptions", "category");
        }
    }
}

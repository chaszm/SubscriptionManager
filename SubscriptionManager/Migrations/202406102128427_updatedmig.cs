namespace SubscriptionManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscriptions", "amount", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriptions", "amount", c => c.Single(nullable: false));
        }
    }
}

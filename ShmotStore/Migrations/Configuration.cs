namespace ShmotStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShmotStore.Models.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShmotStore.Models.ShopContext context)
        {
            context.Categories.AddOrUpdate(new Models.Category
            {
                CategoryId = 1,
                Name = "Без категории"
            });
        }
    }
}

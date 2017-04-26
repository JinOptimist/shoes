using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Migrations
{
    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<ShoesContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;

            ContextKey = "Dao.ShoesContext";
        }

        protected override void Seed(ShoesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

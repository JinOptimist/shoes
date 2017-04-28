using Dao.Migrations;
using Dao.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class ShoesContext : DbContext
    {
        public ShoesContext() : base("name=ShoesContext")
        {
            //Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Shoes>();
            modelBuilder.Entity<Shoes>().HasOptional(x => x.Material);
            modelBuilder.Entity<Shoes>().HasOptional(x => x.Group);
            modelBuilder.Entity<Shoes>().HasOptional(x => x.PlaceOfBuying);
            modelBuilder.Entity<Shoes>().HasOptional(x => x.PlaceOfProduce);
            modelBuilder.Entity<Shoes>().HasMany(x => x.Givers);
            modelBuilder.Entity<Shoes>().HasMany(x => x.ConnectedShoes);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<StaticPage>();
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShoesContext, MigrationsConfiguration>());
        }
    }
}

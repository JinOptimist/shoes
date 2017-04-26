using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class ShoesInitializer : DropCreateDatabaseIfModelChanges<ShoesContext>
    {
        protected override void Seed(ShoesContext context)
        {
            context.SaveChanges();
        }
    }
}

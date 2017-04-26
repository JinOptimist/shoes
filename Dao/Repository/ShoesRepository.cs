using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repository
{
    public class ShoesRepository : BaseRepository<Shoes>
    {
        public ShoesRepository(ShoesContext db) : base(db)
        {
        }
    }
}

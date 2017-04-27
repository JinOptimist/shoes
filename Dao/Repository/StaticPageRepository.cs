using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repository
{
    public class StaticPageRepository : BaseRepository<StaticPage>
    {
        public StaticPageRepository(ShoesContext db) : base(db)
        {
        }
    }
}

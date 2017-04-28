using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repository
{
    public class PlaceRepository : BaseRepository<Place>
    {
        public PlaceRepository(ShoesContext db) : base(db)
        {
        }
    }
}

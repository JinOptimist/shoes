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

        public bool IsOldIdUniq(Shoes shoes)
        {
            return Entity.Any(x => x.OldId == shoes.OldId 
                                && x.OldIdLvl2 == shoes.OldIdLvl2 
                                && x.Id != shoes.Id);
        }

        public List<Shoes> GetAll(bool isAuth)
        {
            return Entity.Where(x => x.IsPublic || isAuth).ToList();
        }

        public List<Shoes> GetWithDublicate(long id)
        {
            var shoes = Entity.FirstOrDefault(x => x.Id == id);
            if (shoes == null)
                return null;

            return Entity.Where(x => x.OldId == shoes.OldId).ToList();
        }
    }
}

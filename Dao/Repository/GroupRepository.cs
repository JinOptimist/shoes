using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repository
{
    public class GroupRepository : BaseRepository<Group>
    {
        public GroupRepository(ShoesContext db) : base(db)
        {
        }

        public bool Exists(string name)
        {
            return Entity.Any(x => x.Name == name);
        }

        public override Group Save(Group model)
        {
            if (Exists(model.Name)) {
                throw new Exception("Имя материала должно быть уникальным");
            }

            return base.Save(model);
        }
    }
}

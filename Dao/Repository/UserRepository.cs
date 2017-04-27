using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ShoesContext db) : base(db)
        {
        }

        public override User Save(User model)
        {
            model.Name = model.Name.ToLower();
            model.Password = model.Password.ToLower();
            return base.Save(model);
        }

        public User Login(string name, string password)
        {
            var nameLower = name.ToLower();
            var passwordLower = password.ToLower();
            return Entity.FirstOrDefault(x => x.Name == nameLower
                                            && x.Password == passwordLower);
        }

        public User Login(User user)
        {
            return Login(user.Name, user.Password);
        }

        public bool ExistName(string name)
        {
            var nameLower = name.ToLower();
            return Entity.Any(x => x.Name == nameLower);
        }
    }
}

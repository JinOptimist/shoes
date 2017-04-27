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

        public User Login(string name, string password)
        {
            return Entity.FirstOrDefault(x => x.Name == name && x.Password == password);
        }

        public User Login(User user)
        {
            return Login(user.Name, user.Password);
        }
    }
}

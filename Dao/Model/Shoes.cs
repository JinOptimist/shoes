using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Model
{
    public class Shoes : BaseModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string ImageUrl { get; set; }        
    }
}

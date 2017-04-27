using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Model
{
    public class Shoes : BaseModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public string ImageUrl { get; set; }
        public long? Price { get; set; }
        public bool IsPublic { get; set; }
    }
}

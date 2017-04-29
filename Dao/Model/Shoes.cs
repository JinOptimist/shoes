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
        public int OldId { get; set; }
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Notation { get; set; }
        public string ImageUrl { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DateOfCreating { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DateOfPurchase { get; set; }
        public int NumberOfDuplication { get; set; }
        public bool IsPublic { get; set; }

        public virtual Material Material { get; set; }
        public virtual Group Group { get; set; }
        public virtual Place PlaceOfProduce { get; set; }
        public virtual Place PlaceOfBuying { get; set; }

        public virtual List<Person> Givers { get; set; }
        public virtual List<Shoes> ConnectedShoes { get; set; }
    }
}

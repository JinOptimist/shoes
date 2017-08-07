using Dao.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shoes.Models
{
    public class IndexViewModel
    {
        public IndexViewModel() { }

        public IndexViewModel(IEnumerable<Dao.Model.Shoes> shoes,
                              IEnumerable<Material> materials,
                              IEnumerable<Group> groups,
                              IEnumerable<Place> places,
                              IEnumerable<Person> givers) {
            Shoes = shoes.ToList();
            DropDowns = new ListOfDropDown(materials, groups, places, givers, null);
        }
        

        public List<Dao.Model.Shoes> Shoes { get; set; }

        public ListOfDropDown DropDowns { get; set; }
    }
}
using Dao.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shoes.Models
{
    public class IndexViewModel
    {
        public IndexViewModel() { }

        public IndexViewModel(List<Dao.Model.Shoes> shoes,
                              List<Material> materials,
                              List<Group> groups,
                              List<Place> places,
                              List<Person> givers) {
            Shoes = shoes;
            DropDowns = new ListOfDropDown(materials, groups, places, givers, null);
        }
        

        public List<Dao.Model.Shoes> Shoes { get; set; }

        public ListOfDropDown DropDowns { get; set; }
    }
}
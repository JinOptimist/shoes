using Dao.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

/// <summary>
/// For now, not used
/// </summary>
namespace Shoes.Models
{
    public class MaterialViewModel : Material
    {
        public MaterialViewModel() { }

        public MaterialViewModel(Material material, int countOfShoes)
        {
            Id = material.Id;
            Name = material.Name;
        }

        public int countOfShoes { get; set; }
    }
}
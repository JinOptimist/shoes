using Dao.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shoes.Models
{
    public class ShoesViewModel : Dao.Model.Shoes
    {
        public ShoesViewModel() { }

        public ShoesViewModel(Dao.Model.Shoes shoes, List<Material> materials, List<Group> groups, List<Place> places)
        {
            Id = shoes.Id;
            OldId = shoes.OldId;
            Name = shoes.Name;
            Desc = shoes.Desc;
            Notation = shoes.Notation;
            ImageUrl = shoes.ImageUrl;
            DateOfCreating = shoes.DateOfCreating;
            DateOfPurchase = shoes.DateOfPurchase;
            NumberOfDuplication = shoes.NumberOfDuplication;
            IsPublic = shoes.IsPublic;

            Material = shoes.Material;
            Group = shoes.Group;
            PlaceOfProduce = shoes.PlaceOfProduce;
            PlaceOfBuying = shoes.PlaceOfBuying;

            Givers = shoes.Givers;
            ConnectedShoes = shoes.ConnectedShoes;

            MaterialList = materials?.Select(x=> new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = Material?.Id == x.Id
            }).ToList();
            PlaceList = places?.Select(x => new SelectListItem() {
                Text = x.CountryName,
                Value = x.Id.ToString(),
            }).ToList();
            GroupList = groups?.Select(x => new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = Group?.Id == x.Id
            }).ToList();
        }

        public List<SelectListItem> MaterialList { get; set; }
        public List<SelectListItem> PlaceList { get; set; }
        public List<SelectListItem> GroupList { get; set; }
    }
}
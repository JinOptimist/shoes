using Dao.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shoes.Models
{
    public class ShoesViewModel : Dao.Model.Shoes
    {
        public ShoesViewModel() { }

        public ShoesViewModel(Dao.Model.Shoes shoes,
            List<Material> materials,
            List<Group> groups,
            List<Place> places,
            List<Person> givers)
        {
            Id = shoes.Id;
            OldId = shoes.OldId;
            OldIdLvl2 = shoes.OldIdLvl2;
            Name = shoes.Name;
            Desc = shoes.Desc;
            Width = shoes.Width;
            Height = shoes.Height;
            Notation = shoes.Notation;
            ImageUrl = shoes.ImageUrl;
            DateOfCreating = shoes.DateOfCreating;
            DateOfPurchase = shoes.DateOfPurchase;
            NumberOfDuplication = shoes.NumberOfDuplication;
            IsPublic = shoes.IsPublic;

            Material = shoes.Material;
            Group = shoes.Group;
            Giver = shoes.Giver;
            PlaceOfBuying = shoes.PlaceOfBuying;

            ConnectedShoes = shoes.ConnectedShoes;

            DropDowns = new ListOfDropDown(materials, groups, places, givers, shoes);

            DateOfPurchaseHasFullValue = shoes.DateOfPurchase.HasValue;
            DateOfCreatingHasFullValue = shoes.DateOfCreating.HasValue;
        }

        public ListOfDropDown DropDowns { get; set; }

        public bool DateOfPurchaseHasFullValue { get; set; }
        public bool DateOfCreatingHasFullValue { get; set; }

        public void UpdateModel(Dao.Model.Shoes dbShoes)
        {
            dbShoes.Id = Id;
            dbShoes.OldId = OldId;
            dbShoes.OldIdLvl2 = OldIdLvl2;
            dbShoes.Width = Width;
            dbShoes.Height = Height;
            dbShoes.Name = Name;
            dbShoes.Desc = Desc;
            dbShoes.Notation = Notation;
            dbShoes.ImageUrl = ImageUrl;
            dbShoes.DateOfPurchase = DateOfPurchase;
            dbShoes.YearOfPurchase = YearOfPurchase;
            dbShoes.DateOfCreating = DateOfCreating;
            dbShoes.YearOfCreating = YearOfCreating;            
            dbShoes.NumberOfDuplication = NumberOfDuplication;
            dbShoes.IsPublic = IsPublic;
        }
    }
}
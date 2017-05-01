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
            MaterialId = Material?.Id ?? 0;
            Group = shoes.Group;
            GroupId = Group?.Id ?? 0;
            Giver = shoes.Giver;
            GiverId = Giver?.Id ?? 0;
            PlaceOfBuying = shoes.PlaceOfBuying;
            PlaceOfBuyingId = PlaceOfBuying?.Id ?? 0;
            PlaceOfProduce = shoes.PlaceOfProduce;
            PlaceOfProduceId = PlaceOfProduce?.Id ?? 0;

            Giver = shoes.Giver;
            ConnectedShoes = shoes.ConnectedShoes;

            InitMaterialList(materials);
            InitGroupList(groups);
            InitGiverList(givers);
            InitPlaceList(places);
        }

        public long MaterialId { get; set; }
        public long GroupId { get; set; }
        public long GiverId { get; set; }
        public long PlaceOfBuyingId { get; set; }
        public long PlaceOfProduceId { get; set; }

        public List<SelectListItem> MaterialList { get; set; }
        public List<SelectListItem> PlaceList { get; set; }
        public List<SelectListItem> GroupList { get; set; }
        public List<SelectListItem> GiversList { get; set; }

        public void InitMaterialList(List<Material> materials)
        {
            MaterialList = materials?.Select(x => new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = Material?.Id == x.Id
            }).ToList();
        }

        public void InitGroupList(List<Group> groups)
        {
            GroupList = groups?.Select(x => new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = Group?.Id == x.Id
            }).ToList();
        }

        public void InitGiverList(List<Person> givers)
        {
            GiversList = givers?.Select(x => new SelectListItem() {
                Text = x.LastName + " " + x.FirstName,
                Value = x.Id.ToString(),
                Selected = Giver?.Id == x.Id
            }).ToList();
        }

        public void InitPlaceList(List<Place> places)
        {
            var groups = places.Select(x => x.CountryName).Distinct().Select(
                x => new SelectListGroup {
                    Name = x
                }).ToList();
            PlaceList = places?.Select(x => new SelectListItem() {
                Group = groups.FirstOrDefault(gr => gr.Name == x.CountryName),
                Text = x.CountryName + " " + x.CityName,
                Value = x.Id.ToString()
            }).ToList();
        }

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
            dbShoes.DateOfCreating = DateOfCreating;
            dbShoes.DateOfPurchase = DateOfPurchase;
            dbShoes.NumberOfDuplication = NumberOfDuplication;
            dbShoes.IsPublic = IsPublic;
        }
    }
}
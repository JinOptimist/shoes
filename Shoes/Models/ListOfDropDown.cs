using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shoes.Models
{
    public class ListOfDropDown
    {
        public ListOfDropDown() { }

        public ListOfDropDown(IEnumerable<Material> materials,
                                IEnumerable<Group> groups,
                                IEnumerable<Place> places,
                                IEnumerable<Person> givers,
                                Dao.Model.Shoes shoes)
        {
            MaterialId = shoes?.Material?.Id ?? 0;
            GroupId = shoes?.Group?.Id ?? 0;
            GiverId = shoes?.Giver?.Id ?? 0;
            PlaceOfBuyingId = shoes?.PlaceOfBuying?.Id ?? 0;

            InitMaterialList(materials);
            InitGroupList(groups);
            InitGiverList(givers);
            InitPlaceList(places);

            YearsOfPurchase = GenerateYears(shoes?.YearOfPurchase);
            YearsOfCreating = GenerateYears(shoes?.YearOfCreating);
        }

        public List<SelectListItem> MaterialList { get; set; }
        public List<SelectListItem> GroupList { get; set; }
        public List<SelectListItem> GiversList { get; set; }
        public List<SelectListItem> PlaceOfBuyingList { get; set; }
        public List<SelectListItem> YearsOfPurchase { get; set; }
        public List<SelectListItem> YearsOfCreating { get; set; }

        public long MaterialId { get; set; }
        public long GroupId { get; set; }
        public long GiverId { get; set; }
        public long PlaceOfBuyingId { get; set; }

        public void InitMaterialList(IEnumerable<Material> materials)
        {
            MaterialList = materials?.Select(x => new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = MaterialId == x.Id
            }).ToList();
        }

        public void InitGroupList(IEnumerable<Group> groups)
        {
            GroupList = groups?.Select(x => new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = GroupId == x.Id
            }).ToList();
        }

        public void InitGiverList(IEnumerable<Person> givers)
        {
            GiversList = givers?.Select(x => new SelectListItem() {
                Text = x.LastName + " " + x.FirstName,
                Value = x.Id.ToString(),
                Selected = GiverId == x.Id
            }).ToList();
        }

        public void InitPlaceList(IEnumerable<Place> places)
        {
            var groups = places.Select(x => x.CountryName).Distinct().Select(
                x => new SelectListGroup {
                    Name = x
                }).ToList();
            PlaceOfBuyingList = places?.Select(x => new SelectListItem() {
                Group = groups.FirstOrDefault(gr => gr.Name == x.CountryName),
                Text = x.CountryName + " " + x.CityName,
                Value = x.Id.ToString(),
                Selected = PlaceOfBuyingId == x.Id
            }).ToList();
        }

        private List<SelectListItem> GenerateYears(int? selectedValue)
        {
            var years = new List<SelectListItem>();
            years.Add(new SelectListItem {
                Text = "- Год -",
                Value = string.Empty,
                Selected = selectedValue == null
            });

            for (var i = DateTime.Now.Year; i >= 1700; i--) {
                years.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = selectedValue == i
                });
            }
            return years;
        }
    }
}
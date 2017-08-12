using Dao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shoes.Models
{
    public class ShoesShortViewModel
    {
        public ShoesShortViewModel() { }

        public ShoesShortViewModel(Dao.Model.Shoes shoes)
        {
            Id = shoes.Id;
            OldId = shoes.OldId;
            OldIdLvl2 = shoes.OldIdLvl2;
            Name = shoes.Name;
            Desc = shoes.Desc;
            Width = shoes.Width;
            Height = shoes.Height;
            ImageUrl = shoes.ImageUrl;
            DateOfCreating = shoes.DateOfCreating;
            DateOfPurchase = shoes.DateOfPurchase;
            NumberOfDuplication = shoes.NumberOfDuplication;

            Material = shoes.Material.Name;
            Group = shoes.Group.Name;
            Giver = shoes.Giver.ToString();
            PlaceOfBuying = shoes.PlaceOfBuying.ToString();

        }

        public long Id { get; set; }
        public int OldId { get; set; }
        public int OldIdLvl2 { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string ImageUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public DateTime? DateOfCreating { get; set; }
        public int? YearOfCreating { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public int? YearOfPurchase { get; set; }

        public int NumberOfDuplication { get; set; }

        public string Material { get; set; }
        public string Group { get; set; }
        public string PlaceOfBuying { get; set; }
        public string Giver { get; set; }
    }
}
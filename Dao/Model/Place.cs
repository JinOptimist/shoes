﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Model
{
    public class Place : BaseModel
    {
        public string CountryName { get; set; }
        public string CityName { get; set; }

        public override string ToString()
        {
            return CountryName 
                + (string.IsNullOrWhiteSpace(CityName) ? "" : " " )
                + CityName;
        }
    }
}

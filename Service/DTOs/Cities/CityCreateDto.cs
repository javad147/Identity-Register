﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Cities
{
    public class CityCreateDto
    {
        public string Name { get; set; }
        public string Population { get; set; }
        public int CountryId { get; set; }
    }
}

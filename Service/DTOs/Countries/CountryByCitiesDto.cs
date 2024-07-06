using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Countries
{
    public class CountryByCitiesDto
    {
        public string Name { get; set; }
        public List<string> Cities { get; set; }
    }
}

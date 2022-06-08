using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Models
{
    public class OfficesModel
    {
        public OfficesModel()
        {
            Id = 0;
            Country = new CountriesModel();
            Title = string.Empty;
            Phone = string.Empty;
            Contact = string.Empty;
        }

        public int Id { get; set; }
        public CountriesModel Country { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
    }
}

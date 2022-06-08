using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Models
{
    public class RolesModel
    {
        public RolesModel()
        {
            Id = 0;
            Title = string.Empty;
        }

        public int Id { get; set; }
        public string Title { get; set; }    
    }
}

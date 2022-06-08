using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Models
{
   public class UserViewModel
    {
        public UserViewModel()
        {
            Id = 0;
            Role = string.Empty;
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Office = string.Empty;
            Age = 0;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Office { get; set; }
    }
}

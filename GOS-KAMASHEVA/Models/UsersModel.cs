using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Models
{
    public class UsersModel
    {
        public UsersModel()
        {
            Id = 0;
            Role = new RolesModel();
            Email = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Office = new OfficesModel();
            BirthDate = DateTime.MinValue;
            Active = false;
        }

        public int Id { get; set; }
        public RolesModel Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public OfficesModel Office { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}

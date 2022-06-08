using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Models
{
    public class UsersLoginModel
    {
        public UsersLoginModel()
        {
            Id = 0;
            UserId = 0;
            DateLogin = DateTime.MinValue;
            DateLogout = DateTime.MinValue;          
            IsSuccesful = true;
            Reason = string.Empty;
        }
        public int Id { get; set; }
        public int UserId { get; set;}
        public DateTime DateLogin { get; set; }
        public DateTime DateLogout { get; set; }
        public bool IsSuccesful { get; set; }
        public string Reason { get; set; }
    }
}

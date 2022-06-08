using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Models
{
   public class UserLoginsViewModel
    {
        public UserLoginsViewModel()
        {
            Date = string.Empty;
            TimeLogin = string.Empty;
            TimeLogout = string.Empty;
            TimeSpent = string.Empty;
            Reason = string.Empty;
        }
        public string Date { get; set; }
        public string TimeLogin { get; set; }
        public string TimeLogout { get; set; }
        public string TimeSpent { get; set; }
        public string Reason { get; set; }
    }
}

using GOS_KAMASHEVA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Controllers
{
    class UserController
    {
        public static UserLoginsViewModel ToUserLoginsViewModel(UsersLoginModel loginModel)
        {
            var login = new UserLoginsViewModel();
            login.Date = loginModel.DateLogin.ToShortDateString();
            login.TimeLogin = loginModel.DateLogin.ToShortTimeString();
            login.Reason = loginModel.Reason;
            if (loginModel.IsSuccesful)
            {
                login.TimeLogout = loginModel.DateLogout.ToShortTimeString();
                login.TimeSpent = (loginModel.DateLogout - loginModel.DateLogin).ToString();
            }
            else
            {

                login.TimeLogout = string.Empty;
                login.TimeSpent = string.Empty;
            }
            return login;
        }
    }
}

using GOS_KAMASHEVA.Helpers;
using GOS_KAMASHEVA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Controllers
{
    class AuthorizationController
    {
        public static UsersModel Login(string email, string password)
        {
            var userModel = new UsersModel();
            try
            {
                var userModels = ConnectionHelper.GetUsers();
                userModel = userModels.Where(x => x.Email == email && x.Password == password).First();
            }
            catch (Exception)
            {
                throw;
            }
            return userModel;
        }
    }
}

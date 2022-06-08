using GOS_KAMASHEVA.Helpers;
using GOS_KAMASHEVA.Models;
using GOS_KAMASHEVA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS_KAMASHEVA.Controllers
{
    class AdminController
    {
        public static List<UsersModel> InitUsersList()
        {           
            var users = ConnectionHelper.GetUsers();
            return users;
        }
        public static bool ChangeStatus(int userId)
        {
            var users = ConnectionHelper.GetUsers();
            var user = users.Where(x => x.Id == userId).First();
            if (user.Active)
            {
                ConnectionHelper.UpdateStatus(false, userId);
                return false;
            }
            else
            {
                ConnectionHelper.UpdateStatus(true, userId);
                return true;
            }

        }
        public static void EditUser(UsersModel usersModel, int userId)
        {

            
        }
        public static UserViewModel ToUserViewModel(UsersModel user)
        {
            var userViewModel = new UserViewModel();
            userViewModel.Id = user.Id;
            userViewModel.Role = user.Role.Title;
            userViewModel.Email = user.Email;
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.Office = user.Office.Title;
            userViewModel.Age = DateTime.Now.Year - user.BirthDate.Year;
            return userViewModel;

        }
    }
}

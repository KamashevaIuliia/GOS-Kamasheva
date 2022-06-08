using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOS_KAMASHEVA.Models;

namespace GOS_KAMASHEVA.Helpers
{
    public class ConnectionHelper
    {
       
        public const string connectionString = "Server = 88.99.68.68; Database = Gos_Kamasheva; User Id = sqluser; Password = sqldiplom21;";

        public static List<UsersModel> GetUsers()
        {            
                string queryString =
                    "SELECT * FROM dbo.Users";

                var listUser = new List<UsersModel>();
                var listRole = GetRoles();
                var listOffice = GetOffices();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new UsersModel();
                        user.Id = Convert.ToInt32(reader[0].ToString());
                        user.Role = listRole.Where(x => x.Id == Convert.ToInt32(reader[1].ToString())).First();
                        user.Email = reader[2].ToString();
                        user.Password = reader[3].ToString();
                        user.FirstName = reader[4].ToString();
                        user.LastName = reader[5].ToString();
                        user.Office = listOffice.Where(x => x.Id == Convert.ToInt32(reader[6].ToString())).First();
                        user.BirthDate = DateTime.Parse(reader[7].ToString());
                        user.Active = bool.Parse(reader[8].ToString());
                        listUser.Add(user);
                    }
                    reader.Close();
                }
                return listUser;
        }
        public static List<OfficesModel> GetOffices()
        {
            string queryString =
                    "SELECT * FROM dbo.Offices";

            var listOffice = new List<OfficesModel>();
            var listCountry = GetCountries();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var office = new OfficesModel();
                    office.Id = Convert.ToInt32(reader[0].ToString());
                    office.Country = listCountry.Where(x => x.Id == Convert.ToInt32(reader[1].ToString())).First();
                    office.Title = reader[2].ToString();
                    office.Phone = reader[3].ToString();
                    office.Contact = reader[4].ToString();
                    listOffice.Add(office);
                }
                reader.Close();
            }
            return listOffice;
        } 
        public static List<RolesModel> GetRoles()
        {
            string queryString =
                    "SELECT * FROM dbo.Roles";

            var listRole = new List<RolesModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var role = new RolesModel();
                    role.Id = Convert.ToInt32(reader[0].ToString());
                    role.Title = reader[1].ToString();
                    listRole.Add(role);
                }
                reader.Close();
            }
            return listRole;
        }
        public static List<CountriesModel> GetCountries()
        {
            string queryString =
                    "SELECT * FROM dbo.Countries";

            var listCountry = new List<CountriesModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var country = new CountriesModel();
                    country.Id = Convert.ToInt32(reader[0].ToString());
                    country.Name = reader[1].ToString();
                    listCountry.Add(country);
                }
                reader.Close();
            }
            return listCountry;
        }
        public static List<UsersLoginModel> GetUsersLogins(int userId)
        {
            string queryString =
                    $"SELECT * FROM dbo.UserLogins WHERE UserId = {userId}";

            var listLogins = new List<UsersLoginModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var login = new UsersLoginModel();
                    login.Id = Convert.ToInt32(reader[0].ToString());
                    login.UserId = Convert.ToInt32(reader[1].ToString());
                    login.DateLogin = DateTime.Parse(reader[2].ToString());
                    login.DateLogout = DateTime.Parse(reader[3].ToString());
                    login.IsSuccesful = bool.Parse(reader[4].ToString());
                    login.Reason = reader[5].ToString();
                    listLogins.Add(login);
                }
                reader.Close();
            }
            return listLogins;
        }
        public static void UpdateStatus(bool status, int userId)
        {
            var str = status ? 1 : 0;
            string queryString =
                   $"UPDATE dbo.Users SET Active = {str.ToString()} WHERE ID = {userId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void UpdateRole(int role, int userId)
        {
            string queryString =
                   $"UPDATE dbo.Users SET RoleID = {role} WHERE ID = {userId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void UpdateLogoutReason(UsersLoginModel usersLogin)
        {
            string queryString =
                   $"UPDATE dbo.UserLogins SET IsSuccessfull = 0, Reason = '{usersLogin.Reason}'  WHERE ID = {usersLogin.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void AddUser(UsersModel user)
        {
            var isActive = user.Active ? 1 : 0;
            string queryString =
                   $"INSERT INTO dbo.Users (RoleID, Email, Password, FirstName, LastName, OfficeID, Birthdate, Active) VALUES ({user.Role.Id}, '{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', {user.Office.Id}, '{user.BirthDate}', {isActive}) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void AddLogin(UsersLoginModel login)
        {
            var isSuccessfull = login.IsSuccesful ? 1 : 0;
            string queryString =
                   $"INSERT INTO dbo.UserLogins (UserId, DateLogin, DateLogout, IsSuccessfull, Reason) VALUES ({login.UserId}, '{login.DateLogin.ToString()}', '{login.DateLogout.ToString()}', {isSuccessfull}, '{login.Reason}') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}

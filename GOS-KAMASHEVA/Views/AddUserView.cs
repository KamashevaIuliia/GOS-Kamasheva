using GOS_KAMASHEVA.Helpers;
using GOS_KAMASHEVA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS_KAMASHEVA.Views
{
    public partial class AddUserView : Form
    {
        public AddUserView()
        {
            InitializeComponent();
            OfficesBox.Items.AddRange(AdminView.Offices.Select(x => x.Title).OrderBy(x => x).ToArray());
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var form = new AdminView();
            form.Show();
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var userModel = new UsersModel();
            userModel.Role = new RolesModel() { Id = 2, Title = "User"}; 
            userModel.Email = EmailBox.Text;
            userModel.Password = PasswordBox.Text;
            userModel.FirstName = FNameBox.Text;
            userModel.LastName = LNameBox.Text;
            var office = AdminView.Offices.Where(x => x.Title == OfficesBox.SelectedItem.ToString()).First();
            userModel.Office = office;
            userModel.BirthDate = BDBox.Value;
            userModel.Active = true;
            ConnectionHelper.AddUser(userModel);
            var form = new AdminView();
            form.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOS_KAMASHEVA.Helpers;
using GOS_KAMASHEVA.Models;

namespace GOS_KAMASHEVA.Views
{
    public partial class EditRoleView : Form
    {
        public static int UserId = 0;
        public EditRoleView(UserViewModel userModel)
        {
            InitializeComponent();
            UserId = userModel.Id;
            EmailBox.Text = userModel.Email;
            FNameBox.Text = userModel.FirstName;
            LNameBox.Text = userModel.LastName;
            OfficesBox.SelectedItem = userModel.Office;
            switch (userModel.Role)
            {
                case "Administrator":
                    AdminRB.Checked = true;
                    break;
                case "User":
                    UserRB.Checked = true;
                    break;
                default:
                    break;
            }

        }

        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            var form = new AdminView();
            form.Show();
            this.Hide();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (AdminRB.Checked)
            {
                ConnectionHelper.UpdateRole(1, UserId);
            }
            else if (UserRB.Checked)
            {
                ConnectionHelper.UpdateRole(2, UserId);
            }

            var form = new AdminView();
            form.Show();
            this.Hide();
        }
    }
}

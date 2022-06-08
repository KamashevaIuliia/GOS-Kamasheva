using GOS_KAMASHEVA.Controllers;
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
    public partial class AdminView : Form
    {
        
        public static List<UsersModel> usersModels = new List<UsersModel>();
        public static List<UserViewModel> usersViewModels = new List<UserViewModel>();
        public static List<OfficesModel> Offices = new List<OfficesModel>();
        public AdminView()
        {
            InitializeComponent();
            usersModels = AdminController.InitUsersList();
            usersViewModels = usersModels.Select(x => AdminController.ToUserViewModel(x)).ToList();
            usersDataGridView.DataSource = usersViewModels;
            Offices = ConnectionHelper.GetOffices();
            OfficesBox.Items.AddRange(Offices.Select(x => x.Title).OrderBy(x => x).ToArray());
            OfficesBox.Items.Add("All");        

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var form = new AuthorizationView();
            form.Show();
            this.Hide();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var form = new AddUserView();
            form.Show();
            this.Hide();
        }

        private void RoleButton_Click(object sender, EventArgs e)
        {
            var rowindex = usersDataGridView.CurrentRow.Index;
            var userId = Convert.ToInt32(usersDataGridView.Rows[rowindex].Cells[0].Value.ToString());
            var userModel = usersViewModels.Where(x => x.Id == userId).First();
            var form = new EditRoleView(userModel);
            form.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var rowindex = usersDataGridView.CurrentRow.Index;
            var status = AdminController.ChangeStatus(Convert.ToInt32(usersDataGridView.Rows[rowindex].Cells[0].Value.ToString()));
            if (status)
            {
                usersDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
            }
            else
            {
                usersDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void OfficesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OfficesBox.SelectedItem == "All")
            {
                usersDataGridView.DataSource = usersViewModels;
            }
            else
            {
                usersDataGridView.DataSource = usersViewModels.Where(x => x.Office == OfficesBox.SelectedItem.ToString()).ToList();
            }

        }

    }
}

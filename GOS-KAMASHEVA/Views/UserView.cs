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
    public partial class UserView : Form
    {
        public static List<UsersLoginModel> usersLoginModels = new List<UsersLoginModel>();
        public static List<UserLoginsViewModel> usersLoginViewModels = new List<UserLoginsViewModel>();
        public static UsersLoginModel currentSession = new UsersLoginModel();
        public UserView(UsersModel user, ref bool isOK)
        {
            InitializeComponent();
            HiLabel.Text = $"Hi, {user.FirstName}, Welcome to AMONIC Airlines.";
            usersLoginModels = ConnectionHelper.GetUsersLogins(user.Id);
            if (usersLoginModels.Where(x => x.DateLogout == DateTime.MinValue && x.IsSuccesful == true).Count() != 0)
            {
                var form = new LogoutReasonView(usersLoginModels.Where(x => x.DateLogout == DateTime.MinValue && x.IsSuccesful == true).First());
                form.Show();
                this.Hide();
                isOK = false;
                return;

            }
            usersLoginViewModels = usersLoginModels.Select(x => UserController.ToUserLoginsViewModel(x)).ToList();
            dataGridView1.DataSource = usersLoginViewModels;
            var totalSpan = new TimeSpan(usersLoginModels.Where(x => x.IsSuccesful).Sum(r => (r.DateLogout - r.DateLogin).Ticks));
            SpentTimeLabel.Text = $"Time spent on system: {totalSpan}";
            var countCrushes = usersLoginModels.Select(x => !x.IsSuccesful).Count();
            CrushesCountLabel.Text = $"Number of crushes: {countCrushes}";
            currentSession.DateLogin = DateTime.UtcNow;
            currentSession.UserId = user.Id;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value.ToString() != string.Empty)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            currentSession.DateLogout = DateTime.UtcNow;
            ConnectionHelper.AddLogin(currentSession);
            var form = new AuthorizationView();
            form.Show();
            this.Hide();
        }

        private void UserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectionHelper.AddLogin(currentSession);
        }
    }
}

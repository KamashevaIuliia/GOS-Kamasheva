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
    public partial class LogoutReasonView : Form
    {
        public static UsersLoginModel usersLogin = new UsersLoginModel();
        public LogoutReasonView(UsersLoginModel userLogin)
        {
            InitializeComponent();
            usersLogin = userLogin;
            var date = usersLogin.DateLogin.ToString().Split(' ');
            label1.Text = $"No logout detected for your last login on {date[0]} at {date [1]}"; 
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != string.Empty)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usersLogin.IsSuccesful = false;
            usersLogin.Reason = richTextBox1.Text != string.Empty ? richTextBox1.Text : radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
            ConnectionHelper.UpdateLogoutReason(usersLogin);
            var userModels = ConnectionHelper.GetUsers();
            var userModel = userModels.Where(x => x.Id == usersLogin.UserId).First();
            var isOk = true;
            var form = new UserView(userModel, ref isOk);
            form.Show();
            this.Hide();
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}

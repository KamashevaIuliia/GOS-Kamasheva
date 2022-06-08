using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOS_KAMASHEVA.Controllers;
using GOS_KAMASHEVA.Views;
using GOS_KAMASHEVA.Models;

namespace GOS_KAMASHEVA
{
    public partial class AuthorizationView : Form
    {
        int schet = 0, timeSec = 10;
        public AuthorizationView()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            if (timeSec != 0)
            {
                lbMessage.Text = "Превышен лимит попыток.\n Форма заблокирована на " + timeSec + " сек.";
                timeSec--;
            }
            else
            {
                this.Enabled = true;
                lbMessage.Text = "";
                schet = 0;
                timer.Stop();
                timeSec = 10;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var userModel = new UsersModel();
            try
            {               
                userModel = AuthorizationController.Login(UserNameBox.Text, PasswordBox.Text);
            }
            catch (Exception)
            {
                if (schet >= 3)
                {
                    this.Enabled = false;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль.");
                    schet++;
                }
                
                return;
            }

            var isOk = true;
            switch (userModel.Role.Id)
            {
                case 1:
                    this.Hide();
                    var form = new AdminView();
                    form.Show();
                    break;
                case 2:
                    this.Hide();
                    var userForm = new UserView(userModel, ref isOk);
                    if (isOk)
                    {
                        userForm.Show();
                    }
                    break;
                default:
                    MessageBox.Show("Ошибочка. Такой роли не существует.");
                    break;
            }
            
               
        }
    }
}

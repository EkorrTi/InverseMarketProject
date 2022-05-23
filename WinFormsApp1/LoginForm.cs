using InverseMarketProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        private Database db;
        public LoginForm()
        {
            db = new Database();
            InitializeComponent();
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            var email = emailTextBox.Text;
            var password = passTextBox.Text;

            var user = db.GetUserByEmailAndPassword(email, password);
            if (user == null)
            {
                MessageBox.Show("User not found");
                return;
            }

            CommonClass.UserId = user.Id;
            // TODO go to main page
            FormProvider.loggedUser = user;
            FormProvider.listForm = new ListForm();
            Hide();
            FormProvider.listForm.Show(); 
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void toRegister_Click(object sender, EventArgs e)
        {
            Hide();
            FormProvider.registrationForm = new RegistrationForm();
            FormProvider.registrationForm.Show();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

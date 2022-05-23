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

        private void loginButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;

            var user = db.GetUserByEmailAndPassword(email, password);
            if (user == null)
            {
                errorLabel.Text = "User not found";
                return;
            }

            CommonClass.UserId = user.Id;
            // TODO go to main page
        }
    }
}

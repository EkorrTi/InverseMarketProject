using InverseMarketProject;
using InverseMarketProject.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void Registration_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text.ToString();
            var password = passwordTextBox.Text.ToString();
            var retryPassword = retryPasswordTextBox.Text.ToString();
            var username = usernameTextBox.Text.ToString();
            var firstName = firstNameTextBox.Text.ToString();
            var lastName = lastNameTextBox.Text.ToString();

            validateFields(email, password, retryPassword, username, firstName, lastName);
        }

        private void validateFields(string email, 
                                    string password, 
                                    string retryPassword, 
                                    string username, 
                                    string firstName, 
                                    string lastName)
        {
            var isEmailValid = validateEmail(email);
            var isPasswordValid = validatePassword(password, retryPassword);
            var isUsernameValid = validateUsername(username);
            var isFirstNameValid = validateFirstName(firstName);
            var isLastNameValid = validateLastName(lastName);


            

            if (isEmailValid && isPasswordValid && isUsernameValid && isFirstNameValid && isLastNameValid)
            {
                User user = new User(email:email, password:password, username:username, firstName:firstName, lastName:lastName);
                addToDatabase(user);
            }
        }

        private bool validateLastName(string lastName)
        {
            if (lastName == "")
            {
                MessageBox.Show("Last Name is required");
                return false;
            }

            return true;
        }

        private bool validateFirstName(string firstName)
        {
            if (firstName == "")
            {
                MessageBox.Show("First Name is required");
                return false;
            }

            return true;
        }

        private bool validateUsername(string username)
        {
            if (username=="")
            {
                MessageBox.Show("Username is required");
                return false;
            }

            return true;
        }

        private void addToDatabase(User user) 
        {
            
            Database db = new Database();
            bool isUserExists = false;
            var dbUser = db.GetUserByEmail(user.Email);
            if (dbUser != null)
            {
                isUserExists = true;
                MessageBox.Show("Email already registered");
            }

            dbUser = db.GetUserByUsername(user.UserName);
            if (dbUser != null)
            {
                isUserExists = true;
                MessageBox.Show("Username already registered");
            }
            if (!isUserExists)
            {
                db.InsertUser(user);
                this.Hide();
                var loginForm = new Form1(); // TODO replace with LoginForm
                loginForm.Show();
            }
        }

        private bool validatePassword(string password, string retryPassword)
        {
            if (password != retryPassword)
            {
                MessageBox.Show("Passwords doesn't match");
                return false;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 symbols");
                return false;
            }

            var validCount = 0;

            foreach(char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validCount++;
                    break;
                }
            }

            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validCount++;
                    break;
                }
            }

            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                {
                    validCount++;
                    break;
                }
            }

            char[] special = { '@', '#', '$', '%', '&' };
            if (password.IndexOfAny(special) != -1) validCount++;

            if (validCount != 4)
            {
                MessageBox.Show("Password must contain 1 uppercase, 1 lowercase letter, 1 number and 1 special character");
                return false;
            }

            return true;
        }

        private bool validateEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

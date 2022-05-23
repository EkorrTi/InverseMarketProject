using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InverseMarketProject.entity;
using InverseMarketProject;

namespace WinFormsApp1
{
    public partial class AddAdvertForm : Form
    {
        public AddAdvertForm()
        {
            InitializeComponent();
            usernameLabel.Text = FormProvider.loggedUser.UserName;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var title = titleTextBox.Text;
            var price = priceTextBox.Text;
            try { Convert.ToInt32(price); }
            catch (FormatException) { MessageBox.Show("Price should be a number"); return; }
            catch (Exception) { MessageBox.Show("Price is improper"); return; }
            var desc = descTextBox.Text;

            Advert advert = new(title, desc, price, "Open", FormProvider.loggedUser.Id);
            Database db = new();
            db.InsertAdvert(advert);
            db.closeConnection();

            FormProvider.listForm = new ListForm();
            Hide();
            FormProvider.listForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            FormProvider.listForm = new ListForm();
            Hide();
            FormProvider.listForm.Show();
        }

        private void AddAdvertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

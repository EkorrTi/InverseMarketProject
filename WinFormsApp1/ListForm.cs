using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InverseMarketProject;
using InverseMarketProject.entity;

namespace WinFormsApp1
{
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();

            usernameLabel.Text = FormProvider.loggedUser.UserName;

            Database db = new();
            DataTable dt = new();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Total Price", typeof(int));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("User_id", typeof(int));
            dt.Columns.Add("Posted", typeof(DateTime));


            foreach (Advert a in db.GetAdverts())
            {
                dt.Rows.Add(new object[] { a.Id, a.Title, a.Description, Convert.ToInt32(a.TotalPrice), a.Status, a.UserId, a.Posted });
            }

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int rowId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            label2.Text = "Clicked on id=" + rowId;
            FormProvider.advertForm = new AdvertForm(rowId);
            FormProvider.advertForm.Show();
            Hide();
        }

        private void toAddAdvert_Click(object sender, EventArgs e)
        {
            FormProvider.addAdvertForm = new AddAdvertForm();
            FormProvider.addAdvertForm.Show();
            Hide();
        }

        private void ListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value.ToString());
                int userId = Convert.ToInt32(item.Cells[5].Value.ToString());
                if (userId == FormProvider.loggedUser.Id)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                    Database db = new();
                    db.DeleteAdvert(id);
                }
            }
        }
    }
}

using System.Data;
using InverseMarketProject.entity;
using InverseMarketProject;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Database db = new();
            DataTable dt = new();

            dt.Columns.Add("ID", typeof(Int32));
            foreach (User user in db.GetUsers())
            {
                dt.Rows.Add(new object[] {user.Id});
            }

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new Registration();
            form.Tag = this;
            form.Show();
        }
    }
}
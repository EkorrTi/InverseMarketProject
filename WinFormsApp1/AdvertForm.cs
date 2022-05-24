using InverseMarketProject;
using InverseMarketProject.entity;
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
    public partial class AdvertForm : Form
    {
        private Database db;
        private int advertId;

        private const int ORDER_BY_DATE_DESC_INDEX = 0;
        private const int ORDER_BY_DATE_ASC_INDEX = 1;
        private const int ORDER_BY_PRICE_DESC_INDEX = 2;
        private const int ORDER_BY_PRICE_ASC_INDEX = 3;
        private const string ORDER_BY_DATE_DESC = "Date desc";
        private const string ORDER_BY_DATE_ASC = "Date asc";
        private const string ORDER_BY_PRICE_DESC = "Price desc";
        private const string ORDER_BY_PRICE_ASC = "Price asc";
        private dynamic replies;
        private List<Tuple<Reply, String>> replyList = new();
        public AdvertForm()
        {
            db = new Database();
            InitializeComponent();
        }
        public AdvertForm(int advertId) : this()
        {
            this.advertId = advertId;
            setAdvert();
        }

        private void setAdvert()
        {
            Advert advert = db.GetAdvertById(advertId);
            titleTextBox.Text = advert.Title;
            descriptionTextBox.Text = advert.Description;
            priceTextBox.Text = advert.TotalPrice.ToString();

            User author = db.GetUserById(advert.UserId);
            authorTextBox.Text = author.UserName;

            getList();
        }

        private void setList()
        {
            DataTable dt = new();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("message", typeof(string));
            dt.Columns.Add("price", typeof(int));
            dt.Columns.Add("AuthorID", typeof(int));
            dt.Columns.Add("Author", typeof(string));
            
            foreach(Tuple<Reply, string, int> reply in replies)
            {
                dt.Rows.Add(new Object[] { reply.Item1.Id, reply.Item1.Message, reply.Item1.Price, reply.Item3, reply.Item2 });
            }
            replyDataGrid.DataSource = dt;
        }

        private void getList()
        {
            List<Reply> replies = db.GetRepliesByAdvertId(advertId);
            List<Tuple<Reply, String, int>> repliesWithAuthor = new();
            foreach (Reply reply in replies)
            {
                var user = db.GetUserById(reply.UserId);
                repliesWithAuthor.Add(new Tuple<Reply, String, int>(reply, user.UserName, user.Id));
            }
            this.replies =  repliesWithAuthor;
            setList();
        }

        private void replyButton_Click(object sender, EventArgs e)
        {
            var message = replyMessageTextBox.Text;
            var price = 0;
            if (message == "")
            {
                MessageBox.Show("Add message");
                return;
            }
            try
            {
                price = replyPriceTextBox.Text == "" ? 0 : Convert.ToInt32(replyPriceTextBox.Text);
            } catch( FormatException )
            {
                MessageBox.Show("Please write a valid price");
                return;
            }

            db.InsertReply(
                new Reply(message: message, 
                          price: price, 
                          userId: FormProvider.loggedUser.Id, 
                          advertId: advertId)
                );
            replyMessageTextBox.Text = "";
            replyPriceTextBox.Text = "";
            getList();
        }

        private void replyPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(replyMessageTextBox.Text, "^[0-9]"))
            {
                replyMessageTextBox.Text = "";
            }
        }


        private void orderByPriceAsc()
        {
            this.replies = from reply in replyList
                                orderby reply.Item1.Price ascending
                                select reply;
        }

        private void orderByPriceDesc()
        {
            this.replies = from reply in replyList
                           orderby reply.Item1.Price descending
                                select reply;
        }

        private void orderByDateAsc()
        {
            this.replies = from reply in replyList
                           orderby reply.Item1.Id ascending
                                select reply;
        }

        private void orderByDateDesc()
        {
            this.replies = from reply in replyList
                           orderby reply.Item1.Id descending
                           select reply;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            FormProvider.listForm = new ListForm();
            Hide();
            FormProvider.listForm.Show();
        }

        private void AdvertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in replyDataGrid.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value.ToString());
                int userId = Convert.ToInt32(item.Cells[3].Value.ToString());
                if (userId == FormProvider.loggedUser.Id)
                {
                    replyDataGrid.Rows.RemoveAt(item.Index);
                    Database db = new();
                    db.DeleteReply(id);
                }
            }
        }
    }
}

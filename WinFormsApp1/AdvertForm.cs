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
        private List<Tuple<Reply, string>> replies = new();
        public AdvertForm()
        {
            db = new Database();
            InitializeComponent();
        }
        public AdvertForm(int advertId) : this()
        {
            this.advertId = advertId;
            orderComboBox.Items.Add(ORDER_BY_DATE_DESC);
            orderComboBox.Items.Add(ORDER_BY_DATE_ASC);
            orderComboBox.Items.Add(ORDER_BY_PRICE_DESC);
            orderComboBox.Items.Add(ORDER_BY_PRICE_ASC);
            orderComboBox.SelectedIndex = ORDER_BY_DATE_DESC_INDEX;
            setAdvert();
        }

        private void setAdvert()
        {
            Advert advert = db.GetAdvertById(advertId);
            titleTextBox.Text = advert.Title;
            descriptionTextBox.Text = advert.Description;
            statusTextBox.Text = advert.Status;
            priceTextBox.Text = advert.TotalPrice.ToString();

            getList();

            setList();
        }

        private void setList()
        {
            replyListPanel.Controls.Clear();
            ReplyForm[] replyForms = new ReplyForm[this.replies.Count];
            foreach(Tuple< Reply, String> reply in this.replies)
            {
                ReplyForm replyForm = new();
                replyForm.Message = reply.Item1.Message;
                replyForm.Author = reply.Item2;
                replyForm.Price = reply.Item1.Price;
                replyListPanel.Controls.Add(replyForm);
            }
        }

        private void getList()
        {
            List<Reply> replies = db.GetRepliesByAdvertId(advertId);
            List<Tuple<Reply, String>> repliesWithAuthor = new();
            foreach (Reply reply in replies)
            {
                var user = db.GetUserById(reply.UserId);
                repliesWithAuthor.Add(new Tuple<Reply, String>(reply, user.UserName));
            }
            this.replies =  repliesWithAuthor;
            orderByDateDesc();
        }

        private void replyButton_Click(object sender, EventArgs e)
        {
            var message = replyMessageTextBox.Text;
            var price = 0;
            try
            {
                price = replyPriceTextBox.Text == "" ? 0 : Convert.ToInt32(replyPriceTextBox.Text);
            } catch( FormatException )
            {
                MessageBox.Show("Please write a valid price");
            }


            var userId = 1; // TODO GET CURRENT USER

            db.InsertReply(
                new Reply(message: message, 
                          price: price, 
                          userId: userId, 
                          advertId: advertId)
                );
        }

        private void replyPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(replyMessageTextBox.Text, "^[0-9]"))
            {
                replyMessageTextBox.Text = "";
            }
        }

        private void orderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(orderComboBox.SelectedIndex)
            {
                case ORDER_BY_DATE_ASC_INDEX:
                    orderByDateAsc();
                    break;
                case ORDER_BY_PRICE_DESC_INDEX:
                    orderByPriceDesc();
                    break;
                case ORDER_BY_PRICE_ASC_INDEX:
                    orderByPriceAsc();
                    break;
                default:
                    orderByDateDesc();
                    break;
            };
            setList();
        }

        private void orderByPriceAsc()
        {
            this.replies = (List<Tuple<Reply, string>>)(from reply in replies
                                                        orderby reply.Item1.Price ascending
                                                        select reply);
        }

        private void orderByPriceDesc()
        {
            this.replies = (List<Tuple<Reply, string>>)(from reply in replies
                                                        orderby reply.Item1.Price descending
                                                        select reply);
        }

        private void orderByDateAsc()
        {
            this.replies = (List<Tuple<Reply, string>>)(from reply in replies
                                                        orderby reply.Item1.Id ascending
                                                        select reply);
        }

        private void orderByDateDesc()
        {
            this.replies = (List<Tuple<Reply, string>>)(from reply in replies
                           orderby reply.Item1.Id descending
                           select reply);
        }
    }
}

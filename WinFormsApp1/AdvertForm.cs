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
        public AdvertForm()
        {
            InitializeComponent();
        }
        public AdvertForm(int advertId)
        {
            InitializeComponent();
            setAdvert(advertId);
        }

        private void setAdvert(int advertId)
        {
            Database db = new Database();
            Advert advert = db.GetAdvertById(advertId);
            titleTextBox.Text = advert.Title;
            descriptionTextBox.Text = advert.Description;
            statusTextBox.Text = advert.Status;
            priceTextBox.Text = advert.TotalPrice.ToString();

            List<Reply> replies = db.GetRepliesByAdvertId(advertId);
            List<Tuple<Reply, String>> repliesWithAuthor = new();
            foreach(Reply reply in replies)
            {
                var user = db.GetUserById(reply.UserId);
                repliesWithAuthor.Add(new Tuple<Reply, String>(reply, user.UserName));
            }
            setList(repliesWithAuthor);
        }

        private void setList(List<Tuple<Reply, String>> replies)
        {
            replyListPanel.Controls.Clear();
            ReplyForm[] replyForms = new ReplyForm[replies.Count];
            foreach(Tuple< Reply, String> reply in replies)
            {
                ReplyForm replyForm = new();
                replyForm.Message = reply.Item1.Message;
                replyForm.Author = reply.Item2;
                replyForm.Price = reply.Item1.Price;
                replyListPanel.Controls.Add(replyForm);
            }
        }

        private void replyButton_Click(object sender, EventArgs e)
        {
            var message = replyMessageTextBox.Text;
            try
            {
                var price = replyPriceTextBox.Text == "" ? 0 : Convert.ToInt32(replyPriceTextBox.Text);
            } catch( FormatException )
            {
                MessageBox.Show("Please write a valid price");
            }


            var userId = 1; // TODO GET CURRENT USER


        }

        private void replyPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(replyMessageTextBox.Text, "^[0-9]"))
            {
                replyMessageTextBox.Text = "";
            }
        }
    }
}

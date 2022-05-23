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
    public partial class ReplyForm : UserControl
    {
        public ReplyForm()
        {
            InitializeComponent();
        }


        private string _message;
        private string _author;
        private int _price;


        public string Message
        {
            get { return _message; }
            set { _message = value; messageLabel.Text = value; }
        }

        public string Author
        {
            get { return _author; }
            set { value = _author;authorLabel.Text = value; }
        }

        public int Price
        {
            get { return _price; }
            set { value = _price; priceLabel.Text = value.ToString() + " тг"; }
        }
    }
}

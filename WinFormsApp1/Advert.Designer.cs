namespace WinFormsApp1
{
    partial class Advert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.replyInfoTextBox = new System.Windows.Forms.TextBox();
            this.replyPriceTextBox = new System.Windows.Forms.TextBox();
            this.replyMessageTextBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(12, 12);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(776, 23);
            this.titleTextBox.TabIndex = 0;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 41);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(776, 92);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // priceTextBox
            // 
            this.priceTextBox.BackColor = System.Drawing.Color.Moccasin;
            this.priceTextBox.Location = new System.Drawing.Point(710, 139);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.ReadOnly = true;
            this.priceTextBox.Size = new System.Drawing.Size(78, 23);
            this.priceTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.replyInfoTextBox);
            this.panel1.Controls.Add(this.replyPriceTextBox);
            this.panel1.Controls.Add(this.replyMessageTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 161);
            this.panel1.TabIndex = 3;
            // 
            // replyInfoTextBox
            // 
            this.replyInfoTextBox.Location = new System.Drawing.Point(3, 3);
            this.replyInfoTextBox.Multiline = true;
            this.replyInfoTextBox.Name = "replyInfoTextBox";
            this.replyInfoTextBox.ReadOnly = true;
            this.replyInfoTextBox.Size = new System.Drawing.Size(166, 34);
            this.replyInfoTextBox.TabIndex = 2;
            this.replyInfoTextBox.Text = "Reply to advert";
            // 
            // replyPriceTextBox
            // 
            this.replyPriceTextBox.Location = new System.Drawing.Point(672, 128);
            this.replyPriceTextBox.Multiline = true;
            this.replyPriceTextBox.Name = "replyPriceTextBox";
            this.replyPriceTextBox.PlaceholderText = "Your price";
            this.replyPriceTextBox.Size = new System.Drawing.Size(101, 20);
            this.replyPriceTextBox.TabIndex = 1;
            // 
            // replyMessageTextBox
            // 
            this.replyMessageTextBox.Location = new System.Drawing.Point(3, 43);
            this.replyMessageTextBox.Multiline = true;
            this.replyMessageTextBox.Name = "replyMessageTextBox";
            this.replyMessageTextBox.PlaceholderText = "Your message";
            this.replyMessageTextBox.Size = new System.Drawing.Size(770, 79);
            this.replyMessageTextBox.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 365);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 139);
            this.listBox1.TabIndex = 4;
            // 
            // Advert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Name = "Advert";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private TextBox priceTextBox;
        private Panel panel1;
        private TextBox replyInfoTextBox;
        private TextBox replyPriceTextBox;
        private TextBox replyMessageTextBox;
        private ListBox listBox1;
    }
}
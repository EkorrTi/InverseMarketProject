﻿namespace WinFormsApp1
{
    partial class AdvertForm
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
            this.replyButton = new System.Windows.Forms.Button();
            this.replyInfoTextBox = new System.Windows.Forms.TextBox();
            this.replyPriceTextBox = new System.Windows.Forms.TextBox();
            this.replyMessageTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.replyListPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.panel1.Controls.Add(this.replyButton);
            this.panel1.Controls.Add(this.replyInfoTextBox);
            this.panel1.Controls.Add(this.replyPriceTextBox);
            this.panel1.Controls.Add(this.replyMessageTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 161);
            this.panel1.TabIndex = 3;
            // 
            // replyButton
            // 
            this.replyButton.Location = new System.Drawing.Point(698, 128);
            this.replyButton.Name = "replyButton";
            this.replyButton.Size = new System.Drawing.Size(75, 23);
            this.replyButton.TabIndex = 5;
            this.replyButton.Text = "Reply";
            this.replyButton.UseVisualStyleBackColor = true;
            this.replyButton.Click += new System.EventHandler(this.replyButton_Click);
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
            this.replyPriceTextBox.Location = new System.Drawing.Point(591, 129);
            this.replyPriceTextBox.Multiline = true;
            this.replyPriceTextBox.Name = "replyPriceTextBox";
            this.replyPriceTextBox.PlaceholderText = "Your price";
            this.replyPriceTextBox.Size = new System.Drawing.Size(101, 20);
            this.replyPriceTextBox.TabIndex = 1;
            this.replyPriceTextBox.TextChanged += new System.EventHandler(this.replyPriceTextBox_TextChanged);
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
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(538, 139);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(166, 23);
            this.statusTextBox.TabIndex = 6;
            // 
            // replyListPanel
            // 
            this.replyListPanel.Location = new System.Drawing.Point(12, 335);
            this.replyListPanel.Name = "replyListPanel";
            this.replyListPanel.Size = new System.Drawing.Size(776, 167);
            this.replyListPanel.TabIndex = 7;
            // 
            // AdvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.replyListPanel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Name = "AdvertForm";
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
        private Button replyButton;
        private TextBox statusTextBox;
        private FlowLayoutPanel replyListPanel;
    }
}
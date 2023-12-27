﻿namespace DBapplication
{
    partial class AdminView
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

            if (disposing)
            {
                if (topLogout1.back)
                    parent.Show();
                else
                    parent.Close();

                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminView));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.topLogout1 = new DBapplication.TopLogout();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(718, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Departments";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(718, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Branches";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(718, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(223, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Services";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(718, 259);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(223, 39);
            this.button4.TabIndex = 3;
            this.button4.Text = "Managers";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(718, 304);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(223, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "Admins";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(718, 350);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(223, 44);
            this.button6.TabIndex = 5;
            this.button6.Text = "Change Password";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // topLogout1
            // 
            this.topLogout1.Location = new System.Drawing.Point(0, 0);
            this.topLogout1.Name = "topLogout1";
            this.topLogout1.Size = new System.Drawing.Size(1055, 100);
            this.topLogout1.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(718, 400);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(223, 40);
            this.button7.TabIndex = 9;
            this.button7.Text = "Statistics";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(68, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(578, 311);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1051, 450);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.topLogout1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "AdminView";
            this.Text = "AdminView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private TopLogout topLogout1;
        private System.Windows.Forms.Button button7;
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class HODLogin : Form
    {
        Controller controllerObj;
        Form parent;
        public HODLogin(Form Parent)
        {
            InitializeComponent();
            parent = Parent;
            top1.setForms(parent, this);

        }

        private void button1_Click(object sender, EventArgs e) //checks hod validity before login
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0) { MessageBox.Show("Error! Please, complete the required info"); }
            else
            {
                controllerObj = new Controller();
                string un = textBox1.Text;
                string pass = textBox2.Text;
                int result = controllerObj.CheckHODLogin(un, pass);
                if (result == 0) { MessageBox.Show("Error! Wrong username or password"); }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    HODView hoDView = new HODView(controllerObj.GetUserID("hod", un, pass),parent);
                    hoDView.Show();
                    this.Hide();
                }
            }
        }

    }
}

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
    public partial class AdminLogin : Form
    {
        Controller controllerObj;
        Form parent;
        public AdminLogin(Form Parent)
        {
            InitializeComponent();
            parent = Parent;
            top1.setForms(parent, this);
        }

        private void button1_Click(object sender, EventArgs e) //checks admin validity before login
        {
            controllerObj = new Controller();
            string un = textBox1.Text;
            string pass = textBox2.Text;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else
            {
                int result = controllerObj.CheckAdminLogin(un, pass);
                if (result == 0) { MessageBox.Show("Error! Wrong username or password"); }
                else
                {
                    AdminView adminView = new AdminView(controllerObj.GetAdminID(un, pass),parent);
                    adminView.Show();
                    this.Hide();
                }
            }
        }

    }
}

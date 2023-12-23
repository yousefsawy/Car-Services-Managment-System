using System;
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
    public partial class AdminsAdmin : Form
    {
        Controller controllerObj;
        public AdminsAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //creates new admin
        {
            controllerObj = new Controller();
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string fname = textBox3.Text;
            string lname = textBox4.Text;
            string phone = textBox5.Text;
            int x = 0;
            if (un == "" || pass == "" || fname == "" || lname == "" || phone == "")
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (!int.TryParse(phone, out x)) { MessageBox.Show("Error! Please enter a valid phone"); }
            else if (textBox5.TextLength != 5) { MessageBox.Show("Error! Phone should be 5 characters"); }
            else if (textBox2.TextLength > 10) { MessageBox.Show("Error! Maximum 10 characters for password"); }
            else
            {
                int result = controllerObj.InsertAdmin(un, pass, fname, lname, phone);
                if (result == 0) { MessageBox.Show("Error! This username is already taken"); }
                else
                {
                    MessageBox.Show("Admin created successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
        }
    }
}

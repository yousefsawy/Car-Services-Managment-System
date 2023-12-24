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
    public partial class Register : Form
    {
        Controller controllerObj;
        Form parent;
        public bool back;
        public Register(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            top1.setForms(parent, this);
            back = false;
        }

        private void button1_Click(object sender, EventArgs e) //register as a new client
        {
            controllerObj = new Controller();
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string fname = textBox3.Text;
            string lname = textBox4.Text;
            string phone = textBox5.Text;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (textBox2.TextLength > 10)
            {
                MessageBox.Show("Error! Maximum 10 characters for your password");
            }
            else if (textBox5.TextLength == 0)
            {
                int result = controllerObj.InsertClient(un, pass, fname, lname, "null");
                if (result == 0) { MessageBox.Show("Error! This username is already taken"); }
                else { MessageBox.Show("Successful registration"); }
            }
            else
            {
                int result = controllerObj.InsertClient(un, pass, fname, lname, phone);
                if (result == 0) { MessageBox.Show("Error! This username is already taken"); }
                else { MessageBox.Show("Successful registration"); }
            }
        }


    }
}

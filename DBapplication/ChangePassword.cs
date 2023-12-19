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
    public partial class ChangePassword : Form
    {
        int user_id;
        string user;
        Controller controllerObj;
        public ChangePassword(int id, string userr)
        {
            InitializeComponent();
            user_id = id;
            user = userr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            string pass = textBox1.Text;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (pass != textBox2.Text)
            {
                MessageBox.Show("Error! Two passwords don't match");
            }
            else if (textBox2.TextLength > 10)
            {
                MessageBox.Show("Error! Maximum 10 characters for your password");
            }
            else
            {
                controllerObj.ChangePassword(user, user_id, pass);
                MessageBox.Show("Password changed successfully");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}

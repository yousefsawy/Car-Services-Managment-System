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
    public partial class ClientLogin : Form
    {
        Controller controllerObj;
        Form parent;
        public ClientLogin(Form Parent)
        {
            this.parent = Parent;
            InitializeComponent();
            top1.setForms(parent, this);
        }

        private void button1_Click(object sender, EventArgs e) //checks client validity before login
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0) { MessageBox.Show("Error! Please, complete the required info"); }
            else
            {
                controllerObj = new Controller();
                string un = textBox1.Text;
                string pass = textBox2.Text;
                int result = controllerObj.CheckClientLogin(un, pass);
                if (result == 0) { MessageBox.Show("Error! Wrong username or password"); }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    ClientView clientView = new ClientView(controllerObj.GetUserID("client", un, pass),parent);
                    clientView.Show();
                    this.Hide();
                }
            }
        }


    }
}

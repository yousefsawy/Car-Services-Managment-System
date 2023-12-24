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
    public partial class Welcome : Form
    {
        Controller controllerobj;
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            controllerobj = new Controller(); //it just shows the db connection message at first
        }



        private void button3_Click(object sender, EventArgs e) //login as hod
        {
            HODLogin hODLogin = new HODLogin(this);
            hODLogin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //login as client
        {
            ClientLogin clientLogin = new ClientLogin(this);
            clientLogin.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e) //login as admin
        {
            AdminLogin adminLogin = new AdminLogin(this);
            adminLogin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) //register as client
        {
            Register register = new Register(this);
            register.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //login as manager
        {
            ManagerLogin managerLogin = new ManagerLogin(this);
            managerLogin.Show();
            this.Hide();
        }


    }
}

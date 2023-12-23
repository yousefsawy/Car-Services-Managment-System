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
            HODLogin hODLogin = new HODLogin();
            hODLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e) //login as client
        {
            ClientLogin clientLogin = new ClientLogin(this);
            clientLogin.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e) //useless
        {

        }

        private void button2_Click(object sender, EventArgs e) //login as admin
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void button5_Click(object sender, EventArgs e) //register as client
        {
            Register register = new Register(this);
            register.Show();
        }

        private void button4_Click(object sender, EventArgs e) //login as manager
        {
            ManagerLogin managerLogin = new ManagerLogin();
            managerLogin.Show();
        }


    }
}

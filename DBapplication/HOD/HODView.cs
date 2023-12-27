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
    public partial class HODView : Form
    {
        int hod_id;
        Form parent;
        public HODView(int id, Form parent)
        {
            InitializeComponent();
            hod_id = id;
            this.parent = parent;
            topLogout1.setForms(parent, this);
        }


        private void button3_Click(object sender, EventArgs e) //changes password
        {
            ChangePassword changePassword = new ChangePassword(hod_id, "hod", this);
            changePassword.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //handles requests and assigns to employees in his department
        {
            RequestHOD requestHOD = new RequestHOD(hod_id,this);
            requestHOD.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //get stats of his department
        {
            StatsHOD statsHOD = new StatsHOD(hod_id,this);
            statsHOD.Show();
            this.Hide();
        }

        private void HODView_Load(object sender, EventArgs e)
        {

        }
    }
}

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
        public HODView(int id)
        {
            InitializeComponent();
            hod_id = id;
        }

        private void HODView_Load(object sender, EventArgs e) //useless
        {

        }

        private void button3_Click(object sender, EventArgs e) //changes password
        {
            ChangePassword changePassword = new ChangePassword(hod_id, "hod");
            changePassword.Show();
        }

        private void button1_Click(object sender, EventArgs e) //handles requests and assigns to employees in his department
        {
            RequestHOD requestHOD = new RequestHOD(hod_id);
            requestHOD.Show();
        }

        private void button2_Click(object sender, EventArgs e) //get stats of his department
        {
            StatsHOD statsHOD = new StatsHOD(hod_id);
            statsHOD.Show();
        }
    }
}

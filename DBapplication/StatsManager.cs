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
    public partial class StatsManager : Form
    {
        int manager_id;
        Controller controllerObj;
        public StatsManager(int id)
        {
            InitializeComponent();
            manager_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int scount = controllerObj.GetBranchSCount(manager_id);
            textBox1.Text = scount.ToString();
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int rev = controllerObj.GetBranchRevenue(manager_id);
            textBox2.Text = rev.ToString();
            textBox1.Text = "";
        }
    }
}

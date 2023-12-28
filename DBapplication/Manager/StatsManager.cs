using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class StatsManager : Form
    {
        int manager_id;
        Controller controllerObj;
        Form parent;
        public StatsManager(int id,Form parent)
        {
            InitializeComponent();
            manager_id = id;
            this.parent = parent;
            top1.setForms(parent,this);
        }

        private void button1_Click(object sender, EventArgs e) //gets count of all services done by this branch
        {
            controllerObj = new Controller();
            int scount = controllerObj.GetBranchSCount(manager_id);
            textBox1.Text = scount.ToString();
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) //gets total branch revenue
        {
            controllerObj = new Controller();
            int rev = controllerObj.GetBranchRevenue(manager_id);
            textBox2.Text = rev.ToString();
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int result = controllerObj.GetBranchSCount(manager_id) / controllerObj.GetNoEmp(manager_id);
            textBox3.Text = result.ToString();
        }

    }
}

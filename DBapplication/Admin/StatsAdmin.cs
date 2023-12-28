using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public partial class StatsAdmin : Form
    {
        Controller controllerObj;
        Form parent;
        public StatsAdmin(Form parent)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.parent = parent;
            top1.setForms(parent, this);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int result = controllerObj.GetMaxRev();
            textBox1.Text = result.ToString();
            DataTable dt = controllerObj.GetMaxRevBranch();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            textBox2.Text = controllerObj.GetTotalRev().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            dataGridView2.DataSource = controllerObj.GetDepartmentStat();
            dataGridView2.Refresh();
            dataGridView2.Columns[2].HeaderCell.Value = "Sum of Services Count";
            dataGridView2.Columns[3].HeaderCell.Value = "Average of Services Count";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            dataGridView3.DataSource = controllerObj.GetBranchStat();
            dataGridView3.Refresh();
            dataGridView3.Columns[1].HeaderCell.Value = "Number of Requests";
            dataGridView3.Columns[2].HeaderCell.Value = "Total Revenue of Requests";


        }
    }
}

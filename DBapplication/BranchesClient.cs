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
    public partial class BranchesClient : Form
    {
        Controller controllerObj;
        public BranchesClient()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllBranchesCities();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "city";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            if (comboBox1.Text == "")
            {
                DataTable dt = controllerObj.GetAllBranches();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                comboBox1.ResetText();
            }
            else
            {
                DataTable dt = controllerObj.GetAllBranchesFilterCity(comboBox1.Text);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                comboBox1.ResetText();
            }
        }

        private void BranchesClient_Load(object sender, EventArgs e)
        {
            comboBox1.ResetText();
        }
    }
}

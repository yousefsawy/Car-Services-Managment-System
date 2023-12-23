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
        public BranchesClient() //initialize our combobox with the suitable info
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllBranchesCities();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "city";
        }

        private void button1_Click(object sender, EventArgs e) //shows all branches and filter by area if desired
        {
            controllerObj = new Controller();
            if (comboBox1.Text == "")
            {
                DataTable dt = controllerObj.GetAllBranches();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Refresh();
                comboBox1.ResetText();
            }
            else
            {
                DataTable dt = controllerObj.GetAllBranchesFilterCity(comboBox1.Text);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Refresh();
                comboBox1.ResetText();
            }
        }

        private void BranchesClient_Load(object sender, EventArgs e) //empties combobox as it looks better this way
        {
            comboBox1.ResetText();
        }
    }
}

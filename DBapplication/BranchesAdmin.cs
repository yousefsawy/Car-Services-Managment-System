using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public partial class BranchesAdmin : Form
    {
        Controller controllerObj;
        public BranchesAdmin()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllBranches();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "area";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllBranches();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void BranchesAdmin_Load(object sender, EventArgs e)
        {
            comboBox1.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Error! Please, select a branch"); }
            else
            {
                var ans = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    controllerObj = new Controller();
                    int br_id = Convert.ToInt32(comboBox1.SelectedValue);
                    controllerObj.DeleteBranch(br_id);
                    MessageBox.Show("Branch deleted successfully");
                    DataTable dtt = controllerObj.GetAllBranches();
                    comboBox1.DataSource = dtt;
                    comboBox1.ValueMember = "id";
                    comboBox1.DisplayMember = "area";
                    comboBox1.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            string city = textBox1.Text;
            string area = textBox2.Text;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else
            {
                int result = controllerObj.InsertBranch(city, area);
                if (result == 0) { MessageBox.Show("Error! This area is already occupied"); }
                else
                {
                    MessageBox.Show("Branch created successfully");
                    DataTable dt = controllerObj.GetAllBranches();
                    comboBox1.DataSource = dt;
                    comboBox1.ValueMember = "id";
                    comboBox1.DisplayMember = "area";
                    comboBox1.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            string city = textBox1.Text;
            string area = textBox2.Text;
            int br_id = Convert.ToInt32(comboBox1.SelectedValue);
            if (comboBox1.Text == "") { MessageBox.Show("Error! Please, select a branch"); }
            else if (textBox1.TextLength == 0 || textBox2.TextLength == 0) { MessageBox.Show("Error! Please, complete the required info"); }
            else
            {
                controllerObj.UpdateBranch(br_id, city, area);
                MessageBox.Show("Branch updated successfully");
                DataTable dt = controllerObj.GetAllBranches();
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "area";
                comboBox1.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}

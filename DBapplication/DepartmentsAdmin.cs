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
    public partial class DepartmentsAdmin : Form
    {
        Controller controllerObj;
        public DepartmentsAdmin() //initialize our combobox with the suitable info
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllBranches();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "area";
            DataTable dtt = controllerObj.GetAllDeps();
            comboBox2.DataSource = dtt;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "name";
        }

        private void button1_Click(object sender, EventArgs e) //creates a department and assigns it to a branch
        {
            controllerObj = new Controller();
            string name = textBox1.Text;
            string descrip = textBox2.Text;
            int br_id = Convert.ToInt32(comboBox1.SelectedValue);
            if (textBox1.TextLength == 0 || comboBox1.Text == "")
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (textBox2.TextLength == 0)
            {
                controllerObj.InsertDepartment(name, "null", br_id);
                MessageBox.Show("Department created successfully");
                DataTable dtt = controllerObj.GetAllDeps();
                comboBox2.DataSource = dtt;
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                controllerObj.InsertDepartment(name, descrip, br_id);
                MessageBox.Show("Department created successfully");
                DataTable dtt = controllerObj.GetAllDeps();
                comboBox2.DataSource = dtt;
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e) //shows all departments
        {

            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllDeps();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            comboBox2.ResetText();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e) //deletes a department
        {
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a department"); }
            else
            {
                var ans = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    controllerObj = new Controller();
                    int dep_id = Convert.ToInt32(comboBox2.SelectedValue);
                    controllerObj.DeleteDepartment(dep_id);
                    MessageBox.Show("Department deleted successfully");
                    DataTable dtt = controllerObj.GetAllDeps();
                    comboBox2.DataSource = dtt;
                    comboBox2.ValueMember = "id";
                    comboBox2.DisplayMember = "name";
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            
        }

        private void DepartmentsAdmin_Load(object sender, EventArgs e) //empties combobox as it looks better this way
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button3_Click(object sender, EventArgs e) //updates department by assigning it to a different branch
        {
            controllerObj = new Controller();
            int id = Convert.ToInt32(comboBox2.SelectedValue);
            int br_id = Convert.ToInt32(comboBox1.SelectedValue);
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a department"); }
            else if (comboBox1.Text == "") { MessageBox.Show("Error! Please, select a branch"); }
            else
            {
                controllerObj.UpdateDepartment(id, br_id);
                MessageBox.Show("Department updated successfully");
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}

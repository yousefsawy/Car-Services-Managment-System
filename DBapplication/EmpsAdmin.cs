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
    public partial class EmpsAdmin : Form
    {
        int manager_id;
        Controller controllerObj;
        public EmpsAdmin(int id)
        {
            InitializeComponent();
            manager_id = id;
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetDepsBranch(manager_id);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            DataTable dtt = controllerObj.GetEmpsBranch(manager_id);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "fname";
            comboBox2.ValueMember = "id";
        }

        private void EmpsAdmin_Load(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetEmpsBranch(manager_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            comboBox2.ResetText();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int phone;
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            int dep = Convert.ToInt32(comboBox1.SelectedValue);
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || comboBox1.Text == "")
            { MessageBox.Show("Error! Please, complete the required info"); }
            else if (!int.TryParse(textBox3.Text, out phone)) { MessageBox.Show("Error! Please, insert a valid phone"); }
            else if (textBox3.TextLength != 5) { MessageBox.Show("Error! Phone must be 5 characters"); }
            else
            {
                controllerObj = new Controller();
                MessageBox.Show("Employee created successfully");
                controllerObj.InsertEmployee(fname, lname, textBox3.Text, dep);
                DataTable dtt = controllerObj.GetEmpsBranch(manager_id);
                comboBox2.DataSource = dtt;
                comboBox2.DisplayMember = "fname";
                comboBox2.ValueMember = "id";
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select an employee"); }
            else
            {
                var ans = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    MessageBox.Show("Employee deleted successfully");
                    controllerObj = new Controller();
                    controllerObj.DeleteEmployee(Convert.ToInt32(comboBox2.SelectedValue));
                    DataTable dtt = controllerObj.GetEmpsBranch(manager_id);
                    comboBox2.DataSource = dtt;
                    comboBox2.DisplayMember = "fname";
                    comboBox2.ValueMember = "id";
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "") { MessageBox.Show("Error! Please, complete the required info"); }
            else
            {
                MessageBox.Show("Employee updated successfully");
                controllerObj = new Controller();
                controllerObj.UpdateEmployee(Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}

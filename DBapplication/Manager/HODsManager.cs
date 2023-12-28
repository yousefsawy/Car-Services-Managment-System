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
    public partial class HODsManager : Form
    {
        int manager_id;
        Controller controllerObj;
        Form parent;
        public HODsManager(int id, Form parent) //initialize our combobox with the suitable info
        {
            InitializeComponent();
            manager_id = id;
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllUnmanagedDeps(manager_id);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            DataTable dtt = controllerObj.GetAllHODs(manager_id);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "fname";
            comboBox2.ValueMember = "id";
            this.parent = parent;
            top1.setForms(parent, this);
        }

        private void HODsManager_Load(object sender, EventArgs e) //empties combobox as it looks better this way
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button1_Click(object sender, EventArgs e) //creates hod
        {
            controllerObj = new Controller();
            int phone;
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string fname = textBox3.Text;
            string lname = textBox4.Text;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0 ||
                textBox5.TextLength == 0 || comboBox1.Text == "") { MessageBox.Show("Error! Please, complete the required info"); }
            else if (!int.TryParse(textBox5.Text, out phone)) { MessageBox.Show("Error! Please, insert a valid phone"); }
            else if (textBox5.TextLength != 5) { MessageBox.Show("Error! Phone must be 5 characters"); }
            else if (textBox2.TextLength > 10) { MessageBox.Show("Error! Maximum 10 characters for password"); }
            else
            {
                int dep = Convert.ToInt32(comboBox1.SelectedValue);
                int check = controllerObj.InsertHOD(un, pass, fname, lname, textBox5.Text, dep);
                if (check == 0) { MessageBox.Show("Error! This username is already taken"); }
                else
                {
                    MessageBox.Show("HOD created successfully");
                    DataTable dt = controllerObj.GetAllUnmanagedDeps(manager_id);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "id";
                    DataTable dtt = controllerObj.GetAllHODs(manager_id);
                    comboBox2.DataSource = dtt;
                    comboBox2.DisplayMember = "fname";
                    comboBox2.ValueMember = "id";
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //shows all hods in this branch
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllHODs(manager_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            comboBox2.ResetText();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e) //delete hod and make the department unmanaged
        {
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a HOD"); }
            else
            {
                MessageBox.Show("HOD deleted successfully");
                controllerObj = new Controller();
                controllerObj.DeleteHOD(Convert.ToInt32(comboBox2.SelectedValue));
                DataTable dt = controllerObj.GetAllUnmanagedDeps(manager_id);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
                DataTable dtt = controllerObj.GetAllHODs(manager_id);
                comboBox2.DataSource = dtt;
                comboBox2.DisplayMember = "fname";
                comboBox2.ValueMember = "id";
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e) //update hod by making him head of a different unmanaged dep
        {
            if (comboBox1.Text == "" || comboBox2.Text == "") { MessageBox.Show("Error! Please, complete the required info"); }
            else
            {
                MessageBox.Show("HOD updated successfully");
                controllerObj = new Controller();
                controllerObj.UpdateHOD(Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
                DataTable dt = controllerObj.GetAllUnmanagedDeps(manager_id);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
                DataTable dtt = controllerObj.GetAllHODs(manager_id);
                comboBox2.DataSource = dtt;
                comboBox2.DisplayMember = "fname";
                comboBox2.ValueMember = "id";
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class ManagersAdmin : Form
    {
        Controller controllerObj;
        Form parent;
        public ManagersAdmin(Form parent) //initialize our combobox with the suitable info
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dtt = controllerObj.GetAllManagers();
            comboBox2.DataSource = dtt;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "fname";
            DataTable dt = controllerObj.GetAllUnmanagedBranches();
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "area";
            }

            this.parent = parent;
            top1.setForms(parent, this);
        }

        private void ManagersAdmin_Load(object sender, EventArgs e) //empties combobox as it looks better this way
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button1_Click(object sender, EventArgs e) //creates manager and assigns him to branch
        {
            controllerObj = new Controller();
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string fname = textBox3.Text;
            string lname = textBox4.Text;
            string phone = textBox5.Text;
            int br_id = Convert.ToInt32(comboBox1.SelectedValue);
            int x = 0;
            if (un == "" || pass == "" || fname == "" || lname == "" || phone == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (!int.TryParse(phone, out x)) { MessageBox.Show("Error! Please enter a valid phone"); }
            else if (textBox5.TextLength != 5) { MessageBox.Show("Error! Phone should be 5 characters"); }
            else if (textBox2.TextLength > 10) { MessageBox.Show("Error! Maximum 10 characters for password"); }
            else
            {
                int result = controllerObj.InsertManager(un, pass, fname, lname, phone, br_id);
                if (result == 0) { MessageBox.Show("Error! This username is already taken"); }
                else
                {
                    MessageBox.Show("Manager created successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    DataTable dtt = controllerObj.GetAllManagers();
                    comboBox2.DataSource = dtt;
                    comboBox2.ValueMember = "id";
                    comboBox2.DisplayMember = "fname";
                    DataTable dt = controllerObj.GetAllUnmanagedBranches();
                    if (dt != null)
                    {
                        comboBox1.DataSource = dt;
                        comboBox1.ValueMember = "id";
                        comboBox1.DisplayMember = "area";
                    }
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //shows all managers
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllManagers();
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

        private void button4_Click(object sender, EventArgs e) //deletes manager and makes his branch unmanaged
        {
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a manager"); }
            else
            {
                var ans = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    controllerObj = new Controller();
                    int mn_id = Convert.ToInt32(comboBox2.SelectedValue);
                    controllerObj.DeleteManager(mn_id);
                    MessageBox.Show("Manager deleted successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    DataTable dtt = controllerObj.GetAllManagers();
                    comboBox2.DataSource = dtt;
                    comboBox2.ValueMember = "id";
                    comboBox2.DisplayMember = "fname";
                    DataTable dt = controllerObj.GetAllUnmanagedBranches();
                    if (dt != null)
                    {
                        comboBox1.DataSource = dt;
                        comboBox1.ValueMember = "id";
                        comboBox1.DisplayMember = "area";
                    }
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //updates manager by assigning him to new unmanaged branch
        {
            controllerObj = new Controller();
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a manager"); }
            else if (comboBox1.Text == "") { MessageBox.Show("Error! Please, select a branch"); }
            else
            {
                int br_id = Convert.ToInt32(comboBox1.SelectedValue);
                int mn_id = Convert.ToInt32(comboBox2.SelectedValue);
                controllerObj.UpdateManager(mn_id, br_id);
                MessageBox.Show("Manager updated successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                DataTable dtt = controllerObj.GetAllManagers();
                comboBox2.DataSource = dtt;
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "fname";
                DataTable dt = controllerObj.GetAllUnmanagedBranches();
                if (dt != null)
                {
                    comboBox1.DataSource = dt;
                    comboBox1.ValueMember = "id";
                    comboBox1.DisplayMember = "area";
                }
                comboBox1.ResetText();
                comboBox2.ResetText();
            }
        }
    }
}

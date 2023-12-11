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
        public DepartmentsAdmin()
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

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            string name = textBox1.Text;
            string descrip = textBox2.Text;
            int br_id = Convert.ToInt32(comboBox1.SelectedValue);
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (textBox2.TextLength == 0)
            {
                controllerObj.InsertDepartment(name, "null", br_id);
                MessageBox.Show("Department created successfully");
            }
            else
            {
                controllerObj.InsertDepartment(name, descrip, br_id);
                MessageBox.Show("Department created successfully");
            }
        }
    }
}

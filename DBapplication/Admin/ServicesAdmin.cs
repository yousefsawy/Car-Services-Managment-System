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
    public partial class ServicesAdmin : Form
    {
        Controller controllerObj;
        Form parent;
        public ServicesAdmin(Form parent) //initialize our combobox with the suitable info
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllServices();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";
            this.parent = parent;
            top1.setForms(parent, this);
        }

        private void button1_Click(object sender, EventArgs e) //creates new service in the catalogue
        {
            string type = comboBox1.Text;
            string name = textBox1.Text;
            int price;
            if (comboBox1.Text == "" || textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else if (!int.TryParse(textBox2.Text, out price) || price < 0) { MessageBox.Show("Error! Please, enter a valid price"); }
            else
            {
                int result = controllerObj.InsertService(type, name, price);
                if (result == 0) { MessageBox.Show("Error! Please choose a different name"); }
                else
                {
                    MessageBox.Show("Service created successfully");
                    DataTable dt = controllerObj.GetAllServices();
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "name";
                    comboBox2.ValueMember = "id";
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void ServicesAdmin_Load(object sender, EventArgs e) //empties combobox as it looks better this way
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button2_Click(object sender, EventArgs e) //shows all services available
        {
            DataTable dt = controllerObj.GetAllServices();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            comboBox2.ResetText();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) //updates service by changing its price
        {
            controllerObj = new Controller();
            int price;
            int sr_id = Convert.ToInt32(comboBox2.SelectedValue);
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a service"); }
            else if (textBox2.Text == "") { MessageBox.Show("Error! Please, insert a price"); }
            else if (!int.TryParse(textBox2.Text, out price) || price < 0) { MessageBox.Show("Error! Please, enter a valid price"); }
            else
            {
                controllerObj.UpdateService(sr_id, price);
                MessageBox.Show("Service updated successfully");
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e) //deletes service from catalogue
        {
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a service"); }
            else
            {
                var ans = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    controllerObj = new Controller();
                    int sr_id = Convert.ToInt32(comboBox2.SelectedValue);
                    controllerObj.DeleteService(sr_id);
                    MessageBox.Show("Service deleted successfully");
                    DataTable dt = controllerObj.GetAllServices();
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "name";
                    comboBox2.ValueMember = "id";
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //useless
        {

        }
    }
}

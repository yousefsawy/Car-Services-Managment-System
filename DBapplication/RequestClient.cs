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
    public partial class RequestClient : Form
    {
        int client_id;
        Controller controllerObj;
        public RequestClient(int id)
        {
            InitializeComponent();
            client_id = id;
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetAllServicesTypes();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "type";
        }

        private void RequestClient_Load(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();
            comboBox5.ResetText();
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Error! Please, select a service type"); }
            else
            {
                controllerObj = new Controller();
                DataTable dt = controllerObj.GetAllServicesFilterType(comboBox1.Text);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id";
                comboBox2.ResetText();
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "") { MessageBox.Show("Error! Please, select a service"); }
            else
            {
                controllerObj = new Controller();
                DataTable dt = controllerObj.GetAllBranchesFilterSName(comboBox2.Text);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "area";
                comboBox3.ValueMember = "id";
                comboBox3.ResetText();
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int qty;
            if (textBox1.TextLength == 0 || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "") 
            { MessageBox.Show("Error! Please, complete the required info"); }
            else if (!int.TryParse(textBox1.Text, out qty)) { MessageBox.Show("Error! Please, insert a valid quantity"); }
            else
            {
                int service_id = Convert.ToInt32(comboBox2.SelectedValue);
                int br_id = Convert.ToInt32(comboBox3.SelectedValue);
                int slot_id = controllerObj.GetSlotID(comboBox4.Text,Convert.ToInt32(comboBox5.Text),br_id,service_id);
                if (!controllerObj.CheckSlotID(slot_id)) { MessageBox.Show("Error! Please, select another slot"); return; }
                int price = controllerObj.GetServicePrice(comboBox2.Text);
                int total = price * qty;
                textBox2.Text = total.ToString();
                var ans = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    MessageBox.Show("Request completed succussfully");
                    controllerObj.InsertRequest(qty, total, 0, client_id, slot_id, service_id, br_id);
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();
                    comboBox4.ResetText();
                    comboBox5.ResetText();
                    button1.Enabled = false;
                    button3.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }
    }
}

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
    public partial class RequestHOD : Form
    {
        Controller controllerObj;
        int hod_id;
        public RequestHOD(int id)
        {
            InitializeComponent();
            hod_id = id;
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetDepRequests(hod_id);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "id";
            comboBox1.ValueMember = "id";
            DataTable dtt = controllerObj.GetFreeEmp(hod_id);
            comboBox3.DataSource = dtt;
            comboBox3.DisplayMember = "fname";
            comboBox3.ValueMember = "id";
        }

        private void RequestHOD_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetDepRequests(hod_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetDepRequests(hod_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            if (comboBox1.Text == "" || comboBox2.Text == "") { MessageBox.Show("Error! Please, complete the required info"); }
            else
            {
                if (comboBox2.Text == "Decline")
                {
                    controllerObj.DeclineRequest(Convert.ToInt32(comboBox1.Text));
                    MessageBox.Show("Request declined successfully");
                    DataTable dt = controllerObj.GetDepRequests(hod_id);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "id";
                    comboBox1.ValueMember = "id";
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();
                }
                else
                {
                    if (comboBox3.Text == "") { MessageBox.Show("Error! Please, complete the required info"); }
                    else
                    {
                        MessageBox.Show("Request accepted successfully");
                        controllerObj.AcceptRequest(Convert.ToInt32(comboBox1.Text));
                        controllerObj.UpdateCountRevenue(Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(comboBox1.Text));
                        DataTable dt = controllerObj.GetDepRequests(hod_id);
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "id";
                        comboBox1.ValueMember = "id";
                        comboBox1.ResetText();
                        comboBox2.ResetText();
                        comboBox3.ResetText();
                    }
                }
            }
        }
    }
}

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
    public partial class StatsHOD : Form
    {
        int hod_id;
        Controller controllerObj;
        Form parent;
        public StatsHOD(int id, Form parent)
        {
            InitializeComponent();
            hod_id = id;
            this.parent = parent;
            top1.setForms(parent, this);
        }

        private void StatsHOD_Load(object sender, EventArgs e) //useless
        {

        }

        private void button1_Click(object sender, EventArgs e) //gets total services count done by this department
        {
            controllerObj = new Controller();
            int count = controllerObj.GetDepSCount(hod_id);
            textBox1.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //gets services count done by each employee
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetEmpSCount(hod_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}

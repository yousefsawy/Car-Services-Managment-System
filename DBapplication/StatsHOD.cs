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
        public StatsHOD(int id)
        {
            InitializeComponent();
            hod_id = id;
        }

        private void StatsHOD_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int count = controllerObj.GetDepSCount(hod_id);
            textBox1.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetEmpSCount(hod_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}

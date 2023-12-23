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
    public partial class StorageManager : Form
    {
        int manager_id;
        Controller controllerObj;
        public StorageManager(int id)
        {
            this.Parent = Parent;
            InitializeComponent();
            manager_id = id;
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetParts();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void StorageManager_Load(object sender, EventArgs e)
        {
            comboBox1.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetBranchStorage(manager_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            comboBox1.ResetText();
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int qty;
            if (comboBox1.Text == "" || textBox1.TextLength == 0) { MessageBox.Show("Error! Please, complete the required info"); }
            else if (!int.TryParse(textBox1.Text, out qty)) { MessageBox.Show("Error! Please, insert a valid quantity"); }
            else
            {
                MessageBox.Show("Storage updated successfully");
                controllerObj.UpdateStorage(manager_id, Convert.ToInt32(comboBox1.SelectedValue), qty);
                comboBox1.ResetText();
                textBox1.Text = "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public partial class StatsAdmin : Form
    {
        Controller controllerObj;
        Form parent;
        public StatsAdmin(Form parent)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.parent = parent;
            top1.setForms(parent, this);

        }

        private void StatsAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            int result = controllerObj.GetMaxRev();
            textBox1.Text = result.ToString();
        }
    }
}

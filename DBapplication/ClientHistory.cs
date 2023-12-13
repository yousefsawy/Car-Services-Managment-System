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
    public partial class ClientHistory : Form
    {
        int client_id;
        Controller controllerObj;
        public ClientHistory(int id)
        {
            InitializeComponent();
        }

        private void ClientHistory_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetClientHistory(client_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}

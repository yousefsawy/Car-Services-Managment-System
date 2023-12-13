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
    public partial class ClientView : Form
    {
        int client_id;
        public ClientView(int id)
        {
            InitializeComponent();
            client_id = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(client_id, "client");
            changePassword.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BranchesClient branchesClient = new BranchesClient();
            branchesClient.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientHistory clientHistory = new ClientHistory(client_id);
            clientHistory.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestClient requestClient = new RequestClient(client_id);
            requestClient.Show();
        }
    }
}

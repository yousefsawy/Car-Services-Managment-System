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
        Form parent;
        public ClientView(int id, Form Parent)
        {
            InitializeComponent();
            client_id = id;
            this.parent = Parent;
            topLogout1.setForms(parent, this);
        }

        private void button4_Click(object sender, EventArgs e) //changes password
        {
            ChangePassword changePassword = new ChangePassword(client_id, "client",this);
            changePassword.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //view branches and filter by area if desired
        {
            BranchesClient branchesClient = new BranchesClient(this);
            branchesClient.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //view past bookings and review them if desired
        {
            ClientHistory clientHistory = new ClientHistory(client_id,this);
            clientHistory.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //make a request
        {
            RequestClient requestClient = new RequestClient(client_id,this);
            requestClient.Show();
            this.Hide();
        }
    }
}

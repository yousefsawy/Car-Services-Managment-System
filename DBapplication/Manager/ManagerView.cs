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

namespace DBapplication
{
    public partial class ManagerView : Form
    {
        int manager_id;
        Form parent;
        public ManagerView(int id,Form parent)
        {
            InitializeComponent();
            manager_id = id;
            this.parent = parent;
            topLogout1.setForms(parent, this);
        }

        private void button5_Click(object sender, EventArgs e) //changes password
        {
            ChangePassword changePassword = new ChangePassword(manager_id, "manager", this);
            changePassword.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //gets stats considering his branch
        {
            StatsManager statsManager = new StatsManager(manager_id,this);
            statsManager.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //handles branch storage
        {
            StorageManager storageManager = new StorageManager(manager_id,this);
            storageManager.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //crud employees
        {
            EmpsAdmin empsAdmin = new EmpsAdmin(manager_id,this);
            empsAdmin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //crud hods
        {
            HODsManager hODsManager = new HODsManager(manager_id,this);
            hODsManager.Show();
            this.Hide();
        }

    }
}

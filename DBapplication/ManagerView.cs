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
    public partial class ManagerView : Form
    {
        int manager_id;
        public ManagerView(int id)
        {
            InitializeComponent();
            manager_id = id;
        }

        private void button5_Click(object sender, EventArgs e) //changes password
        {
            ChangePassword changePassword = new ChangePassword(manager_id, "manager");
            changePassword.Show();
        }

        private void button4_Click(object sender, EventArgs e) //gets stats considering his branch
        {
            StatsManager statsManager = new StatsManager(manager_id);
            statsManager.Show();
        }

        private void button3_Click(object sender, EventArgs e) //handles branch storage
        {
            StorageManager storageManager = new StorageManager(manager_id);
            storageManager.Show();
        }

        private void button2_Click(object sender, EventArgs e) //crud employees
        {
            EmpsAdmin empsAdmin = new EmpsAdmin(manager_id);
            empsAdmin.Show();
        }

        private void button1_Click(object sender, EventArgs e) //crud hods
        {
            HODsManager hODsManager = new HODsManager(manager_id);
            hODsManager.Show();
        }

    }
}

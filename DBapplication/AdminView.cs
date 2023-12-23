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
    public partial class AdminView : Form
    {
        int admin_id;
        public AdminView(int id)
        {
            InitializeComponent();
            admin_id = id;
        }

        private void AdminView_Load(object sender, EventArgs e) //useless
        {

        }

        private void button6_Click(object sender, EventArgs e) //change password
        {
            ChangePassword changePassword = new ChangePassword(admin_id, "admin");
            changePassword.Show();
        }

        private void button1_Click(object sender, EventArgs e) //crud departments
        {
            DepartmentsAdmin departmentsAdmin = new DepartmentsAdmin();
            departmentsAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e) //crud branches
        {
            BranchesAdmin branchesAdmin = new BranchesAdmin();
            branchesAdmin.Show();
        }

        private void button3_Click(object sender, EventArgs e) //crud services
        {
            ServicesAdmin servicesAdmin = new ServicesAdmin();
            servicesAdmin.Show();
        }

        private void button5_Click(object sender, EventArgs e) //add another admin
        {
            AdminsAdmin adminsAdmin = new AdminsAdmin();
            adminsAdmin.Show();
        }

        private void button4_Click(object sender, EventArgs e) //crud managers
        {
            ManagersAdmin managersAdmin = new ManagersAdmin();
            managersAdmin.Show();
        }
    }
}

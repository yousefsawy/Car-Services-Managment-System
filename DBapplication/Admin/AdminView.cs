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
        Form parent;
        public AdminView(int id, Form parent)
        {
            InitializeComponent();
            admin_id = id;
            this.parent = parent;
            topLogout1.setForms(parent, this);
        }


        private void button6_Click(object sender, EventArgs e) //change password
        {
            ChangePassword changePassword = new ChangePassword(admin_id, "admin",this);
            changePassword.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //crud departments
        {
            DepartmentsAdmin departmentsAdmin = new DepartmentsAdmin(this);
            departmentsAdmin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //crud branches
        {
            BranchesAdmin branchesAdmin = new BranchesAdmin(this);
            branchesAdmin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //crud services
        {
            ServicesAdmin servicesAdmin = new ServicesAdmin(this);
            servicesAdmin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) //add another admin
        {
            AdminsAdmin adminsAdmin = new AdminsAdmin(this);
            adminsAdmin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //crud managers
        {
            ManagersAdmin managersAdmin = new ManagersAdmin(this);
            managersAdmin.Show();
            this.Hide();
        }
    }
}

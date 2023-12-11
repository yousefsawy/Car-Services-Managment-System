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
        Controller controllerObj;
        public AdminView(int id)
        {
            InitializeComponent();
            admin_id = id;
        }

        private void AdminView_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(admin_id, "admin");
            changePassword.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepartmentsAdmin departmentsAdmin = new DepartmentsAdmin();
            departmentsAdmin.Show();
        }
    }
}

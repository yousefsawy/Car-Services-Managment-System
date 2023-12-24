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
    public partial class TopLogout : UserControl
    {
        Form Pr;
        Form Child;
        public bool back;
        public TopLogout()
        {
            InitializeComponent();
            back = false;
        }
        public void setForms(Form parent, Form Child)
        {
            Pr = parent;
            this.Child = Child;
        }

        private void Logout_B_Click(object sender, EventArgs e)
        {
            try
            {
                back = true;
                Pr.Show();
                Child.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

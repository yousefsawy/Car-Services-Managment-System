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
    public partial class Top : UserControl
    {
        Form Pr;
        Form Child;
        public bool back;
        public Top()
        {
            back = false;
            InitializeComponent();
        }


        public void setForms(Form parent, Form Child) {
            Pr = parent;
            this.Child = Child;
        }

        private void Back_B_Click(object sender, EventArgs e)
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

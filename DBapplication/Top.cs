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
        public Form Pr;
        Form Child;
        public Top()
        {
            InitializeComponent();
        }

        public Top(Form parent, Form child)
        {
            Pr = parent;
            Child = child;
            InitializeComponent();
        }


        private void Back_B_Click(object sender, EventArgs e)
        {
            try 
            { 
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

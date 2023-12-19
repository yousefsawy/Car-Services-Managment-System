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
    public partial class Header : UserControl
    {
        Form Parent;
        Form Child;
        public Header(Form parent, Form child)
        {
            InitializeComponent();
            Parent = parent;
            Child = child;
        }

        private void Back_B_Click(object sender, EventArgs e)
        {
            Parent.Show();
            Child.Close();
        }
    }
}

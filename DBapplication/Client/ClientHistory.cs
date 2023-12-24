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
    public partial class ClientHistory : Form
    {
        int client_id;
        Controller controllerObj;
        Form parent;
        public ClientHistory(int id, Form parent) //initialize our combobox with the suitable info
        {
            InitializeComponent();
            client_id = id;
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetClientHistory(id);
            comboBox1.DisplayMember = "id";
            comboBox1.ValueMember = "id";
            this.parent = parent;
            top1.setForms(parent, this);
        }

        private void ClientHistory_Load(object sender, EventArgs e) //initialize our data grid with the suitable info
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetClientHistory(client_id);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dtt = controllerObj.GetClientReviews(client_id);
            dataGridView2.DataSource = dtt;
            dataGridView2.Refresh();
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button1_Click(object sender, EventArgs e) //adds a review to an existing booking
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox1.TextLength == 0)
            {
                MessageBox.Show("Error! Please, complete the required info");
            }
            else
            {
                int book_id = Convert.ToInt32(comboBox1.SelectedValue);
                int rating = Convert.ToInt32(comboBox2.Text);
                string text = textBox1.Text;
                controllerObj = new Controller();
                int result = controllerObj.InsertReview(book_id, rating, text);
                if (result == 0) { MessageBox.Show("Error! Only one review per booking is allowed"); }
                else
                {
                    MessageBox.Show("Review added successfully");
                    DataTable dtt = controllerObj.GetClientReviews(client_id);
                    dataGridView2.DataSource = dtt;
                    dataGridView2.Refresh();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Text = "";
                }
            }
        }
    }
}

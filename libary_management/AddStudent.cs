using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace libary_management
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSName.Text != "" && txtSClass.Text != "" && txtSAddress.Text != "" && txtSEmail.Text != "" && txtSNumber.Text != "" )
            {
                string sName = txtSName.Text;
                string sClass = txtSClass.Text;
                string sAddress = txtSAddress.Text;
                string sNumber = txtSNumber.Text;
                string sEmail = txtSEmail.Text;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                conn.Open();
                cmd.CommandText = "insert into AddStudent(sName,sClass,sAddress,sEmail,sNumber) values ('" + sName + "','" + sClass + "','" + sAddress + "','" + sEmail + "','" + sNumber + "')";
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSName.Clear();
                txtSClass.Clear();
                txtSAddress.Clear();
                txtSEmail.Clear();
                txtSNumber.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field NOT ALlowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE all of your unsave DATA", "Are you sure you want to cancel ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

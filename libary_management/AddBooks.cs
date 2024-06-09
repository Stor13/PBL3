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

namespace libary_management
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtBookName.Text !="" && txtAuthor.Text != "" && txtPrice.Text != "" && txtQuantity.Text !="")
            {
                string bName = txtBookName.Text;
                string bAuthor = txtAuthor.Text;
                string bPdate = dateTimePicker1.Text;
                Int64 bPrice = Int64.Parse(txtPrice.Text);
                Int64 bQuantity = Int64.Parse(txtQuantity.Text);


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                conn.Open();
                cmd.CommandText = "insert into Newbook(bName,bAuthor,bPdate,bPrice,bQuantity) values ('" + bName + "','" + bAuthor + "','" + bPdate + "','" + bPrice + "','" + bQuantity + "')";
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Book Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field NOT ALlowed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

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
    public partial class BookReturn : Form
    {
        public BookReturn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from BookIssue where sNumber = '" + txtSearch.Text + "' and bReturnDate IS NULL";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Name or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BookReturn_Load(object sender, EventArgs e)
        {
            panel2.Visible = false; 
            txtSearch.Clear();
        }

        string bName;
        string bIssueDate;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                bIssueDate = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            txtBName.Text = bName;
            txtBIDate.Text = bIssueDate;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update BookIssue set bReturnDate = '"+dateTimePicker.Text+"' where sNumber = '"+txtSearch.Text+"' and id = '"+rowid+"'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Successful","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            BookReturn_Load(this, null);

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;

            cmd1.CommandText = "select bQuantity from NewBook where bName = '" + bName + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);

            int bQuan = 0;
            if (ds1.Tables[0].Rows.Count != 0)
            {
                bQuan = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                bQuan = bQuan + 1;
            }
            else
            {               
            }
            con1.Open();
            cmd1.CommandText = "update Newbook set bQuantity = '" + bQuan + "' where bName = '" + bName + "'";
            cmd1.ExecuteNonQuery();
            con1.Close();
            MessageBox.Show("Book Quantity updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

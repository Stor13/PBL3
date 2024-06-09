using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace libary_management
{
    public partial class BookDetail : Form
    {
        public BookDetail()
        {
            InitializeComponent();
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from BookIssue where bReturnDate is null";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cmd.CommandText = "select * from BookIssue where bReturnDate is not null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            da.Fill(dts);
            dataGridView2.DataSource = dts.Tables[0];


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtReturn.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from BookIssue where bReturnDate is not null and bName LIKE '%" + txtReturn.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from BookIssue where bReturnDate is not null";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void txtIssue_TextChanged(object sender, EventArgs e)
        {
            if (txtIssue.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from BookIssue where bReturnDate is null and bName LIKE '%" + txtIssue.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from BookIssue where bReturnDate is null";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        string sName, sClass, sAddress, sEmail, sNumber, bName, BIDate, BRDate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                this.Visible = false;
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                sName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                sClass = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                sAddress = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                sEmail = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                sNumber = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                bName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                BIDate = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                BRDate = "NULL";

            }

            BookIssueDetail BID = new BookIssueDetail(sName,sClass,sAddress,sEmail,sNumber,bName,BIDate,BRDate);
            BID.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                this.Visible = false;
                rowid = Int64.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                sName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                sClass = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                sAddress = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                sEmail = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                sNumber = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                bName = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                BIDate = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                BRDate = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();

            }
            BookIssueDetail BID = new BookIssueDetail(sName, sClass, sAddress, sEmail, sNumber, bName, BIDate, BRDate);
            BID.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace libary_management
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.Text != "")
            {
                label1.Visible = false;
                Image img = Image.FromFile("C:\\Users\\ntnga\\Downloads\\Liberay Management System Icon and Images\\Liberay Management System\\search1.gif");
                pictureBox1.Image = img;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from AddStudent where sName LIKE '"+txtSearchName.Text+"%'";  
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                label1.Visible = true;
                Image img = Image.FromFile("C:\\Users\\ntnga\\Downloads\\Liberay Management System Icon and Images\\Liberay Management System\\search.gif");
                pictureBox1.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from AddStudent";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible =   false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AddStudent";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int sId;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                sId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AddStudent where sId = "+sId+"";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtSClass.Text = ds.Tables[0].Rows[0][2].ToString();
            txtSAddress.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSEmail.Text = ds.Tables[0].Rows[0][4].ToString(); ;
            txtSNumber.Text = ds.Tables[0].Rows[0][5].ToString();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sName = txtSName.Text;
            string sClass = txtSClass.Text;
            string sAddress = txtSAddress.Text;
            string sEmail = txtSEmail.Text;
            string sNumber = txtSNumber.Text;


            if (MessageBox.Show("Data will be updated. Confirm ?","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update AddStudent set sName ='" + sName + "', sClass = '" + sClass + "', sAddress = '" + sAddress + "', sEmail = '" + sEmail + "', sNumber = '" + sNumber + "' where sId = " + rowid + "";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewStudent_Load(this, null);
            }



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudent_Load(this, null);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm ?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from AddStudent where sId ="+rowid+"";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved data will not be save", "Are you sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

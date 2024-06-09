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
    public partial class BookIssue : Form
    {
        public BookIssue()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                txtSName.Clear();
                txtSClass.Clear();
                txtSAddress.Clear();
                txtSEmail.Clear();
                txtSNumber.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string objName = txtSearch.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from AddStudent where sNumber = '"+objName+"'";   
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);


                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtSName.Text = ds.Tables[0].Rows[0][1].ToString(); 
                    txtSClass.Text = ds.Tables[0].Rows[0][2].ToString();    
                    txtSAddress.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtSNumber.Text = ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    txtSName.Clear();
                    txtSClass.Clear();
                    txtSAddress.Clear();
                    txtSEmail.Clear();
                    txtSNumber.Clear();
                    MessageBox.Show("Please enter exactly Student Name","Invalid Name",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BookIssue_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management;MultipleActiveResultSets=true; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            cmd.Connection = con;
            con.Open(); 

            cmd = new SqlCommand("select bId from NewBook",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            cmd1 = new SqlCommand("select bName from NewBook", con);
            SqlDataReader sdr1 = cmd1.ExecuteReader();

            while (sdr.Read() && sdr1.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    string id = sdr[i].ToString();
                    string name = sdr1[i].ToString();
                    string book = id + " - " + name;
                    txtBName.Items.Add(book);
                }
            }
            sdr.Close();
            con.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtSName.Text != "")
            {
                if (txtBName.SelectedIndex != -1)
                {
                    string sName = txtSName.Text;
                    string sClass = txtSClass.Text;
                    string sAddress = txtSAddress.Text;
                    string sEmail = txtSEmail.Text;
                    string sNumber = txtSNumber.Text;
                    string bName = txtBName.Text;
                    string bIssueDate = dateTimePicker1.Text;


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into BookIssue(sName,sClass,sAddress,sEmail,sNumber,bName,bIssueDate) values ('"+sName+"','"+sClass+"','"+sAddress+"','"+sEmail+"','"+sNumber+"','"+bName+"','"+bIssueDate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlConnection con1 = new SqlConnection();
                    con1.ConnectionString = "data source = DESKTOP-V748TJ7; database = library_management; integrated security = True ";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con1;

                    cmd1.CommandText = "select bQuantity from NewBook where bName = '" +bName+ "'";
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    int bQuan = 0;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        bQuan = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                        bQuan = bQuan - 1;
                    }
                    else
                    {
                        
                    }
                    con1.Open();
                    cmd1.CommandText = "update Newbook set bQuantity = '" + bQuan + "' where bName = '"+bName+"'";
                    cmd1.ExecuteNonQuery();
                    con1.Close();


                }
                else
                {
                    MessageBox.Show("Please select the book", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter exactly Student Name", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure ?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtBName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

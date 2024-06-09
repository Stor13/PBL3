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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-V748TJ7  ; database = library_management ; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con; ;
            string LookUp = "select * from UserDatabase where username = '" +txtusername.Text+ "' and pass = '" +txtpass.Text+ "'";
            cmd.CommandText = LookUp;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                DashBoard dsb = new DashBoard();
                dsb.Show();
            }
            else 
            {
                MessageBox.Show("Wrong Username or Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}

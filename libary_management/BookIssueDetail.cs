using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libary_management
{
    public partial class BookIssueDetail : Form
    {
        public BookIssueDetail(string sName, string sClass, string sAddress, string sEmail,string sNumber,string bName , string BIDate, string BRDate)
        {
            InitializeComponent();
            txtSName.Text = sName;
            txtSClass.Text = sClass;
            txtSAddress.Text = sAddress;
            txtSEmail.Text = sEmail;
            txtSNumber.Text = sNumber;
            txtBName.Text = bName;
            txtBIDate.Text = BIDate;
            txtBRDate.Text = BRDate;
        }

        private void BookIssueDetail_Load(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            BookDetail bd = new BookDetail();
            bd.Show();
        }
    }
}

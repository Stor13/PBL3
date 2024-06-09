using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libary_management
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit ?","confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBooks vb = new ViewBooks();
            vb.Show();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent aS = new AddStudent();
            aS.Show();
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent vs = new ViewStudent();
            vs.Show();

        }

        private void bookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookIssue BI = new BookIssue();
            BI.Show();
        }

        private void bookReturningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookReturn BR = new BookReturn();
            BR.Show();
        }

        private void bookDetailedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookDetail BD = new BookDetail();
            BD.Show();
        }
    }
}

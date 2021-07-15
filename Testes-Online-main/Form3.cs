using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestesOnline
{
    public partial class Form3 : Form
    {
        private DBAccess data= DBAccess.getInstance();
        public Form3()
        {
            InitializeComponent();

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            string groupname =textBox1.Text;
            int maxnumber = (int) numericUpDown1.Value;
            if (data.createGrp(groupname, maxnumber, data.getPessoa().getNumCC()))
            {

                this.Close();
            }
            this.Close();

        }


    }
}

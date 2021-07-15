using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestesOnline
{
    public partial class Form4 : Form
    {
        private string desi;
        private DBAccess data = DBAccess.getInstance();
        public Form4(string desi)
        {
            this.desi = desi;
            InitializeComponent();
          

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            
            int ncc = (int)numericUpDown1.Value;
            if (data.AddParticipant(ncc, desi))
            {

                this.Close();
            }
            this.Close();

        }

    }
}

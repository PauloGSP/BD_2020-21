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

    public partial class Form5 : Form
    {
        private DBAccess data = DBAccess.getInstance();

        public Form5(string desi)
        {
            InitializeComponent();
            DataTable t = data.showPauta(desi);
            dataGridView1.DataSource = new BindingSource(t, null);


        }

       

       
    }

}

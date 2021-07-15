using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestesOnline
{
    public partial class LogIn : Form
    {
        private DBAccess data;
        
        public LogIn()
        {
            data = DBAccess.getInstance();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (data.login(int.Parse(this.textBox1.Text)))
                    this.Close();
                else
                    this.errorLabel.Text = "Nº de CC não registado!";
            } catch (FormatException)
            {
                this.errorLabel.Text = "Nº de CC inválido!";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestesOnline
{
    public partial class Main : Form
    {
        private DBAccess data;

        public Main()
        {
            data = DBAccess.getInstance();
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            new LogIn().ShowDialog();
            if (data.getPessoa() != null)
                successAction();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {   
            new SignUp().ShowDialog();
            Form2 f = new Form2();
            if (data.getPessoa() != null)
                
                f.FormClosed += (s, args) => Close();
                
            
                successAction();
        }

        private void successAction()
        {
            PersonalPage pp = new PersonalPage();
            pp.FormClosed += (s, args) => Close();

            pp.Show();
            Hide();
        }
    }
}

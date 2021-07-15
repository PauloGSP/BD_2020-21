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
    public partial class SignUp : Form
    {
        private DBAccess DBAccess = DBAccess.getInstance();

        public SignUp()
        {
            InitializeComponent();
            this.label7.Text = "";

            nascInput.MaxDate = DateTime.Now;
            estudanteInput.Checked = true;
            matriculaInput.Enabled = true;

            profAreaCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            profAreaCombo.Items.AddRange(DBAccess.getAreas().ToArray());
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void buttonclick(object sender, EventArgs e)
        {
            try
            {

                string codigoarea;
                Nullable<DateTime> datematricula = null;
                string nome = nomeInput.Text;
                int ncc = (int)nCCInput.Value;
                string temp = emailInput.Text;
                string email;
                if (IsValidEmail(temp))
                {
                    email = emailInput.Text;
                }
                else email = "NULL";


                int telemovel = (int)telemovelInput.Value;
                DateTime NascDate = nascInput.Value;
                string morada = moradaInput.Text;

                if (estudanteInput.Checked)
                {
                    datematricula = matriculaInput.Value;
                    codigoarea = null;
                }
                else
                {
                    codigoarea = profAreaCombo.Text;
                    datematricula = null;

                }
                if (DBAccess.sign(ncc, email, telemovel, NascDate, nome, morada, datematricula, codigoarea))
                {
                    DBAccess.login(ncc);
                    this.Close();
                }
                else
                    this.label7.Text = "bad";

            }
            catch (FormatException)
            {
                this.label7.Text = " inválido!";
            }
        }

        private void estudanteInput_CheckedChanged(object sender, EventArgs e)
        {
            if (!estudanteInput.Checked)
                profInput.Checked = true;
        }

        private void profInput_CheckedChanged(object sender, EventArgs e)
        {
            if (!profInput.Checked)
            {
                estudanteInput.Checked = true;
                profAreaCombo.Enabled = false;
            }
            else
                matriculaInput.Enabled = false;
            profAreaCombo.Enabled = true;
        }

        private void telemovelInput_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TestesOnline
{
    class GroupData
    {
        private string NomeGrupo = null;
        private Nullable<int> NumCCProf = null;
        private string NomeProf = null;
        private int NumParticipantes = 0;
        private int NumMaxParticipantes = 0;
        private Nullable<DateTime> DataUltimaNoticia = null;
        private string TituloUltimaNoticia = null;
        private EventHandler btnEvent = null;
        private EventHandler btnPartsEvent = null;

        private int height = 80;
        private GroupBox groupBox;

        public GroupData (string nomeGrupo, int numParticipantes, int numMaxParticipantes)
        {
            NomeGrupo = nomeGrupo;
            NumParticipantes = numParticipantes;
            NumMaxParticipantes = numMaxParticipantes;

            groupBox = new GroupBox();
        }

        public GroupData addProf(int NumCCProf, string NomeProf)
        {
            this.NumCCProf = NumCCProf;
            this.NomeProf = NomeProf;
            return this;
        }

        public GroupData addProf(string NomeProf)
        {
            this.NomeProf = NomeProf;
            return this;
        }

        public GroupData addUltimaNoticia(DateTime DataUltimaNoticia, string TituloUltimaNoticia)
        {
            this.DataUltimaNoticia = DataUltimaNoticia;
            this.TituloUltimaNoticia = TituloUltimaNoticia;

            height += 30;
            return this;
        }

        public GroupData addBtn(EventHandler e)
        {
            btnEvent = e;
            height += 30;
            return this;
        }
        


        public GroupData addBtnParts(EventHandler e)
        {
            btnPartsEvent = e;
            return this;
        }

        public GroupData render(Control parent, int groupIdx)
        {
            int usableWidth = parent.Width - 6; 

            groupBox.Size = new System.Drawing.Size(usableWidth, height);
            groupBox.Location = new System.Drawing.Point(3, 3 + (height + 5) * groupIdx);
            groupBox.Name = NomeGrupo;
            groupBox.Text = NomeGrupo;
            groupBox.TabIndex = groupIdx;
            groupBox.TabStop = false;

            parent.Controls.Add(groupBox);

            Label labelProf = new Label();
            labelProf.Location = new System.Drawing.Point(8, 25);
            labelProf.Width = groupBox.Width - 16;
            labelProf.Text = "Professor: ";

            if (NomeProf != null)
            {
                labelProf.Text += NomeProf;

                if (NumCCProf != null) labelProf.Text += " (" + NumCCProf + ")";
                else labelProf.Font = new System.Drawing.Font(labelProf.Font, System.Drawing.FontStyle.Bold);
            }
            else
                labelProf.Text += "UNKNOWN";

            groupBox.Controls.Add(labelProf);

            Label labelNumParts = new Label();
            labelNumParts.Location = new System.Drawing.Point(8, 50);
            labelNumParts.Width = groupBox.Width - 16;
            labelNumParts.Text = "Participantes: " + NumParticipantes + "/" + NumMaxParticipantes;

            groupBox.Controls.Add(labelNumParts);


            int top = 0;
            if (TituloUltimaNoticia != null)
            {
                Label labelUltimaNoticia = new Label();
                labelUltimaNoticia.Location = new System.Drawing.Point(8, 70);
                labelUltimaNoticia.Width = groupBox.Width - 16;
                labelUltimaNoticia.Text = DataUltimaNoticia.ToString() + " - " + TituloUltimaNoticia;
                groupBox.Controls.Add(labelUltimaNoticia);

                top = 30;
            }

            Button btn = new Button();
            if (btnEvent != null)
            {
                btn.Height = 30;
                btn.BackColor = System.Drawing.SystemColors.ControlDark;
                btn.Location = new System.Drawing.Point(groupBox.Width - btn.Width - 3 - 10, 70 + top);
                btn.Text = "Open";
                btn.Click += btnEvent;
                groupBox.Controls.Add(btn);
            }

            Button btnParts = new Button();
            if (btnPartsEvent != null)
            {
                btnParts.Height = 30;
                btnParts.BackColor = System.Drawing.SystemColors.ControlDark;
                btnParts.Location = new System.Drawing.Point(groupBox.Width - btn.Width - btnParts.Width - 5 - 3 - 10, 70 + top);
                btnParts.Text = "Participantes";
                btnParts.Click += btnPartsEvent;
                groupBox.Controls.Add(btnParts);
            }
            

            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestesOnline
{
    class TestData
    {
        private string testCode = null;
        private DateTime beginDate;
        private DateTime endDate;
        private Nullable<DateTime> duration = null;
        private int maxGrade = 0;
        private Nullable<int> userGrade = null;
        private string btnText = null;
        private EventHandler btnEvent = null;
        private EventHandler btnPauta = null;
        private EventHandler btnToggle = null;




        private int height = 100;
        private GroupBox groupBox;

        //modulos a criar maxGrade grade duration
        public TestData(string testCode, DateTime beginDate, DateTime endDate, int maxGrade) {
            this.testCode = testCode;
            this.beginDate = beginDate;
            this.endDate = endDate;
            this.maxGrade = maxGrade;


            groupBox = new GroupBox();
        } 

        public TestData addDuration(Nullable<DateTime> duration)
        {
            this.duration = duration;
            return this;
        }

        public TestData addGrade(int grade)
        {
            this.userGrade = grade;
            height += 30;
            return this;
        }
        public TestData addmaxGrade(int maxGrade)
        {
            this.maxGrade = maxGrade;
            return this;
        }

        public TestData addBtn(EventHandler e)
        {
            btnEvent = e;
            height += 30;
            return this;
        }
        public TestData addPauta(EventHandler e)
        {
            btnPauta = e;
            return this;
        }
        public TestData addToggle(EventHandler e)
        {
            btnToggle = e;
            return this;
        }
        public TestData addBtnText(string text)
        {
            btnText = text;
            height += 30;
            return this;
        }

        public TestData render(Control parent, int groupIdx)
        {
            int usableWidth = parent.Width - 6;

            groupBox.Size = new System.Drawing.Size(usableWidth, height);
            groupBox.Location = new System.Drawing.Point(3, 3 + (height + 5) * groupIdx);
            groupBox.Name = testCode;
            groupBox.Text = testCode;
            groupBox.TabIndex = groupIdx;
            groupBox.TabStop = false;

            parent.Controls.Add(groupBox);

            Label labelBD = new Label();
            labelBD.Location = new System.Drawing.Point(8, 25);
            labelBD.Width = groupBox.Width - 16;
            labelBD.Text = "Data de Início: " + beginDate;

            groupBox.Controls.Add(labelBD);

            Label labelED = new Label();
            labelED.Location = new System.Drawing.Point(8, 50);
            labelED.Width = groupBox.Width - 16;
            labelED.Text = "Data de Fim: " + endDate;

            groupBox.Controls.Add(labelED);

            Label labelDuration = new Label();
            labelDuration.Location = new System.Drawing.Point(8, 75);
            labelDuration.Size = new System.Drawing.Size(usableWidth-50, labelDuration.Height);
            labelDuration.Width = groupBox.Width - 16;
            labelDuration.Text = "Duration: ";

            if (duration != null)
                labelDuration.Text += duration.Value;
            else
                labelDuration.Text += "Undefined";

            groupBox.Controls.Add(labelDuration);

            int top = 0;
            if (userGrade != null)
            {
                Label labelGrade = new Label();
                labelGrade.Location = new System.Drawing.Point(8, 100);
                labelGrade.Size = new System.Drawing.Size(usableWidth - 50, labelDuration.Height);
                labelGrade.Width = groupBox.Width - 16;
                labelGrade.Text = "Grade: " + userGrade.Value + "/" + maxGrade;
                groupBox.Controls.Add(labelGrade);
                top = labelGrade.Height;
            }
            Button btn = new Button();

            if (btnText != null)
            {
                btn.Height = 30;
                btn.BackColor = System.Drawing.SystemColors.ControlDark;
                btn.Location = new System.Drawing.Point(groupBox.Width - btn.Width - 3 - 10, 100 + top);
                btn.Text = btnText;
                btn.Click += btnEvent;
                groupBox.Controls.Add(btn);
            }
            Button Pauta = new Button();

            if (btnPauta != null)
            {
                Pauta.Height = 30;
                Pauta.BackColor = System.Drawing.SystemColors.ControlDark;
                Pauta.Location = new System.Drawing.Point(groupBox.Width - btn.Width - 3 - Pauta.Width - 3 - 10, 100 + top);
                Pauta.Text = "Pauta";
                Pauta.Click += btnPauta;
                groupBox.Controls.Add(Pauta);
            }

            Button Toggle = new Button();
            if (btnToggle != null)
            {
                Toggle.Height = 30;
                Toggle.BackColor = System.Drawing.SystemColors.ControlDark;
                Toggle.Location = new System.Drawing.Point(groupBox.Width - Toggle.Width - 3 - btn.Width - 3 - Pauta.Width - 3 - 10, 100 + top);
                Toggle.Text = "Esconder/Mostrar";
                Toggle.Click += btnToggle;
                groupBox.Controls.Add(Toggle);
            }

            return this;
        }

    }





}
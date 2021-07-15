using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestesOnline
{
    public partial class PersonalPage : Form
    {
        private DBAccess data;

        public PersonalPage()
        {
            data = DBAccess.getInstance();
            InitializeComponent();
            loadPageData();
        }

        private void loadPageData()
        {
            Pessoa p = data.getPessoa();
            userName.Text = p.getNome();

            if (!p.getIsAluno())
                alunoBox.Visible = false;
            else
                alunoBoxMatricula.Text += p.getDataMatricula();

            if (!p.getIsProf())
                profBox.Visible = false;
            else
                profBoxArea.Text += p.getAreaDesignacao() + " (" + p.getAreaCodigo() + ")";

            loadGroups();
        }

        

        private void infoPanelToggleBtn_Click(object sender, EventArgs e)
        {
            splitContainer.Panel1Collapsed = !splitContainer.Panel1Collapsed;
            if (splitContainer.Panel1Collapsed)
            {
                infoPanelToggleBtn.Text = ">";
                gruposContainer.Width += 150;
                foreach (Control c in gruposContainer.Controls)
                    c.Width += 150;
            }
            else
            {
                infoPanelToggleBtn.Text = "<";
                gruposContainer.Width -= 150;
                foreach (Control c in gruposContainer.Controls)
                    c.Width -= 150;
            }
        }

        public void addPart(string desi)

        {
            //new Form3(data.getPessoa().getNumCC()).ShowDialog();

            Form4 f = new Form4(desi);
            f.ShowDialog();

            loadGroups();
        }
        private void loadPart(string Designacao, bool isProf)
        {
            pageTitle.Text = "Participantes";
            gruposContainer.Controls.Clear();
            int usableWidth = gruposContainer.Width - 30;

          
            

            DataGridView dgv = new DataGridView();
            dgv.Size = new Size(usableWidth - 6, 450);
            DataTable t = data.showParticipants(Designacao);

            dgv.DataSource = new BindingSource(t, null);
            gruposContainer.Controls.Add(dgv);

            Button canBtn = new Button();
            canBtn.Size = new Size(usableWidth - 6, 30);
            canBtn.Text = "Back";   
            canBtn.Click += new EventHandler((object sender, EventArgs e) => loadGroup(Designacao,isProf));
            gruposContainer.Controls.Add(canBtn);

        }
        private void loadGroups()
        {
            pageTitle.Text = "Os Teus Grupos";
            gruposContainer.Controls.Clear();

            Grupo[] groups = data.getGrupos().ToArray();
            for (int i = 0; i < groups.Length; i++)
            {
                string nome = groups[i].getDesignacaoGrupo();
                bool isProf = groups[i].getProf();
                if (isProf)
                {
                    groups[i].getGroupData()
                        .addBtn(new EventHandler((object sender, EventArgs e) => loadGroup(nome, isProf)))
                        .addBtnParts(new EventHandler((object sender, EventArgs e) => addPart(nome)))
                        .render(gruposContainer, i);
                }else
                {
                    groups[i].getGroupData().addBtn(new EventHandler((object sender ,EventArgs e)=> loadGroup(nome, isProf)))
                        
                        .render(gruposContainer, i);
                }

            }

            if (data.getPessoa().getIsProf())
            {
                Button newBtn = new Button();
                newBtn.Size = new Size(gruposContainer.Width - 6, 30);
                newBtn.Text = "Novo Grupo";
                newBtn.Click += new EventHandler((object sender, EventArgs e) => criarGrupo(data.getPessoa().getNumCC()));
                gruposContainer.Controls.Add(newBtn);
            }
        }

        private void loadGroup(string Designacao, bool isProf)
        {
            pageTitle.Text = Designacao;
            gruposContainer.Controls.Clear();

            Teste[] tests = data.getTestes(Designacao).ToArray();
            for(int i =0; i<tests.Length; i++)
            {
                string nome = tests[i].gettestCode();
                if (isProf) { //maybe tirar a cena de ver o teste not sure
                tests[i].GetTestData().addBtn(new EventHandler((object sender, EventArgs e) => loadPergunta(Designacao,nome)))
                    .addPauta(new EventHandler((object sender, EventArgs e) => loadPauta(nome)))
                    .addToggle(new EventHandler((object sender, EventArgs e) => data.toggleVisibilidadeTeste(nome)))
                    .render(gruposContainer, i);
                }else
                {
                    tests[i].GetTestData().addBtn(new EventHandler((object sender, EventArgs e) => loadPergunta(Designacao, nome))).render(gruposContainer, i);
                }
            }
            if (isProf)
            {
                Button newBtn = new Button();
                newBtn.Size = new Size(gruposContainer.Width - 6, 30);
                newBtn.Text = "Novo Teste";
                newBtn.Click += new EventHandler((object sender, EventArgs e) => criarTeste(Designacao));
                gruposContainer.Controls.Add(newBtn);
                Button part = new Button();
                part.Size = new Size(gruposContainer.Width - 6, 30);
                part.Text = "Lista de Participantes";
                part.Click += new EventHandler((object sender, EventArgs e) => loadPart(Designacao,isProf));
                gruposContainer.Controls.Add(part);

            }

            Button btn = new Button();
            btn.Size = new Size(gruposContainer.Width - 6, 30);
            btn.Text = "Back";
            btn.Click += new EventHandler((object sender, EventArgs e) => loadGroups());
            gruposContainer.Controls.Add(btn);
        }
        public void criarGrupo(int ncc)

        {   
            //new Form3(data.getPessoa().getNumCC()).ShowDialog();

            Form3 f = new Form3();
            f.ShowDialog();
            
            loadGroups();
        }
        public void loadPauta(string desi)

        {

            Form5 f = new Form5(desi);
            
            f.ShowDialog();

        }



        public void criarTeste(string DesignacaoGrupo)
        {
            pageTitle.Text = "Novo Teste";
            gruposContainer.Controls.Clear();

            int usableWidth = gruposContainer.Width - 30;

            Panel form = new Panel();
            form.Location = new System.Drawing.Point(3, 3);
            form.Size = new Size(usableWidth, 225);
            gruposContainer.Controls.Add(form);

            Label labelCodigo = new Label();
            labelCodigo.Font = new System.Drawing.Font(labelCodigo.Font, System.Drawing.FontStyle.Bold);
            labelCodigo.Location = new System.Drawing.Point(7, 15);
            labelCodigo.Size = new System.Drawing.Size(58, 20);
            labelCodigo.Text = "Código";
            form.Controls.Add(labelCodigo);

            TextBox inputCodigo = new TextBox();
            inputCodigo.Location = new System.Drawing.Point(150, 12);
            inputCodigo.Size = new System.Drawing.Size(250, 27);
            form.Controls.Add(inputCodigo);

            Label labelDataInicio = new Label();
            labelDataInicio.Font = new System.Drawing.Font(labelDataInicio.Font, System.Drawing.FontStyle.Bold);
            labelDataInicio.Location = new System.Drawing.Point(7, 52);
            labelDataInicio.Size = new System.Drawing.Size(84, 20);
            labelDataInicio.Text = "Data Ínicio";
            form.Controls.Add(labelDataInicio);

            DateTimePicker inputDataInicio = new DateTimePicker();
            inputDataInicio.Location = new System.Drawing.Point(150, 47);
            inputDataInicio.Size = new System.Drawing.Size(250, 27);
            inputDataInicio.Format = DateTimePickerFormat.Custom;
            inputDataInicio.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            form.Controls.Add(inputDataInicio);

            Label labelDataFim = new Label();
            labelDataFim.Font = new System.Drawing.Font(labelDataFim.Font, System.Drawing.FontStyle.Bold);
            labelDataFim.Location = new System.Drawing.Point(7, 87);
            labelDataFim.Size = new System.Drawing.Size(72, 20);
            labelDataFim.Text = "Data Fim";
            form.Controls.Add(labelDataFim);

            DateTimePicker inputDataFim = new DateTimePicker();
            inputDataFim.Location = new System.Drawing.Point(150, 82);
            inputDataFim.Size = new System.Drawing.Size(250, 27);
            inputDataFim.Format = DateTimePickerFormat.Custom;
            inputDataFim.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            form.Controls.Add(inputDataFim);

            Label labelDuracao = new Label();
            labelDuracao.Font = new System.Drawing.Font(labelDuracao.Font, System.Drawing.FontStyle.Bold);
            labelDuracao.Location = new System.Drawing.Point(7, 123);
            labelDuracao.Size = new System.Drawing.Size(67, 20);
            labelDuracao.Text = "Duração";
            form.Controls.Add(labelDuracao);

            DateTimePicker inputDuracao = new DateTimePicker();
            inputDuracao.Location = new Point(150, 118);
            inputDuracao.Size = new Size(250, 27);
            inputDuracao.Format = DateTimePickerFormat.Time;
            form.Controls.Add(inputDuracao);

            Label labelVisivel = new Label();
            labelVisivel.Font = new Font(labelVisivel.Font, FontStyle.Bold);
            labelVisivel.Location = new Point(7, 158);
            labelVisivel.Size = new Size(60, 17);
            labelVisivel.Text = "Visível";
            form.Controls.Add(labelVisivel);

            CheckBox inputVisivel = new CheckBox();
            inputVisivel.Location = new System.Drawing.Point(150, 161);
            inputVisivel.Size = new System.Drawing.Size(18, 17);
            inputVisivel.UseVisualStyleBackColor = true;
            form.Controls.Add(inputVisivel);

            Label labelCotMax = new Label();
            labelCotMax.Font = new System.Drawing.Font(labelCotMax.Font, System.Drawing.FontStyle.Bold);
            labelCotMax.Location = new System.Drawing.Point(7, 193);
            labelCotMax.Size = new System.Drawing.Size(120, 20);
            labelCotMax.Text = "Cotação Max";
            form.Controls.Add(labelCotMax);

            NumericUpDown inputCotMax = new NumericUpDown();
            inputCotMax.Location = new System.Drawing.Point(150, 190);
            inputCotMax.Size = new System.Drawing.Size(250, 27);
            form.Controls.Add(inputCotMax);

            DataGridView dataGridPerguntas = new DataGridView();
            dataGridPerguntas.Size = new Size(usableWidth, 120);
            dataGridPerguntas.AllowUserToAddRows = false;
            dataGridPerguntas.AllowUserToDeleteRows = false;
            gruposContainer.Controls.Add(dataGridPerguntas);

            DataTable perguntasTable = new DataTable();
            data.getPerguntas().Fill(perguntasTable);
            dataGridPerguntas.DataSource = perguntasTable;
            dataGridPerguntas.Columns[0].Visible = false;

            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.HeaderText = "Select";
            dataGridPerguntas.Columns.Add(checkCol);

            dataGridPerguntas.CellStateChanged += new DataGridViewCellStateChangedEventHandler((object sender, DataGridViewCellStateChangedEventArgs e) => { 
                
            });

            Button svBtn = new Button();
            svBtn.Size = new Size(usableWidth - 6, 30);
            svBtn.Text = "Save";
            svBtn.Click += new EventHandler((object sender, EventArgs e) => {
                DataTable perguntas = new DataTable();
                perguntas.Columns.Add("IdentificadorPergunta");

                foreach (DataGridViewRow row in dataGridPerguntas.Rows)
                {
                    DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell) row.Cells[3];
                    if (!Convert.ToBoolean(check.Value))
                        continue;

                    DataRow r = perguntas.NewRow();
                    r["IdentificadorPergunta"] = (int) row.Cells[0].Value;

                    perguntas.Rows.Add(r);
                }

                data.criarTeste(DesignacaoGrupo, inputCodigo.Text, (int)inputCotMax.Value, inputDataInicio.Value, inputDataFim.Value, inputDuracao.Value, inputVisivel.Checked, perguntas);

                loadGroups();
            });
            gruposContainer.Controls.Add(svBtn);

            Button canBtn = new Button();
            canBtn.Size = new Size(usableWidth - 6, 30);
            canBtn.Text = "Cancel";
            canBtn.Click += new EventHandler((object sender, EventArgs e) => loadGroups());
            gruposContainer.Controls.Add(canBtn);
        }

        private void loadPergunta(string DesignacaoGrupo, string CodigoTeste)
        {
            pageTitle.Text = DesignacaoGrupo + " - " + CodigoTeste;
            gruposContainer.Controls.Clear();

            Pergunta p = data.getProximaPergunta(CodigoTeste);

            if (p == null)
            {
                loadGroup(DesignacaoGrupo, false);
                return;
            }

            //data.responderPergunta(CodigoTeste, p.getIdentificadorPergunta(), null);

            Button btn = new Button();
            btn.Text = "Back";
            btn.Click += new EventHandler((object sender, EventArgs e) => loadGroup(DesignacaoGrupo, false));
            gruposContainer.Controls.Add(btn);

            Label enunciadoPergunta = new Label();
            enunciadoPergunta.Text = p.getEnunciado();
            gruposContainer.Controls.Add(enunciadoPergunta);

            string[] imagens = p.getImagens();
            int imagensHeight = 0;

            int i;
            if (imagens.Length > 0)
            {
                imagensHeight = 175;

                Panel imageContainer = new Panel();
                imageContainer.Location = new Point(5, 50);
                imageContainer.Size = new Size(gruposContainer.Width - 10, imagensHeight);
                imageContainer.AutoScroll = true;

                for (i = 0; i < imagens.Length; i++)
                {
                    PictureBox img = new PictureBox();
                    img.Size = new Size(imagensHeight, imagensHeight);
                    img.Location = new Point((imagensHeight + 5) * i, 0);
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                    img.Load(imagens[i]);
                    imageContainer.Controls.Add(img);
                }

                gruposContainer.Controls.Add(imageContainer);
            }

            Panel optionsContainer = new Panel();
            optionsContainer.Size = new Size(gruposContainer.Width - 10, gruposContainer.Height - imagensHeight - 100);
            optionsContainer.Location = new Point(5, 60 + imagensHeight);
            optionsContainer.AutoScroll = true;

            KeyValuePair<int, string>[] opcoes = p.getOpcoes();
            for (i=0; i< opcoes.Length; i++)
            {
                ButtonBase input = (ButtonBase) Activator.CreateInstance(p.getInputType());
                input.Location = new Point(0, 25 * i);
                input.Width = optionsContainer.Width;
                input.Text = opcoes[i].Value;

                int perguntaId = p.getIdentificadorPergunta();
                int valor = opcoes[i].Key;
                input.Click += new EventHandler((object sender, EventArgs e) => data.responderPergunta(CodigoTeste, perguntaId, valor));

                optionsContainer.Controls.Add(input);
            }

            gruposContainer.Controls.Add(optionsContainer);

            Button btnNext = new Button();
            btnNext.Text = "Next";
            btnNext.Size = new Size(btnNext.Width, 30);
            btnNext.Location = new Point(5, gruposContainer.Height - btnNext.Height);
            btnNext.Click += new EventHandler((object sender, EventArgs e) => loadPergunta(DesignacaoGrupo, CodigoTeste));
            gruposContainer.Controls.Add(btnNext);
        }

        private void perguntasPageBtn_Click(object sender, EventArgs e)
        {
            new PerguntasPool().ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void perguntasPageBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void perguntasPageBtn_Click_2(object sender, EventArgs e)
        {
            new PerguntasPool().ShowDialog();
        }
    }
}

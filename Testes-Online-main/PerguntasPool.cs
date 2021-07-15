using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestesOnline
{
    public partial class PerguntasPool : Form
    {
        DBAccess data = DBAccess.getInstance();

        public PerguntasPool()
        {
            InitializeComponent();

            tipoInput.DropDownStyle = ComboBoxStyle.DropDownList;

            tipoInput.Items.AddRange(data.getTiposPergunta());

            loadGridPerguntas();

            dataGridPerguntas.CellClick += new DataGridViewCellEventHandler((object sender, DataGridViewCellEventArgs e) => dataGridPerguntas_CellClick());
            dataGridImagens.CellClick += new DataGridViewCellEventHandler((object sender, DataGridViewCellEventArgs e) => dataGridImagens_CellClick());
            dataGridOpcoes.CellClick += new DataGridViewCellEventHandler((object sender, DataGridViewCellEventArgs e) => dataGridOpcoes_CellClick());

            dataGridPerguntas.ClearSelection();
            dataGridPerguntas.CurrentCell = null;

            updatePergunta.Enabled = false;
            updateImage.Enabled = false;
            updateOpcao.Enabled = false;
            newPergunta.Enabled = false;
            newImage.Enabled = false;
            newOpcao.Enabled = false;
        }

        private void loadGridPerguntas()
        {
            DataTable perguntasTable = new DataTable();
            data.getPerguntas().Fill(perguntasTable);
            dataGridPerguntas.DataSource = perguntasTable;
            dataGridPerguntas.Columns[0].Visible = false;
        }

        private void loadGridImagens()
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            DataTable imagensTable = new DataTable();
            data.getPerguntaImagens(perguntaId).Fill(imagensTable);
            dataGridImagens.DataSource = imagensTable;
            dataGridImagens.Columns[0].Visible = false;
        }

        private void loadGridOpcoes()
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            DataTable opcoesTable = new DataTable();
            data.getPerguntaOpcoes(perguntaId).Fill(opcoesTable);
            dataGridOpcoes.DataSource = opcoesTable;
            dataGridOpcoes.Columns[0].Visible = false;
        }

        private void dataGridPerguntas_CellClick()
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;

            enunciadoInput.Text = (string)dataGridPerguntas.Rows[rowId].Cells[1].Value;
            tipoInput.SelectedItem = dataGridPerguntas.Rows[rowId].Cells[2].Value;

            loadGridImagens();
            loadGridOpcoes();

            dataGridImagens.ClearSelection();
            dataGridOpcoes.ClearSelection();

            updatePergunta.Enabled = true;
        }

        private void dataGridImagens_CellClick()
        {
            int rowId = (int)dataGridImagens.SelectedCells[0].RowIndex;
            imgLinkInput.Text = (string)dataGridImagens.Rows[rowId].Cells[1].Value;
            imgDescInput.Text = (string)dataGridImagens.Rows[rowId].Cells[2].Value;

            updateImage.Enabled = true;
        }

        private void dataGridOpcoes_CellClick()
        {
            int rowId = (int)dataGridOpcoes.SelectedCells[0].RowIndex;
            opcaoTextoInput.Text = (string)dataGridOpcoes.Rows[rowId].Cells[1].Value;
            opcaoCotacaoInput.Value = (int)dataGridOpcoes.Rows[rowId].Cells[2].Value;

            updateOpcao.Enabled = true;
        }

        private void perguntaForm_Changed(object sender, EventArgs e)
        {
            if (enunciadoInput.Text != "" && tipoInput.SelectedItem != null)
                newPergunta.Enabled = true;
            else
                newPergunta.Enabled = false;
        }

        private void imagemForm_Changed(object sender, EventArgs e)
        {
            if (imgDescInput.Text != "" && imgLinkInput.Text != "")
                newImage.Enabled = true;
            else
                newImage.Enabled = false;
        }

        private void opcaoForm_Changed(object sender, EventArgs e)
        {
            if (opcaoTextoInput.Text != "")
                newOpcao.Enabled = true;
            else
                newOpcao.Enabled = false;
        }

        private void perguntaForm_BtnClick()
        {
            enunciadoInput.Text = "";
            tipoInput.SelectedItem = null;
            updatePergunta.Enabled = false;
            loadGridPerguntas();
        }

        private void imagemForm_BtnClick()
        {
            imgDescInput.Text = "";
            imgLinkInput.Text = "";
            updatePergunta.Enabled = false;
            loadGridImagens();
        }

        private void opcaoForm_BtnClick()
        {
            opcaoTextoInput.Text = "";
            opcaoCotacaoInput.Value = 0;
            updatePergunta.Enabled = false;
            loadGridOpcoes();
        }

        private void newPergunta_Click(object sender, EventArgs e)
        {
            data.createPergunta(enunciadoInput.Text, tipoInput.Text);
            perguntaForm_BtnClick();
        }

        private void updatePergunta_Click(object sender, EventArgs e)
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            data.atualizarPergunta(perguntaId, enunciadoInput.Text, tipoInput.Text);
            perguntaForm_BtnClick();
        }

        private void newImage_Click(object sender, EventArgs e)
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            data.createPerguntaImagem(perguntaId, imgDescInput.Text, imgLinkInput.Text);
            imagemForm_BtnClick();
        }

        private void updateImage_Click(object sender, EventArgs e)
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            int rowImageId = (int)dataGridImagens.SelectedCells[0].RowIndex;
            int perguntaImageId = (int)dataGridImagens.Rows[rowImageId].Cells[0].Value;

            data.atualizarPerguntaImagem(perguntaId, perguntaImageId, imgDescInput.Text, imgLinkInput.Text);
            imagemForm_BtnClick();
        }

        private void newOpcao_Click(object sender, EventArgs e)
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            data.createPerguntaOpcao(perguntaId, opcaoTextoInput.Text, (int) opcaoCotacaoInput.Value);
            opcaoForm_BtnClick();
        }

        private void updateOpcao_Click(object sender, EventArgs e)
        {
            int rowId = (int)dataGridPerguntas.SelectedCells[0].RowIndex;
            int perguntaId = (int)dataGridPerguntas.Rows[rowId].Cells[0].Value;

            int rowOptId = (int)dataGridOpcoes.SelectedCells[0].RowIndex;
            int perguntaOptId = (int)dataGridOpcoes.Rows[rowOptId].Cells[0].Value;

            data.atualizarPerguntaOpcao(perguntaId, perguntaOptId, opcaoTextoInput.Text, (int)opcaoCotacaoInput.Value);
            opcaoForm_BtnClick();
        }
    }
}


namespace TestesOnline
{
    partial class PerguntasPool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridPerguntas = new System.Windows.Forms.DataGridView();
            this.dataGridOpcoes = new System.Windows.Forms.DataGridView();
            this.dataGridImagens = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updatePergunta = new System.Windows.Forms.Button();
            this.newPergunta = new System.Windows.Forms.Button();
            this.tipoInput = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.enunciadoInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imgLinkInput = new System.Windows.Forms.TextBox();
            this.updateImage = new System.Windows.Forms.Button();
            this.newImage = new System.Windows.Forms.Button();
            this.imageLinkInput = new System.Windows.Forms.Label();
            this.imgDescInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.opcaoCotacaoInput = new System.Windows.Forms.NumericUpDown();
            this.updateOpcao = new System.Windows.Forms.Button();
            this.newOpcao = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.opcaoTextoInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOpcoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImagens)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcaoCotacaoInput)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPerguntas
            // 
            this.dataGridPerguntas.AllowUserToAddRows = false;
            this.dataGridPerguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPerguntas.Location = new System.Drawing.Point(13, 101);
            this.dataGridPerguntas.MultiSelect = false;
            this.dataGridPerguntas.Name = "dataGridPerguntas";
            this.dataGridPerguntas.ReadOnly = true;
            this.dataGridPerguntas.RowHeadersWidth = 51;
            this.dataGridPerguntas.RowTemplate.Height = 29;
            this.dataGridPerguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPerguntas.Size = new System.Drawing.Size(424, 337);
            this.dataGridPerguntas.TabIndex = 0;
            // 
            // dataGridOpcoes
            // 
            this.dataGridOpcoes.AllowUserToAddRows = false;
            this.dataGridOpcoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOpcoes.Location = new System.Drawing.Point(454, 318);
            this.dataGridOpcoes.MultiSelect = false;
            this.dataGridOpcoes.Name = "dataGridOpcoes";
            this.dataGridOpcoes.ReadOnly = true;
            this.dataGridOpcoes.RowHeadersWidth = 51;
            this.dataGridOpcoes.RowTemplate.Height = 29;
            this.dataGridOpcoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOpcoes.Size = new System.Drawing.Size(334, 120);
            this.dataGridOpcoes.TabIndex = 2;
            // 
            // dataGridImagens
            // 
            this.dataGridImagens.AllowUserToAddRows = false;
            this.dataGridImagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridImagens.Location = new System.Drawing.Point(454, 101);
            this.dataGridImagens.MultiSelect = false;
            this.dataGridImagens.Name = "dataGridImagens";
            this.dataGridImagens.ReadOnly = true;
            this.dataGridImagens.RowHeadersWidth = 51;
            this.dataGridImagens.RowTemplate.Height = 29;
            this.dataGridImagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridImagens.Size = new System.Drawing.Size(334, 120);
            this.dataGridImagens.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updatePergunta);
            this.groupBox1.Controls.Add(this.newPergunta);
            this.groupBox1.Controls.Add(this.tipoInput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.enunciadoInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // updatePergunta
            // 
            this.updatePergunta.Location = new System.Drawing.Point(337, 53);
            this.updatePergunta.Name = "updatePergunta";
            this.updatePergunta.Size = new System.Drawing.Size(81, 29);
            this.updatePergunta.TabIndex = 5;
            this.updatePergunta.Text = "Atualizar";
            this.updatePergunta.UseVisualStyleBackColor = true;
            this.updatePergunta.Click += new System.EventHandler(this.updatePergunta_Click);
            // 
            // newPergunta
            // 
            this.newPergunta.Location = new System.Drawing.Point(249, 53);
            this.newPergunta.Name = "newPergunta";
            this.newPergunta.Size = new System.Drawing.Size(81, 29);
            this.newPergunta.TabIndex = 4;
            this.newPergunta.Text = "Adicionar";
            this.newPergunta.UseVisualStyleBackColor = true;
            this.newPergunta.Click += new System.EventHandler(this.newPergunta_Click);
            // 
            // tipoInput
            // 
            this.tipoInput.FormattingEnabled = true;
            this.tipoInput.Location = new System.Drawing.Point(91, 54);
            this.tipoInput.Name = "tipoInput";
            this.tipoInput.Size = new System.Drawing.Size(151, 28);
            this.tipoInput.TabIndex = 3;
            this.tipoInput.SelectedIndexChanged += new System.EventHandler(this.perguntaForm_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // enunciadoInput
            // 
            this.enunciadoInput.Location = new System.Drawing.Point(91, 18);
            this.enunciadoInput.Name = "enunciadoInput";
            this.enunciadoInput.Size = new System.Drawing.Size(327, 27);
            this.enunciadoInput.TabIndex = 1;
            this.enunciadoInput.TextChanged += new System.EventHandler(this.perguntaForm_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enunciado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imgLinkInput);
            this.groupBox2.Controls.Add(this.updateImage);
            this.groupBox2.Controls.Add(this.newImage);
            this.groupBox2.Controls.Add(this.imageLinkInput);
            this.groupBox2.Controls.Add(this.imgDescInput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(454, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 92);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // imgLinkInput
            // 
            this.imgLinkInput.Location = new System.Drawing.Point(54, 54);
            this.imgLinkInput.Name = "imgLinkInput";
            this.imgLinkInput.Size = new System.Drawing.Size(102, 27);
            this.imgLinkInput.TabIndex = 6;
            this.imgLinkInput.TextChanged += new System.EventHandler(this.imagemForm_Changed);
            // 
            // updateImage
            // 
            this.updateImage.Location = new System.Drawing.Point(249, 53);
            this.updateImage.Name = "updateImage";
            this.updateImage.Size = new System.Drawing.Size(81, 29);
            this.updateImage.TabIndex = 5;
            this.updateImage.Text = "Atualizar";
            this.updateImage.UseVisualStyleBackColor = true;
            this.updateImage.Click += new System.EventHandler(this.updateImage_Click);
            // 
            // newImage
            // 
            this.newImage.Location = new System.Drawing.Point(162, 53);
            this.newImage.Name = "newImage";
            this.newImage.Size = new System.Drawing.Size(81, 29);
            this.newImage.TabIndex = 4;
            this.newImage.Text = "Adicionar";
            this.newImage.UseVisualStyleBackColor = true;
            this.newImage.Click += new System.EventHandler(this.newImage_Click);
            // 
            // imageLinkInput
            // 
            this.imageLinkInput.AutoSize = true;
            this.imageLinkInput.Location = new System.Drawing.Point(7, 57);
            this.imageLinkInput.Name = "imageLinkInput";
            this.imageLinkInput.Size = new System.Drawing.Size(35, 20);
            this.imageLinkInput.TabIndex = 2;
            this.imageLinkInput.Text = "Link";
            // 
            // imgDescInput
            // 
            this.imgDescInput.Location = new System.Drawing.Point(54, 18);
            this.imgDescInput.Name = "imgDescInput";
            this.imgDescInput.Size = new System.Drawing.Size(276, 27);
            this.imgDescInput.TabIndex = 1;
            this.imgDescInput.TextChanged += new System.EventHandler(this.imagemForm_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Desc";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.opcaoCotacaoInput);
            this.groupBox3.Controls.Add(this.updateOpcao);
            this.groupBox3.Controls.Add(this.newOpcao);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.opcaoTextoInput);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(454, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 92);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // opcaoCotacaoInput
            // 
            this.opcaoCotacaoInput.Location = new System.Drawing.Point(77, 55);
            this.opcaoCotacaoInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.opcaoCotacaoInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.opcaoCotacaoInput.Name = "opcaoCotacaoInput";
            this.opcaoCotacaoInput.Size = new System.Drawing.Size(79, 27);
            this.opcaoCotacaoInput.TabIndex = 6;
            // 
            // updateOpcao
            // 
            this.updateOpcao.Location = new System.Drawing.Point(249, 53);
            this.updateOpcao.Name = "updateOpcao";
            this.updateOpcao.Size = new System.Drawing.Size(81, 29);
            this.updateOpcao.TabIndex = 5;
            this.updateOpcao.Text = "Atualizar";
            this.updateOpcao.UseVisualStyleBackColor = true;
            this.updateOpcao.Click += new System.EventHandler(this.updateOpcao_Click);
            // 
            // newOpcao
            // 
            this.newOpcao.Location = new System.Drawing.Point(162, 53);
            this.newOpcao.Name = "newOpcao";
            this.newOpcao.Size = new System.Drawing.Size(81, 29);
            this.newOpcao.TabIndex = 4;
            this.newOpcao.Text = "Adicionar";
            this.newOpcao.UseVisualStyleBackColor = true;
            this.newOpcao.Click += new System.EventHandler(this.newOpcao_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cotacao";
            // 
            // opcaoTextoInput
            // 
            this.opcaoTextoInput.Location = new System.Drawing.Point(77, 18);
            this.opcaoTextoInput.Name = "opcaoTextoInput";
            this.opcaoTextoInput.Size = new System.Drawing.Size(253, 27);
            this.opcaoTextoInput.TabIndex = 1;
            this.opcaoTextoInput.TextChanged += new System.EventHandler(this.opcaoForm_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Texto";
            // 
            // PerguntasPool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridImagens);
            this.Controls.Add(this.dataGridOpcoes);
            this.Controls.Add(this.dataGridPerguntas);
            this.Name = "PerguntasPool";
            this.Text = "PerguntasPool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOpcoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImagens)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcaoCotacaoInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPerguntas;
        private System.Windows.Forms.DataGridView dataGridOpcoes;
        private System.Windows.Forms.DataGridView dataGridImagens;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox enunciadoInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updatePergunta;
        private System.Windows.Forms.Button newPergunta;
        private System.Windows.Forms.ComboBox tipoInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox imgLinkInput;
        private System.Windows.Forms.Button updateImage;
        private System.Windows.Forms.Button newImage;
        private System.Windows.Forms.Label imageLinkInput;
        private System.Windows.Forms.TextBox imgDescInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown opcaoCotacaoInput;
        private System.Windows.Forms.Button updateOpcao;
        private System.Windows.Forms.Button newOpcao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox opcaoTextoInput;
        private System.Windows.Forms.Label label6;
    }
}
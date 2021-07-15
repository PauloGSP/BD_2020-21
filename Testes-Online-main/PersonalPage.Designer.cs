
namespace TestesOnline
{
    partial class PersonalPage
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.alunoBox = new System.Windows.Forms.GroupBox();
            this.alunoBoxMatricula = new System.Windows.Forms.Label();
            this.alunoBoxMatriculalabel = new System.Windows.Forms.Label();
            this.profBox = new System.Windows.Forms.GroupBox();
            this.profBoxArea = new System.Windows.Forms.Label();
            this.perguntasPageBtn = new System.Windows.Forms.Button();
            this.profBoxArealabel = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gruposContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.infoPanelToggleBtn = new System.Windows.Forms.Button();
            this.pageTitle = new System.Windows.Forms.Label();
            this.pessoaNome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.alunoBox.SuspendLayout();
            this.profBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.flowLayoutPanel3);
            this.splitContainer.Panel1.Controls.Add(this.userName);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gruposContainer);
            this.splitContainer.Panel2.Controls.Add(this.infoPanelToggleBtn);
            this.splitContainer.Panel2.Controls.Add(this.pageTitle);
            this.splitContainer.Size = new System.Drawing.Size(800, 450);
            this.splitContainer.SplitterDistance = 150;
            this.splitContainer.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.alunoBox);
            this.flowLayoutPanel3.Controls.Add(this.profBox);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(12, 191);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(135, 247);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // alunoBox
            // 
            this.alunoBox.Controls.Add(this.alunoBoxMatricula);
            this.alunoBox.Controls.Add(this.alunoBoxMatriculalabel);
            this.alunoBox.Location = new System.Drawing.Point(3, 3);
            this.alunoBox.Name = "alunoBox";
            this.alunoBox.Size = new System.Drawing.Size(132, 72);
            this.alunoBox.TabIndex = 5;
            this.alunoBox.TabStop = false;
            this.alunoBox.Text = "Aluno";
            // 
            // alunoBoxMatricula
            // 
            this.alunoBoxMatricula.AutoSize = true;
            this.alunoBoxMatricula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alunoBoxMatricula.Location = new System.Drawing.Point(6, 43);
            this.alunoBoxMatricula.Name = "alunoBoxMatricula";
            this.alunoBoxMatricula.Size = new System.Drawing.Size(0, 20);
            this.alunoBoxMatricula.TabIndex = 3;
            // 
            // alunoBoxMatriculalabel
            // 
            this.alunoBoxMatriculalabel.AutoSize = true;
            this.alunoBoxMatriculalabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.alunoBoxMatriculalabel.Location = new System.Drawing.Point(6, 23);
            this.alunoBoxMatriculalabel.Name = "alunoBoxMatriculalabel";
            this.alunoBoxMatriculalabel.Size = new System.Drawing.Size(170, 20);
            this.alunoBoxMatriculalabel.TabIndex = 2;
            this.alunoBoxMatriculalabel.Text = "Matrícula:                       ";
            // 
            // profBox
            // 
            this.profBox.Controls.Add(this.profBoxArea);
            this.profBox.Controls.Add(this.perguntasPageBtn);
            this.profBox.Controls.Add(this.profBoxArealabel);
            this.profBox.Location = new System.Drawing.Point(3, 81);
            this.profBox.Name = "profBox";
            this.profBox.Size = new System.Drawing.Size(132, 110);
            this.profBox.TabIndex = 6;
            this.profBox.TabStop = false;
            this.profBox.Text = "Professor";
            // 
            // profBoxArea
            // 
            this.profBoxArea.AutoSize = true;
            this.profBoxArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.profBoxArea.Location = new System.Drawing.Point(7, 43);
            this.profBoxArea.Name = "profBoxArea";
            this.profBoxArea.Size = new System.Drawing.Size(0, 20);
            this.profBoxArea.TabIndex = 4;
            // 
            // perguntasPageBtn
            // 
            this.perguntasPageBtn.Location = new System.Drawing.Point(7, 75);
            this.perguntasPageBtn.Name = "perguntasPageBtn";
            this.perguntasPageBtn.Size = new System.Drawing.Size(119, 29);
            this.perguntasPageBtn.TabIndex = 3;
            this.perguntasPageBtn.Text = "Perguntas";
            this.perguntasPageBtn.UseVisualStyleBackColor = true;
            this.perguntasPageBtn.Click += new System.EventHandler(this.perguntasPageBtn_Click_2);
            // 
            // profBoxArealabel
            // 
            this.profBoxArealabel.AutoSize = true;
            this.profBoxArealabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.profBoxArealabel.Location = new System.Drawing.Point(6, 23);
            this.profBoxArealabel.Name = "profBoxArealabel";
            this.profBoxArealabel.Size = new System.Drawing.Size(189, 20);
            this.profBoxArealabel.TabIndex = 2;
            this.profBoxArealabel.Text = "Área:                                    ";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userName.Location = new System.Drawing.Point(12, 37);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(0, 20);
            this.userName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bem Vindo";
            // 
            // gruposContainer
            // 
            this.gruposContainer.AutoScroll = true;
            this.gruposContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gruposContainer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gruposContainer.Location = new System.Drawing.Point(3, 54);
            this.gruposContainer.Name = "gruposContainer";
            this.gruposContainer.Size = new System.Drawing.Size(640, 384);
            this.gruposContainer.TabIndex = 5;
            // 
            // infoPanelToggleBtn
            // 
            this.infoPanelToggleBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.infoPanelToggleBtn.Location = new System.Drawing.Point(3, 3);
            this.infoPanelToggleBtn.Name = "infoPanelToggleBtn";
            this.infoPanelToggleBtn.Size = new System.Drawing.Size(45, 45);
            this.infoPanelToggleBtn.TabIndex = 4;
            this.infoPanelToggleBtn.Text = "<";
            this.infoPanelToggleBtn.UseVisualStyleBackColor = true;
            this.infoPanelToggleBtn.Click += new System.EventHandler(this.infoPanelToggleBtn_Click);
            // 
            // pageTitle
            // 
            this.pageTitle.AutoSize = true;
            this.pageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pageTitle.Location = new System.Drawing.Point(54, 9);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(146, 28);
            this.pageTitle.TabIndex = 3;
            this.pageTitle.Text = "Os Teus Grupos";
            // 
            // pessoaNome
            // 
            this.pessoaNome.AutoSize = true;
            this.pessoaNome.Location = new System.Drawing.Point(12, 49);
            this.pessoaNome.Name = "pessoaNome";
            this.pessoaNome.Size = new System.Drawing.Size(50, 20);
            this.pessoaNome.TabIndex = 0;
            this.pessoaNome.Text = "label1";
            // 
            // PersonalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Name = "PersonalPage";
            this.Text = "PersonalPage";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.alunoBox.ResumeLayout(false);
            this.alunoBox.PerformLayout();
            this.profBox.ResumeLayout(false);
            this.profBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label pessoaNome;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button infoPanelToggleBtn;
        private System.Windows.Forms.Label pageTitle;
        private System.Windows.Forms.FlowLayoutPanel gruposContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.GroupBox alunoBox;
        private System.Windows.Forms.Label alunoBoxMatriculalabel;
        private System.Windows.Forms.GroupBox profBox;
        private System.Windows.Forms.Button perguntasPageBtn;
        private System.Windows.Forms.Label profBoxArealabel;
        private System.Windows.Forms.Label alunoBoxMatricula;
        private System.Windows.Forms.Label profBoxArea;
    }
}
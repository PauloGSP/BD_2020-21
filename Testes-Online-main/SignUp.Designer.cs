
namespace TestesOnline
{
    partial class SignUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nomeInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.moradaInput = new System.Windows.Forms.TextBox();
            this.estudanteInput = new System.Windows.Forms.CheckBox();
            this.profInput = new System.Windows.Forms.CheckBox();
            this.nascInput = new System.Windows.Forms.DateTimePicker();
            this.registarBtn = new System.Windows.Forms.Button();
            this.nCCInput = new System.Windows.Forms.NumericUpDown();
            this.telemovelInput = new System.Windows.Forms.NumericUpDown();
            this.profAreaCombo = new System.Windows.Forms.ComboBox();
            this.matriculaInput = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nCCInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telemovelInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(39, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nº de CC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(39, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(209, 132);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(262, 27);
            this.emailInput.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(39, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Telemovel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(39, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Data Nascimento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(39, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nome";
            // 
            // nomeInput
            // 
            this.nomeInput.Location = new System.Drawing.Point(209, 40);
            this.nomeInput.Name = "nomeInput";
            this.nomeInput.Size = new System.Drawing.Size(262, 27);
            this.nomeInput.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(39, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Morada";
            // 
            // moradaInput
            // 
            this.moradaInput.Location = new System.Drawing.Point(209, 273);
            this.moradaInput.Name = "moradaInput";
            this.moradaInput.Size = new System.Drawing.Size(262, 27);
            this.moradaInput.TabIndex = 18;
            // 
            // estudanteInput
            // 
            this.estudanteInput.AutoSize = true;
            this.estudanteInput.Location = new System.Drawing.Point(267, 329);
            this.estudanteInput.Name = "estudanteInput";
            this.estudanteInput.Size = new System.Drawing.Size(204, 24);
            this.estudanteInput.TabIndex = 20;
            this.estudanteInput.Text = "Iniciar Conta de Estudante";
            this.estudanteInput.UseVisualStyleBackColor = true;
            this.estudanteInput.CheckedChanged += new System.EventHandler(this.estudanteInput_CheckedChanged);
            // 
            // profInput
            // 
            this.profInput.AutoSize = true;
            this.profInput.Location = new System.Drawing.Point(267, 367);
            this.profInput.Name = "profInput";
            this.profInput.Size = new System.Drawing.Size(200, 24);
            this.profInput.TabIndex = 21;
            this.profInput.Text = "Iniciar Conta de Professor";
            this.profInput.UseVisualStyleBackColor = true;
            this.profInput.CheckedChanged += new System.EventHandler(this.profInput_CheckedChanged);
            // 
            // nascInput
            // 
            this.nascInput.Location = new System.Drawing.Point(209, 224);
            this.nascInput.Name = "nascInput";
            this.nascInput.Size = new System.Drawing.Size(262, 27);
            this.nascInput.TabIndex = 22;
            // 
            // registarBtn
            // 
            this.registarBtn.Location = new System.Drawing.Point(39, 420);
            this.registarBtn.Name = "registarBtn";
            this.registarBtn.Size = new System.Drawing.Size(432, 29);
            this.registarBtn.TabIndex = 23;
            this.registarBtn.Text = "Registar";
            this.registarBtn.UseVisualStyleBackColor = true;
            this.registarBtn.Click += new System.EventHandler(this.buttonclick);
            // 
            // nCCInput
            // 
            this.nCCInput.Location = new System.Drawing.Point(209, 87);
            this.nCCInput.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nCCInput.Name = "nCCInput";
            this.nCCInput.Size = new System.Drawing.Size(262, 27);
            this.nCCInput.TabIndex = 24;
            // 
            // telemovelInput
            // 
            this.telemovelInput.Location = new System.Drawing.Point(209, 178);
            this.telemovelInput.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.telemovelInput.Name = "telemovelInput";
            this.telemovelInput.Size = new System.Drawing.Size(262, 27);
            this.telemovelInput.TabIndex = 25;
            this.telemovelInput.ValueChanged += new System.EventHandler(this.telemovelInput_ValueChanged);
            // 
            // profAreaCombo
            // 
            this.profAreaCombo.Enabled = false;
            this.profAreaCombo.FormattingEnabled = true;
            this.profAreaCombo.Location = new System.Drawing.Point(39, 365);
            this.profAreaCombo.Name = "profAreaCombo";
            this.profAreaCombo.Size = new System.Drawing.Size(222, 28);
            this.profAreaCombo.TabIndex = 26;
            // 
            // matriculaInput
            // 
            this.matriculaInput.Location = new System.Drawing.Point(39, 325);
            this.matriculaInput.Name = "matriculaInput";
            this.matriculaInput.Size = new System.Drawing.Size(222, 27);
            this.matriculaInput.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "label7";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 476);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.matriculaInput);
            this.Controls.Add(this.profAreaCombo);
            this.Controls.Add(this.telemovelInput);
            this.Controls.Add(this.nCCInput);
            this.Controls.Add(this.registarBtn);
            this.Controls.Add(this.nascInput);
            this.Controls.Add(this.profInput);
            this.Controls.Add(this.estudanteInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.moradaInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nomeInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.label1);
            this.Name = "SignUp";
            this.Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)(this.nCCInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telemovelInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nomeInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox moradaInput;
        private System.Windows.Forms.CheckBox estudanteInput;
        private System.Windows.Forms.CheckBox profInput;
        private System.Windows.Forms.DateTimePicker nascInput;
        
        private System.Windows.Forms.Button registarBtn;
        private System.Windows.Forms.NumericUpDown nCCInput;
        private System.Windows.Forms.NumericUpDown telemovelInput;
        private System.Windows.Forms.ComboBox profAreaCombo;
        //private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DateTimePicker matriculaInput;
        private System.Windows.Forms.Label label7;
    }
}
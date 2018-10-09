namespace HematoLab.Reporte
{
    partial class FormReporteParamtro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteParamtro));
            this.cboFechasEstudios = new System.Windows.Forms.ComboBox();
            this.txtDniFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstPacientes = new System.Windows.Forms.ListBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboFechasEstudios
            // 
            this.cboFechasEstudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFechasEstudios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFechasEstudios.FormattingEnabled = true;
            this.cboFechasEstudios.Location = new System.Drawing.Point(557, 218);
            this.cboFechasEstudios.Name = "cboFechasEstudios";
            this.cboFechasEstudios.Size = new System.Drawing.Size(140, 22);
            this.cboFechasEstudios.TabIndex = 1;
            // 
            // txtDniFind
            // 
            this.txtDniFind.Location = new System.Drawing.Point(26, 384);
            this.txtDniFind.MaxLength = 8;
            this.txtDniFind.Name = "txtDniFind";
            this.txtDniFind.Size = new System.Drawing.Size(82, 22);
            this.txtDniFind.TabIndex = 3;
            this.txtDniFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniFind_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Paciente";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(336, 165);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(28, 14);
            this.lblPaciente.TabIndex = 6;
            this.lblPaciente.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Listado fechas de estudios realizados";
            // 
            // lstPacientes
            // 
            this.lstPacientes.FormattingEnabled = true;
            this.lstPacientes.ItemHeight = 14;
            this.lstPacientes.Location = new System.Drawing.Point(26, 82);
            this.lstPacientes.Name = "lstPacientes";
            this.lstPacientes.Size = new System.Drawing.Size(141, 298);
            this.lstPacientes.TabIndex = 8;
            this.lstPacientes.SelectedIndexChanged += new System.EventHandler(this.lstPacientes_SelectedIndexChanged);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(250, 384);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 22);
            this.txtDni.TabIndex = 9;
            this.txtDni.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HematoLab.Properties.Resources.icons8_historial_médico_64;
            this.pictureBox1.Location = new System.Drawing.Point(423, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 73);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Image = global::HematoLab.Properties.Resources.icons8_Search_32;
            this.btnFiltrar.Location = new System.Drawing.Point(114, 384);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(53, 22);
            this.btnFiltrar.TabIndex = 38;
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Image = global::HematoLab.Properties.Resources.icons8_View_Details_32;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporte.Location = new System.Drawing.Point(720, 216);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(111, 25);
            this.btnReporte.TabIndex = 2;
            this.btnReporte.Text = "Consultar";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // FormReporteParamtro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(857, 436);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lstPacientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDniFind);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.cboFechasEstudios);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormReporteParamtro";
            this.Padding = new System.Windows.Forms.Padding(23, 65, 23, 22);
            this.Resizable = false;
            this.Text = "Evolución del paciente";
            this.Load += new System.EventHandler(this.FormReporteParamtro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFechasEstudios;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.TextBox txtDniFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstPacientes;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
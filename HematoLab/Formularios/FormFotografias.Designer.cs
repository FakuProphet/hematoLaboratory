namespace HematoLab.Formularios
{
    partial class FormFotografias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFotografias));
            this.groupBoxFoto = new System.Windows.Forms.GroupBox();
            this.txtTipoPersonal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.PBMostrarImagen = new System.Windows.Forms.PictureBox();
            this.txtExaminar = new System.Windows.Forms.TextBox();
            this.btnAF = new System.Windows.Forms.Button();
            this.btnAcF = new System.Windows.Forms.Button();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.groupBoxDispositivo = new System.Windows.Forms.GroupBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCamaras = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrarImagen)).BeginInit();
            this.groupBoxDispositivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFoto
            // 
            this.groupBoxFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBoxFoto.Controls.Add(this.txtTipoPersonal);
            this.groupBoxFoto.Controls.Add(this.label1);
            this.groupBoxFoto.Controls.Add(this.lblLegajo);
            this.groupBoxFoto.Controls.Add(this.btnSalir);
            this.groupBoxFoto.Controls.Add(this.PBMostrarImagen);
            this.groupBoxFoto.Controls.Add(this.txtExaminar);
            this.groupBoxFoto.Controls.Add(this.btnAF);
            this.groupBoxFoto.Controls.Add(this.btnAcF);
            this.groupBoxFoto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFoto.Location = new System.Drawing.Point(19, 68);
            this.groupBoxFoto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxFoto.Name = "groupBoxFoto";
            this.groupBoxFoto.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxFoto.Size = new System.Drawing.Size(439, 331);
            this.groupBoxFoto.TabIndex = 109;
            this.groupBoxFoto.TabStop = false;
            this.groupBoxFoto.Text = "Foto Personal";
            // 
            // txtTipoPersonal
            // 
            this.txtTipoPersonal.Location = new System.Drawing.Point(345, 16);
            this.txtTipoPersonal.Name = "txtTipoPersonal";
            this.txtTipoPersonal.Size = new System.Drawing.Size(27, 22);
            this.txtTipoPersonal.TabIndex = 116;
            this.txtTipoPersonal.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 14);
            this.label1.TabIndex = 115;
            this.label1.Text = "Captura legajo número";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.ForeColor = System.Drawing.Color.Red;
            this.lblLegajo.Location = new System.Drawing.Point(267, 19);
            this.lblLegajo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(45, 14);
            this.lblLegajo.TabIndex = 114;
            this.lblLegajo.Text = "label1";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::HematoLab.Properties.Resources.icons8_Back_26px;
            this.btnSalir.Location = new System.Drawing.Point(311, 267);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 48);
            this.btnSalir.TabIndex = 113;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // PBMostrarImagen
            // 
            this.PBMostrarImagen.Location = new System.Drawing.Point(105, 42);
            this.PBMostrarImagen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PBMostrarImagen.Name = "PBMostrarImagen";
            this.PBMostrarImagen.Size = new System.Drawing.Size(221, 218);
            this.PBMostrarImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBMostrarImagen.TabIndex = 23;
            this.PBMostrarImagen.TabStop = false;
            // 
            // txtExaminar
            // 
            this.txtExaminar.Enabled = false;
            this.txtExaminar.Location = new System.Drawing.Point(455, 26);
            this.txtExaminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtExaminar.Name = "txtExaminar";
            this.txtExaminar.ReadOnly = true;
            this.txtExaminar.Size = new System.Drawing.Size(24, 22);
            this.txtExaminar.TabIndex = 21;
            this.txtExaminar.Visible = false;
            // 
            // btnAF
            // 
            this.btnAF.Enabled = false;
            this.btnAF.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAF.Location = new System.Drawing.Point(8, 266);
            this.btnAF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAF.Name = "btnAF";
            this.btnAF.Size = new System.Drawing.Size(140, 50);
            this.btnAF.TabIndex = 109;
            this.btnAF.Text = "Agregar Foto";
            this.btnAF.UseVisualStyleBackColor = true;
            this.btnAF.Click += new System.EventHandler(this.btnAF_Click);
            // 
            // btnAcF
            // 
            this.btnAcF.Enabled = false;
            this.btnAcF.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAcF.Location = new System.Drawing.Point(155, 266);
            this.btnAcF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAcF.Name = "btnAcF";
            this.btnAcF.Size = new System.Drawing.Size(148, 50);
            this.btnAcF.TabIndex = 110;
            this.btnAcF.Text = "ActualizarFoto";
            this.btnAcF.UseVisualStyleBackColor = true;
            this.btnAcF.Click += new System.EventHandler(this.btnAcF_Click);
            // 
            // txtEstado
            // 
            this.txtEstado.ForeColor = System.Drawing.Color.Red;
            this.txtEstado.Location = new System.Drawing.Point(31, 416);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(409, 22);
            this.txtEstado.TabIndex = 114;
            // 
            // groupBoxDispositivo
            // 
            this.groupBoxDispositivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBoxDispositivo.Controls.Add(this.btnDetener);
            this.groupBoxDispositivo.Controls.Add(this.btnIniciar);
            this.groupBoxDispositivo.Controls.Add(this.label16);
            this.groupBoxDispositivo.Controls.Add(this.cmbCamaras);
            this.groupBoxDispositivo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDispositivo.Location = new System.Drawing.Point(19, 453);
            this.groupBoxDispositivo.Name = "groupBoxDispositivo";
            this.groupBoxDispositivo.Size = new System.Drawing.Size(437, 110);
            this.groupBoxDispositivo.TabIndex = 115;
            this.groupBoxDispositivo.TabStop = false;
            this.groupBoxDispositivo.Text = "Dispositivo";
            // 
            // btnDetener
            // 
            this.btnDetener.Enabled = false;
            this.btnDetener.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Image = global::HematoLab.Properties.Resources.icons8_Shutdown_32;
            this.btnDetener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetener.Location = new System.Drawing.Point(282, 57);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(139, 45);
            this.btnDetener.TabIndex = 116;
            this.btnDetener.Text = "Detener";
            this.btnDetener.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Image = global::HematoLab.Properties.Resources.icons8_Playc_32;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciar.Location = new System.Drawing.Point(12, 56);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(139, 45);
            this.btnIniciar.TabIndex = 105;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(139, 14);
            this.label16.TabIndex = 102;
            this.label16.Text = "Camaras Disponibles";
            // 
            // cmbCamaras
            // 
            this.cmbCamaras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamaras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCamaras.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCamaras.FormattingEnabled = true;
            this.cmbCamaras.Location = new System.Drawing.Point(155, 24);
            this.cmbCamaras.Name = "cmbCamaras";
            this.cmbCamaras.Size = new System.Drawing.Size(267, 24);
            this.cmbCamaras.TabIndex = 103;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HematoLab.Properties.Resources.Web_Camera_96px;
            this.pictureBox1.Location = new System.Drawing.Point(269, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 116;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(447, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 23);
            this.panel1.TabIndex = 117;
            // 
            // FormFotografias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxDispositivo);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.groupBoxFoto);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormFotografias";
            this.Padding = new System.Windows.Forms.Padding(27, 65, 27, 22);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Administrar Fotografías";
            this.Load += new System.EventHandler(this.FormFotografias_Load);
            this.groupBoxFoto.ResumeLayout(false);
            this.groupBoxFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMostrarImagen)).EndInit();
            this.groupBoxDispositivo.ResumeLayout(false);
            this.groupBoxDispositivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFoto;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox PBMostrarImagen;
        private System.Windows.Forms.TextBox txtExaminar;
        private System.Windows.Forms.Button btnAF;
        private System.Windows.Forms.Button btnAcF;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.GroupBox groupBoxDispositivo;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCamaras;
        public System.Windows.Forms.TextBox txtTipoPersonal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
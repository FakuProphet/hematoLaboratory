namespace HematoLab.Formularios
{
    partial class FormUsuariosSistemaAdm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuariosSistemaAdm));
            this.lstUsuariosProfesionales = new System.Windows.Forms.ListBox();
            this.groupBoxDatosLab = new System.Windows.Forms.GroupBox();
            this.cboEstadoLab = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoUsuarioLab = new System.Windows.Forms.ComboBox();
            this.txtContrasenaLab = new System.Windows.Forms.TextBox();
            this.txtLegajoLab = new System.Windows.Forms.TextBox();
            this.txtNombreUsuarioLab = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnActualizarUsuarioExt = new System.Windows.Forms.Button();
            this.btnCancelarExt = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lstExtractorio = new System.Windows.Forms.ListBox();
            this.groupBoxDatosExt = new System.Windows.Forms.GroupBox();
            this.cboEstadoExt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoUsuarioExt = new System.Windows.Forms.ComboBox();
            this.txtPassExt = new System.Windows.Forms.TextBox();
            this.txtLegajoExt = new System.Windows.Forms.TextBox();
            this.txtNombreUsuarioExt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGrabarExt = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnActualizarLab = new System.Windows.Forms.Button();
            this.btnCancelarLab = new System.Windows.Forms.Button();
            this.btnGrabarUsuarioLab = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnActualizarAtPublico = new System.Windows.Forms.Button();
            this.btnCancelarAtPublico = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lstPersonalAtencion = new System.Windows.Forms.ListBox();
            this.groupBoxDatosAP = new System.Windows.Forms.GroupBox();
            this.cboEstadoAP = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboTipoUsuarioAP = new System.Windows.Forms.ComboBox();
            this.txtPassAP = new System.Windows.Forms.TextBox();
            this.txtLegajoAP = new System.Windows.Forms.TextBox();
            this.txtNombreUsuarioAP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnGrabarUsuarioAP = new System.Windows.Forms.Button();
            this.btnSalirExt = new System.Windows.Forms.Button();
            this.groupBoxDatosLab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxDatosExt.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBoxDatosAP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUsuariosProfesionales
            // 
            this.lstUsuariosProfesionales.FormattingEnabled = true;
            this.lstUsuariosProfesionales.ItemHeight = 14;
            this.lstUsuariosProfesionales.Location = new System.Drawing.Point(598, 70);
            this.lstUsuariosProfesionales.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstUsuariosProfesionales.Name = "lstUsuariosProfesionales";
            this.lstUsuariosProfesionales.Size = new System.Drawing.Size(129, 256);
            this.lstUsuariosProfesionales.TabIndex = 0;
            this.lstUsuariosProfesionales.SelectedIndexChanged += new System.EventHandler(this.lstUsuariosProfesionales_SelectedIndexChanged);
            // 
            // groupBoxDatosLab
            // 
            this.groupBoxDatosLab.Controls.Add(this.cboEstadoLab);
            this.groupBoxDatosLab.Controls.Add(this.label5);
            this.groupBoxDatosLab.Controls.Add(this.label1);
            this.groupBoxDatosLab.Controls.Add(this.cboTipoUsuarioLab);
            this.groupBoxDatosLab.Controls.Add(this.txtContrasenaLab);
            this.groupBoxDatosLab.Controls.Add(this.txtLegajoLab);
            this.groupBoxDatosLab.Controls.Add(this.txtNombreUsuarioLab);
            this.groupBoxDatosLab.Controls.Add(this.label2);
            this.groupBoxDatosLab.Controls.Add(this.label4);
            this.groupBoxDatosLab.Controls.Add(this.label3);
            this.groupBoxDatosLab.Location = new System.Drawing.Point(42, 38);
            this.groupBoxDatosLab.Name = "groupBoxDatosLab";
            this.groupBoxDatosLab.Size = new System.Drawing.Size(510, 288);
            this.groupBoxDatosLab.TabIndex = 1;
            this.groupBoxDatosLab.TabStop = false;
            this.groupBoxDatosLab.Text = "Datos de usuario";
            // 
            // cboEstadoLab
            // 
            this.cboEstadoLab.Enabled = false;
            this.cboEstadoLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstadoLab.FormattingEnabled = true;
            this.cboEstadoLab.Location = new System.Drawing.Point(168, 211);
            this.cboEstadoLab.Name = "cboEstadoLab";
            this.cboEstadoLab.Size = new System.Drawing.Size(279, 22);
            this.cboEstadoLab.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Numero de legajo";
            // 
            // cboTipoUsuarioLab
            // 
            this.cboTipoUsuarioLab.Enabled = false;
            this.cboTipoUsuarioLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoUsuarioLab.FormattingEnabled = true;
            this.cboTipoUsuarioLab.Location = new System.Drawing.Point(168, 88);
            this.cboTipoUsuarioLab.Name = "cboTipoUsuarioLab";
            this.cboTipoUsuarioLab.Size = new System.Drawing.Size(279, 22);
            this.cboTipoUsuarioLab.TabIndex = 10;
            // 
            // txtContrasenaLab
            // 
            this.txtContrasenaLab.Enabled = false;
            this.txtContrasenaLab.Location = new System.Drawing.Point(168, 166);
            this.txtContrasenaLab.Name = "txtContrasenaLab";
            this.txtContrasenaLab.Size = new System.Drawing.Size(279, 22);
            this.txtContrasenaLab.TabIndex = 11;
            // 
            // txtLegajoLab
            // 
            this.txtLegajoLab.Location = new System.Drawing.Point(168, 53);
            this.txtLegajoLab.Name = "txtLegajoLab";
            this.txtLegajoLab.ReadOnly = true;
            this.txtLegajoLab.Size = new System.Drawing.Size(279, 22);
            this.txtLegajoLab.TabIndex = 12;
            // 
            // txtNombreUsuarioLab
            // 
            this.txtNombreUsuarioLab.Enabled = false;
            this.txtNombreUsuarioLab.Location = new System.Drawing.Point(168, 127);
            this.txtNombreUsuarioLab.Name = "txtNombreUsuarioLab";
            this.txtNombreUsuarioLab.Size = new System.Drawing.Size(279, 22);
            this.txtNombreUsuarioLab.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo de usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nombre de usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(573, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Legajos usuarios laboratorio";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 464);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnActualizarUsuarioExt);
            this.tabPage2.Controls.Add(this.btnCancelarExt);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.lstExtractorio);
            this.tabPage2.Controls.Add(this.groupBoxDatosExt);
            this.tabPage2.Controls.Add(this.btnGrabarExt);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Usuarios Extractorio";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnActualizarUsuarioExt
            // 
            this.btnActualizarUsuarioExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarUsuarioExt.Image = global::HematoLab.Properties.Resources.icons8_Upgrade_321;
            this.btnActualizarUsuarioExt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarUsuarioExt.Location = new System.Drawing.Point(276, 375);
            this.btnActualizarUsuarioExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActualizarUsuarioExt.Name = "btnActualizarUsuarioExt";
            this.btnActualizarUsuarioExt.Size = new System.Drawing.Size(162, 37);
            this.btnActualizarUsuarioExt.TabIndex = 7;
            this.btnActualizarUsuarioExt.Text = "Actualizar usuario";
            this.btnActualizarUsuarioExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarUsuarioExt.UseVisualStyleBackColor = true;
            this.btnActualizarUsuarioExt.Click += new System.EventHandler(this.btnActualizarUsuarioExt_Click);
            // 
            // btnCancelarExt
            // 
            this.btnCancelarExt.Enabled = false;
            this.btnCancelarExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarExt.Image = global::HematoLab.Properties.Resources.icons8_Cancel_32;
            this.btnCancelarExt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarExt.Location = new System.Drawing.Point(444, 375);
            this.btnCancelarExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelarExt.Name = "btnCancelarExt";
            this.btnCancelarExt.Size = new System.Drawing.Size(114, 37);
            this.btnCancelarExt.TabIndex = 8;
            this.btnCancelarExt.Text = "Cancelar";
            this.btnCancelarExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarExt.UseVisualStyleBackColor = true;
            this.btnCancelarExt.Click += new System.EventHandler(this.btnCancelarExt_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(586, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(187, 14);
            this.label12.TabIndex = 6;
            this.label12.Text = "Legajos usuarios extractorio";
            // 
            // lstExtractorio
            // 
            this.lstExtractorio.FormattingEnabled = true;
            this.lstExtractorio.ItemHeight = 14;
            this.lstExtractorio.Location = new System.Drawing.Point(613, 74);
            this.lstExtractorio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstExtractorio.Name = "lstExtractorio";
            this.lstExtractorio.Size = new System.Drawing.Size(129, 256);
            this.lstExtractorio.TabIndex = 3;
            this.lstExtractorio.SelectedIndexChanged += new System.EventHandler(this.lstExtractorio_SelectedIndexChanged);
            // 
            // groupBoxDatosExt
            // 
            this.groupBoxDatosExt.Controls.Add(this.cboEstadoExt);
            this.groupBoxDatosExt.Controls.Add(this.label7);
            this.groupBoxDatosExt.Controls.Add(this.label8);
            this.groupBoxDatosExt.Controls.Add(this.cboTipoUsuarioExt);
            this.groupBoxDatosExt.Controls.Add(this.txtPassExt);
            this.groupBoxDatosExt.Controls.Add(this.txtLegajoExt);
            this.groupBoxDatosExt.Controls.Add(this.txtNombreUsuarioExt);
            this.groupBoxDatosExt.Controls.Add(this.label9);
            this.groupBoxDatosExt.Controls.Add(this.label10);
            this.groupBoxDatosExt.Controls.Add(this.label11);
            this.groupBoxDatosExt.Location = new System.Drawing.Point(48, 42);
            this.groupBoxDatosExt.Name = "groupBoxDatosExt";
            this.groupBoxDatosExt.Size = new System.Drawing.Size(510, 288);
            this.groupBoxDatosExt.TabIndex = 2;
            this.groupBoxDatosExt.TabStop = false;
            this.groupBoxDatosExt.Text = "Datos de usuario";
            // 
            // cboEstadoExt
            // 
            this.cboEstadoExt.Enabled = false;
            this.cboEstadoExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstadoExt.FormattingEnabled = true;
            this.cboEstadoExt.Location = new System.Drawing.Point(168, 211);
            this.cboEstadoExt.Name = "cboEstadoExt";
            this.cboEstadoExt.Size = new System.Drawing.Size(279, 22);
            this.cboEstadoExt.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Estado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "Numero de legajo";
            // 
            // cboTipoUsuarioExt
            // 
            this.cboTipoUsuarioExt.Enabled = false;
            this.cboTipoUsuarioExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoUsuarioExt.FormattingEnabled = true;
            this.cboTipoUsuarioExt.Location = new System.Drawing.Point(168, 88);
            this.cboTipoUsuarioExt.Name = "cboTipoUsuarioExt";
            this.cboTipoUsuarioExt.Size = new System.Drawing.Size(279, 22);
            this.cboTipoUsuarioExt.TabIndex = 10;
            // 
            // txtPassExt
            // 
            this.txtPassExt.Enabled = false;
            this.txtPassExt.Location = new System.Drawing.Point(168, 166);
            this.txtPassExt.Name = "txtPassExt";
            this.txtPassExt.Size = new System.Drawing.Size(279, 22);
            this.txtPassExt.TabIndex = 11;
            // 
            // txtLegajoExt
            // 
            this.txtLegajoExt.Location = new System.Drawing.Point(168, 53);
            this.txtLegajoExt.Name = "txtLegajoExt";
            this.txtLegajoExt.ReadOnly = true;
            this.txtLegajoExt.Size = new System.Drawing.Size(279, 22);
            this.txtLegajoExt.TabIndex = 12;
            // 
            // txtNombreUsuarioExt
            // 
            this.txtNombreUsuarioExt.Enabled = false;
            this.txtNombreUsuarioExt.Location = new System.Drawing.Point(168, 127);
            this.txtNombreUsuarioExt.Name = "txtNombreUsuarioExt";
            this.txtNombreUsuarioExt.Size = new System.Drawing.Size(279, 22);
            this.txtNombreUsuarioExt.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tipo de usuario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "Contraseña";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 14);
            this.label11.TabIndex = 14;
            this.label11.Text = "Nombre de usuario";
            // 
            // btnGrabarExt
            // 
            this.btnGrabarExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarExt.Image = global::HematoLab.Properties.Resources.icons8_Save_321;
            this.btnGrabarExt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabarExt.Location = new System.Drawing.Point(276, 375);
            this.btnGrabarExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabarExt.Name = "btnGrabarExt";
            this.btnGrabarExt.Size = new System.Drawing.Size(162, 37);
            this.btnGrabarExt.TabIndex = 10;
            this.btnGrabarExt.Text = "Grabar";
            this.btnGrabarExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabarExt.UseVisualStyleBackColor = true;
            this.btnGrabarExt.Click += new System.EventHandler(this.btnGrabarExt_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnActualizarLab);
            this.tabPage1.Controls.Add(this.btnCancelarLab);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lstUsuariosProfesionales);
            this.tabPage1.Controls.Add(this.groupBoxDatosLab);
            this.tabPage1.Controls.Add(this.btnGrabarUsuarioLab);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios Laboratorio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnActualizarLab
            // 
            this.btnActualizarLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarLab.Image = global::HematoLab.Properties.Resources.icons8_Upgrade_321;
            this.btnActualizarLab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarLab.Location = new System.Drawing.Point(270, 375);
            this.btnActualizarLab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActualizarLab.Name = "btnActualizarLab";
            this.btnActualizarLab.Size = new System.Drawing.Size(162, 37);
            this.btnActualizarLab.TabIndex = 2;
            this.btnActualizarLab.Text = "Actualizar usuario";
            this.btnActualizarLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarLab.UseVisualStyleBackColor = true;
            this.btnActualizarLab.Click += new System.EventHandler(this.btnActualizarLab_Click);
            // 
            // btnCancelarLab
            // 
            this.btnCancelarLab.Enabled = false;
            this.btnCancelarLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarLab.Image = global::HematoLab.Properties.Resources.icons8_Cancel_32;
            this.btnCancelarLab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarLab.Location = new System.Drawing.Point(438, 375);
            this.btnCancelarLab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelarLab.Name = "btnCancelarLab";
            this.btnCancelarLab.Size = new System.Drawing.Size(114, 37);
            this.btnCancelarLab.TabIndex = 3;
            this.btnCancelarLab.Text = "Cancelar";
            this.btnCancelarLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarLab.UseVisualStyleBackColor = true;
            this.btnCancelarLab.Click += new System.EventHandler(this.btnCancelarLab_Click);
            // 
            // btnGrabarUsuarioLab
            // 
            this.btnGrabarUsuarioLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarUsuarioLab.Image = global::HematoLab.Properties.Resources.icons8_Save_321;
            this.btnGrabarUsuarioLab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabarUsuarioLab.Location = new System.Drawing.Point(270, 375);
            this.btnGrabarUsuarioLab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabarUsuarioLab.Name = "btnGrabarUsuarioLab";
            this.btnGrabarUsuarioLab.Size = new System.Drawing.Size(162, 37);
            this.btnGrabarUsuarioLab.TabIndex = 6;
            this.btnGrabarUsuarioLab.Text = "Grabar";
            this.btnGrabarUsuarioLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabarUsuarioLab.UseVisualStyleBackColor = true;
            this.btnGrabarUsuarioLab.Click += new System.EventHandler(this.btnGrabarUsuarioLab_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnActualizarAtPublico);
            this.tabPage3.Controls.Add(this.btnCancelarAtPublico);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.lstPersonalAtencion);
            this.tabPage3.Controls.Add(this.groupBoxDatosAP);
            this.tabPage3.Controls.Add(this.btnGrabarUsuarioAP);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(791, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Usuarios Atención ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnActualizarAtPublico
            // 
            this.btnActualizarAtPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarAtPublico.Image = global::HematoLab.Properties.Resources.icons8_Upgrade_321;
            this.btnActualizarAtPublico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarAtPublico.Location = new System.Drawing.Point(270, 373);
            this.btnActualizarAtPublico.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActualizarAtPublico.Name = "btnActualizarAtPublico";
            this.btnActualizarAtPublico.Size = new System.Drawing.Size(162, 37);
            this.btnActualizarAtPublico.TabIndex = 7;
            this.btnActualizarAtPublico.Text = "Actualizar usuario";
            this.btnActualizarAtPublico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarAtPublico.UseVisualStyleBackColor = true;
            this.btnActualizarAtPublico.Click += new System.EventHandler(this.btnActualizarAtPublico_Click);
            // 
            // btnCancelarAtPublico
            // 
            this.btnCancelarAtPublico.Enabled = false;
            this.btnCancelarAtPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarAtPublico.Image = global::HematoLab.Properties.Resources.icons8_Cancel_32;
            this.btnCancelarAtPublico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarAtPublico.Location = new System.Drawing.Point(438, 373);
            this.btnCancelarAtPublico.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelarAtPublico.Name = "btnCancelarAtPublico";
            this.btnCancelarAtPublico.Size = new System.Drawing.Size(114, 37);
            this.btnCancelarAtPublico.TabIndex = 8;
            this.btnCancelarAtPublico.Text = "Cancelar";
            this.btnCancelarAtPublico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarAtPublico.UseVisualStyleBackColor = true;
            this.btnCancelarAtPublico.Click += new System.EventHandler(this.btnCancelarAtPublico_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(575, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(194, 14);
            this.label18.TabIndex = 6;
            this.label18.Text = "Legajos personal de atención";
            // 
            // lstPersonalAtencion
            // 
            this.lstPersonalAtencion.FormattingEnabled = true;
            this.lstPersonalAtencion.ItemHeight = 14;
            this.lstPersonalAtencion.Location = new System.Drawing.Point(603, 80);
            this.lstPersonalAtencion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstPersonalAtencion.Name = "lstPersonalAtencion";
            this.lstPersonalAtencion.Size = new System.Drawing.Size(129, 256);
            this.lstPersonalAtencion.TabIndex = 3;
            this.lstPersonalAtencion.SelectedIndexChanged += new System.EventHandler(this.lstPersonalAtencion_SelectedIndexChanged);
            // 
            // groupBoxDatosAP
            // 
            this.groupBoxDatosAP.Controls.Add(this.cboEstadoAP);
            this.groupBoxDatosAP.Controls.Add(this.label13);
            this.groupBoxDatosAP.Controls.Add(this.label14);
            this.groupBoxDatosAP.Controls.Add(this.cboTipoUsuarioAP);
            this.groupBoxDatosAP.Controls.Add(this.txtPassAP);
            this.groupBoxDatosAP.Controls.Add(this.txtLegajoAP);
            this.groupBoxDatosAP.Controls.Add(this.txtNombreUsuarioAP);
            this.groupBoxDatosAP.Controls.Add(this.label15);
            this.groupBoxDatosAP.Controls.Add(this.label16);
            this.groupBoxDatosAP.Controls.Add(this.label17);
            this.groupBoxDatosAP.Location = new System.Drawing.Point(42, 48);
            this.groupBoxDatosAP.Name = "groupBoxDatosAP";
            this.groupBoxDatosAP.Size = new System.Drawing.Size(510, 288);
            this.groupBoxDatosAP.TabIndex = 2;
            this.groupBoxDatosAP.TabStop = false;
            this.groupBoxDatosAP.Text = "Datos de usuario";
            // 
            // cboEstadoAP
            // 
            this.cboEstadoAP.Enabled = false;
            this.cboEstadoAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstadoAP.FormattingEnabled = true;
            this.cboEstadoAP.Location = new System.Drawing.Point(168, 211);
            this.cboEstadoAP.Name = "cboEstadoAP";
            this.cboEstadoAP.Size = new System.Drawing.Size(279, 22);
            this.cboEstadoAP.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 16;
            this.label13.Text = "Estado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 14);
            this.label14.TabIndex = 8;
            this.label14.Text = "Numero de legajo";
            // 
            // cboTipoUsuarioAP
            // 
            this.cboTipoUsuarioAP.Enabled = false;
            this.cboTipoUsuarioAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoUsuarioAP.FormattingEnabled = true;
            this.cboTipoUsuarioAP.Location = new System.Drawing.Point(168, 88);
            this.cboTipoUsuarioAP.Name = "cboTipoUsuarioAP";
            this.cboTipoUsuarioAP.Size = new System.Drawing.Size(279, 22);
            this.cboTipoUsuarioAP.TabIndex = 10;
            // 
            // txtPassAP
            // 
            this.txtPassAP.Enabled = false;
            this.txtPassAP.Location = new System.Drawing.Point(168, 166);
            this.txtPassAP.Name = "txtPassAP";
            this.txtPassAP.Size = new System.Drawing.Size(279, 22);
            this.txtPassAP.TabIndex = 11;
            // 
            // txtLegajoAP
            // 
            this.txtLegajoAP.Location = new System.Drawing.Point(168, 53);
            this.txtLegajoAP.Name = "txtLegajoAP";
            this.txtLegajoAP.ReadOnly = true;
            this.txtLegajoAP.Size = new System.Drawing.Size(279, 22);
            this.txtLegajoAP.TabIndex = 12;
            // 
            // txtNombreUsuarioAP
            // 
            this.txtNombreUsuarioAP.Enabled = false;
            this.txtNombreUsuarioAP.Location = new System.Drawing.Point(168, 127);
            this.txtNombreUsuarioAP.Name = "txtNombreUsuarioAP";
            this.txtNombreUsuarioAP.Size = new System.Drawing.Size(279, 22);
            this.txtNombreUsuarioAP.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 14);
            this.label15.TabIndex = 13;
            this.label15.Text = "Tipo de usuario";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(39, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 14);
            this.label16.TabIndex = 15;
            this.label16.Text = "Contraseña";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 14);
            this.label17.TabIndex = 14;
            this.label17.Text = "Nombre de usuario";
            // 
            // btnGrabarUsuarioAP
            // 
            this.btnGrabarUsuarioAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarUsuarioAP.Image = global::HematoLab.Properties.Resources.icons8_Save_321;
            this.btnGrabarUsuarioAP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabarUsuarioAP.Location = new System.Drawing.Point(270, 373);
            this.btnGrabarUsuarioAP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabarUsuarioAP.Name = "btnGrabarUsuarioAP";
            this.btnGrabarUsuarioAP.Size = new System.Drawing.Size(162, 37);
            this.btnGrabarUsuarioAP.TabIndex = 10;
            this.btnGrabarUsuarioAP.Text = "Grabar";
            this.btnGrabarUsuarioAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabarUsuarioAP.UseVisualStyleBackColor = true;
            this.btnGrabarUsuarioAP.Click += new System.EventHandler(this.btnGrabarUsuarioAP_Click);
            // 
            // btnSalirExt
            // 
            this.btnSalirExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalirExt.Image = global::HematoLab.Properties.Resources.icons8_Exit_32;
            this.btnSalirExt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalirExt.Location = new System.Drawing.Point(679, 544);
            this.btnSalirExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalirExt.Name = "btnSalirExt";
            this.btnSalirExt.Size = new System.Drawing.Size(129, 37);
            this.btnSalirExt.TabIndex = 9;
            this.btnSalirExt.Text = "Salir";
            this.btnSalirExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirExt.UseVisualStyleBackColor = true;
            this.btnSalirExt.Click += new System.EventHandler(this.btnSalirExt_Click);
            // 
            // FormUsuariosSistemaAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 597);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSalirExt);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormUsuariosSistemaAdm";
            this.Padding = new System.Windows.Forms.Padding(27, 65, 27, 22);
            this.Resizable = false;
            this.Text = "Administración Usuarios Sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUsuariosSistemaAdm_FormClosing);
            this.Load += new System.EventHandler(this.FormUsuariosSistemaAdm_Load);
            this.groupBoxDatosLab.ResumeLayout(false);
            this.groupBoxDatosLab.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxDatosExt.ResumeLayout(false);
            this.groupBoxDatosExt.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBoxDatosAP.ResumeLayout(false);
            this.groupBoxDatosAP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsuariosProfesionales;
        private System.Windows.Forms.GroupBox groupBoxDatosLab;
        private System.Windows.Forms.Button btnActualizarLab;
        private System.Windows.Forms.Button btnCancelarLab;
        private System.Windows.Forms.ComboBox cboEstadoLab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoUsuarioLab;
        public System.Windows.Forms.TextBox txtContrasenaLab;
        public System.Windows.Forms.TextBox txtLegajoLab;
        public System.Windows.Forms.TextBox txtNombreUsuarioLab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstExtractorio;
        private System.Windows.Forms.GroupBox groupBoxDatosExt;
        private System.Windows.Forms.ComboBox cboEstadoExt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoUsuarioExt;
        public System.Windows.Forms.TextBox txtPassExt;
        public System.Windows.Forms.TextBox txtLegajoExt;
        public System.Windows.Forms.TextBox txtNombreUsuarioExt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancelarExt;
        private System.Windows.Forms.Button btnSalirExt;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lstPersonalAtencion;
        private System.Windows.Forms.GroupBox groupBoxDatosAP;
        private System.Windows.Forms.ComboBox cboEstadoAP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboTipoUsuarioAP;
        public System.Windows.Forms.TextBox txtPassAP;
        public System.Windows.Forms.TextBox txtLegajoAP;
        public System.Windows.Forms.TextBox txtNombreUsuarioAP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnActualizarAtPublico;
        private System.Windows.Forms.Button btnCancelarAtPublico;
        private System.Windows.Forms.Button btnGrabarExt;
        private System.Windows.Forms.Button btnActualizarUsuarioExt;
        private System.Windows.Forms.Button btnGrabarUsuarioLab;
        private System.Windows.Forms.Button btnGrabarUsuarioAP;
    }
}
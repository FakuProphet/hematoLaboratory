namespace HematoLab.Formularios
{
    partial class FormInformesGestionUsuarios
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboSeleccion = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxPEXT = new System.Windows.Forms.GroupBox();
            this.btnFiltroPExt = new System.Windows.Forms.Button();
            this.cboTurnoExt = new System.Windows.Forms.ComboBox();
            this.btnGenerarPDFPExt = new System.Windows.Forms.Button();
            this.btnListadoPExt = new System.Windows.Forms.Button();
            this.groupBoxPNM = new System.Windows.Forms.GroupBox();
            this.btnGenerarPDFPNM = new System.Windows.Forms.Button();
            this.btnListadoPNM = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxFiltroPPT = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTurnos = new System.Windows.Forms.ComboBox();
            this.btnFiltroPPT = new System.Windows.Forms.Button();
            this.btnCargarListaPPT = new System.Windows.Forms.Button();
            this.groupBox1FiltroPPE = new System.Windows.Forms.GroupBox();
            this.btnFiltroEspHem = new System.Windows.Forms.Button();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnGenerarPDFPPT = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxPEXT.SuspendLayout();
            this.groupBoxPNM.SuspendLayout();
            this.groupBoxFiltroPPT.SuspendLayout();
            this.groupBox1FiltroPPE.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("SketchFlow Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Selección";
            // 
            // cboSeleccion
            // 
            this.cboSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeleccion.FormattingEnabled = true;
            this.cboSeleccion.Items.AddRange(new object[] {
            "Seleccionar...",
            "Profesionales turno",
            "Profesionales Especialistas",
            "Personal no médico",
            "Personal Extractorio"});
            this.cboSeleccion.Location = new System.Drawing.Point(133, 83);
            this.cboSeleccion.Name = "cboSeleccion";
            this.cboSeleccion.Size = new System.Drawing.Size(290, 26);
            this.cboSeleccion.TabIndex = 19;
            this.cboSeleccion.SelectedIndexChanged += new System.EventHandler(this.cboSeleccion_SelectedIndexChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(437, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(745, 535);
            this.dataGridView1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("SketchFlow Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(437, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(745, 47);
            this.label1.TabIndex = 16;
            this.label1.Text = "Listados y generación de informes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.groupBoxPEXT);
            this.panel1.Controls.Add(this.groupBoxPNM);
            this.panel1.Controls.Add(this.groupBoxFiltroPPT);
            this.panel1.Controls.Add(this.groupBox1FiltroPPE);
            this.panel1.Location = new System.Drawing.Point(7, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 535);
            this.panel1.TabIndex = 15;
            // 
            // groupBoxPEXT
            // 
            this.groupBoxPEXT.Controls.Add(this.btnFiltroPExt);
            this.groupBoxPEXT.Controls.Add(this.cboTurnoExt);
            this.groupBoxPEXT.Controls.Add(this.btnGenerarPDFPExt);
            this.groupBoxPEXT.Controls.Add(this.btnListadoPExt);
            this.groupBoxPEXT.Enabled = false;
            this.groupBoxPEXT.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPEXT.ForeColor = System.Drawing.Color.White;
            this.groupBoxPEXT.Location = new System.Drawing.Point(3, 422);
            this.groupBoxPEXT.Name = "groupBoxPEXT";
            this.groupBoxPEXT.Size = new System.Drawing.Size(418, 109);
            this.groupBoxPEXT.TabIndex = 13;
            this.groupBoxPEXT.TabStop = false;
            this.groupBoxPEXT.Text = "Filtro Personal Extractorio";
            // 
            // btnFiltroPExt
            // 
            this.btnFiltroPExt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiltroPExt.FlatAppearance.BorderSize = 0;
            this.btnFiltroPExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroPExt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroPExt.ForeColor = System.Drawing.Color.White;
            this.btnFiltroPExt.Image = global::HematoLab.Properties.Resources.icons8_Filter_32;
            this.btnFiltroPExt.Location = new System.Drawing.Point(269, 37);
            this.btnFiltroPExt.Name = "btnFiltroPExt";
            this.btnFiltroPExt.Size = new System.Drawing.Size(44, 41);
            this.btnFiltroPExt.TabIndex = 27;
            this.btnFiltroPExt.UseVisualStyleBackColor = false;
            this.btnFiltroPExt.Click += new System.EventHandler(this.btnFiltroPExt_Click);
            // 
            // cboTurnoExt
            // 
            this.cboTurnoExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnoExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTurnoExt.Font = new System.Drawing.Font("SketchFlow Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTurnoExt.FormattingEnabled = true;
            this.cboTurnoExt.Location = new System.Drawing.Point(17, 47);
            this.cboTurnoExt.Name = "cboTurnoExt";
            this.cboTurnoExt.Size = new System.Drawing.Size(246, 21);
            this.cboTurnoExt.TabIndex = 26;
            // 
            // btnGenerarPDFPExt
            // 
            this.btnGenerarPDFPExt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerarPDFPExt.FlatAppearance.BorderSize = 0;
            this.btnGenerarPDFPExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPDFPExt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDFPExt.ForeColor = System.Drawing.Color.Red;
            this.btnGenerarPDFPExt.Image = global::HematoLab.Properties.Resources.icons8_PDF_321;
            this.btnGenerarPDFPExt.Location = new System.Drawing.Point(367, 37);
            this.btnGenerarPDFPExt.Name = "btnGenerarPDFPExt";
            this.btnGenerarPDFPExt.Size = new System.Drawing.Size(43, 41);
            this.btnGenerarPDFPExt.TabIndex = 25;
            this.btnGenerarPDFPExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarPDFPExt.UseVisualStyleBackColor = false;
            this.btnGenerarPDFPExt.Click += new System.EventHandler(this.btnGenerarPDFPExt_Click);
            // 
            // btnListadoPExt
            // 
            this.btnListadoPExt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListadoPExt.FlatAppearance.BorderSize = 0;
            this.btnListadoPExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListadoPExt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListadoPExt.ForeColor = System.Drawing.Color.White;
            this.btnListadoPExt.Image = global::HematoLab.Properties.Resources.icons8_Select_All_32;
            this.btnListadoPExt.Location = new System.Drawing.Point(318, 37);
            this.btnListadoPExt.Name = "btnListadoPExt";
            this.btnListadoPExt.Size = new System.Drawing.Size(44, 41);
            this.btnListadoPExt.TabIndex = 24;
            this.btnListadoPExt.UseVisualStyleBackColor = false;
            this.btnListadoPExt.Click += new System.EventHandler(this.btnListadoPExt_Click);
            // 
            // groupBoxPNM
            // 
            this.groupBoxPNM.Controls.Add(this.btnGenerarPDFPNM);
            this.groupBoxPNM.Controls.Add(this.btnListadoPNM);
            this.groupBoxPNM.Controls.Add(this.label6);
            this.groupBoxPNM.Enabled = false;
            this.groupBoxPNM.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPNM.ForeColor = System.Drawing.Color.White;
            this.groupBoxPNM.Location = new System.Drawing.Point(3, 304);
            this.groupBoxPNM.Name = "groupBoxPNM";
            this.groupBoxPNM.Size = new System.Drawing.Size(418, 100);
            this.groupBoxPNM.TabIndex = 12;
            this.groupBoxPNM.TabStop = false;
            this.groupBoxPNM.Text = "Filtro Personal no médico";
            // 
            // btnGenerarPDFPNM
            // 
            this.btnGenerarPDFPNM.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerarPDFPNM.FlatAppearance.BorderSize = 0;
            this.btnGenerarPDFPNM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPDFPNM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDFPNM.ForeColor = System.Drawing.Color.Red;
            this.btnGenerarPDFPNM.Image = global::HematoLab.Properties.Resources.icons8_PDF_321;
            this.btnGenerarPDFPNM.Location = new System.Drawing.Point(269, 37);
            this.btnGenerarPDFPNM.Name = "btnGenerarPDFPNM";
            this.btnGenerarPDFPNM.Size = new System.Drawing.Size(43, 41);
            this.btnGenerarPDFPNM.TabIndex = 25;
            this.btnGenerarPDFPNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarPDFPNM.UseVisualStyleBackColor = false;
            this.btnGenerarPDFPNM.Click += new System.EventHandler(this.btnGenerarPDFPNM_Click);
            // 
            // btnListadoPNM
            // 
            this.btnListadoPNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListadoPNM.FlatAppearance.BorderSize = 0;
            this.btnListadoPNM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListadoPNM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListadoPNM.ForeColor = System.Drawing.Color.White;
            this.btnListadoPNM.Image = global::HematoLab.Properties.Resources.icons8_Select_All_32;
            this.btnListadoPNM.Location = new System.Drawing.Point(219, 37);
            this.btnListadoPNM.Name = "btnListadoPNM";
            this.btnListadoPNM.Size = new System.Drawing.Size(44, 41);
            this.btnListadoPNM.TabIndex = 24;
            this.btnListadoPNM.UseVisualStyleBackColor = false;
            this.btnListadoPNM.Click += new System.EventHandler(this.btnListadoPNM_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Generar listado ";
            // 
            // groupBoxFiltroPPT
            // 
            this.groupBoxFiltroPPT.Controls.Add(this.button1);
            this.groupBoxFiltroPPT.Controls.Add(this.label4);
            this.groupBoxFiltroPPT.Controls.Add(this.cboTurnos);
            this.groupBoxFiltroPPT.Controls.Add(this.btnFiltroPPT);
            this.groupBoxFiltroPPT.Controls.Add(this.btnCargarListaPPT);
            this.groupBoxFiltroPPT.Enabled = false;
            this.groupBoxFiltroPPT.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFiltroPPT.ForeColor = System.Drawing.Color.White;
            this.groupBoxFiltroPPT.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFiltroPPT.Name = "groupBoxFiltroPPT";
            this.groupBoxFiltroPPT.Size = new System.Drawing.Size(418, 129);
            this.groupBoxFiltroPPT.TabIndex = 11;
            this.groupBoxFiltroPPT.TabStop = false;
            this.groupBoxFiltroPPT.Text = "Filtro Profesionales  Turno";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Image = global::HematoLab.Properties.Resources.icons8_PDF_32;
            this.button1.Location = new System.Drawing.Point(294, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 41);
            this.button1.TabIndex = 25;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("SketchFlow Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Turno";
            // 
            // cboTurnos
            // 
            this.cboTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTurnos.Font = new System.Drawing.Font("SketchFlow Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTurnos.FormattingEnabled = true;
            this.cboTurnos.Location = new System.Drawing.Point(18, 72);
            this.cboTurnos.Name = "cboTurnos";
            this.cboTurnos.Size = new System.Drawing.Size(150, 21);
            this.cboTurnos.TabIndex = 10;
            // 
            // btnFiltroPPT
            // 
            this.btnFiltroPPT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiltroPPT.FlatAppearance.BorderSize = 0;
            this.btnFiltroPPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroPPT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroPPT.ForeColor = System.Drawing.Color.White;
            this.btnFiltroPPT.Image = global::HematoLab.Properties.Resources.icons8_Filter_32;
            this.btnFiltroPPT.Location = new System.Drawing.Point(194, 59);
            this.btnFiltroPPT.Name = "btnFiltroPPT";
            this.btnFiltroPPT.Size = new System.Drawing.Size(44, 41);
            this.btnFiltroPPT.TabIndex = 12;
            this.btnFiltroPPT.UseVisualStyleBackColor = false;
            this.btnFiltroPPT.Click += new System.EventHandler(this.btnFiltroPPT_Click_1);
            // 
            // btnCargarListaPPT
            // 
            this.btnCargarListaPPT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCargarListaPPT.FlatAppearance.BorderSize = 0;
            this.btnCargarListaPPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarListaPPT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarListaPPT.ForeColor = System.Drawing.Color.White;
            this.btnCargarListaPPT.Image = global::HematoLab.Properties.Resources.icons8_Select_All_32;
            this.btnCargarListaPPT.Location = new System.Drawing.Point(244, 59);
            this.btnCargarListaPPT.Name = "btnCargarListaPPT";
            this.btnCargarListaPPT.Size = new System.Drawing.Size(44, 41);
            this.btnCargarListaPPT.TabIndex = 10;
            this.btnCargarListaPPT.UseVisualStyleBackColor = false;
            this.btnCargarListaPPT.Click += new System.EventHandler(this.btnCargarListaPPT_Click_1);
            // 
            // groupBox1FiltroPPE
            // 
            this.groupBox1FiltroPPE.Controls.Add(this.btnFiltroEspHem);
            this.groupBox1FiltroPPE.Controls.Add(this.cboEspecialidad);
            this.groupBox1FiltroPPE.Controls.Add(this.btnGenerarPDFPPT);
            this.groupBox1FiltroPPE.Controls.Add(this.label5);
            this.groupBox1FiltroPPE.Enabled = false;
            this.groupBox1FiltroPPE.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1FiltroPPE.ForeColor = System.Drawing.Color.White;
            this.groupBox1FiltroPPE.Location = new System.Drawing.Point(3, 138);
            this.groupBox1FiltroPPE.Name = "groupBox1FiltroPPE";
            this.groupBox1FiltroPPE.Size = new System.Drawing.Size(418, 160);
            this.groupBox1FiltroPPE.TabIndex = 28;
            this.groupBox1FiltroPPE.TabStop = false;
            this.groupBox1FiltroPPE.Text = "Filtro Profesionales  con especialidad";
            // 
            // btnFiltroEspHem
            // 
            this.btnFiltroEspHem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiltroEspHem.FlatAppearance.BorderSize = 0;
            this.btnFiltroEspHem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroEspHem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroEspHem.ForeColor = System.Drawing.Color.White;
            this.btnFiltroEspHem.Image = global::HematoLab.Properties.Resources.icons8_Filter_32;
            this.btnFiltroEspHem.Location = new System.Drawing.Point(295, 93);
            this.btnFiltroEspHem.Name = "btnFiltroEspHem";
            this.btnFiltroEspHem.Size = new System.Drawing.Size(44, 41);
            this.btnFiltroEspHem.TabIndex = 27;
            this.btnFiltroEspHem.UseVisualStyleBackColor = false;
            this.btnFiltroEspHem.Click += new System.EventHandler(this.btnFiltroEspHem_Click_1);
            // 
            // cboEspecialidad
            // 
            this.cboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEspecialidad.Font = new System.Drawing.Font("SketchFlow Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEspecialidad.FormattingEnabled = true;
            this.cboEspecialidad.Items.AddRange(new object[] {
            "Bioquimico Especialista en Hematologia-Postgrado-"});
            this.cboEspecialidad.Location = new System.Drawing.Point(13, 66);
            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Size = new System.Drawing.Size(342, 21);
            this.cboEspecialidad.TabIndex = 25;
            // 
            // btnGenerarPDFPPT
            // 
            this.btnGenerarPDFPPT.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerarPDFPPT.FlatAppearance.BorderSize = 0;
            this.btnGenerarPDFPPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPDFPPT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDFPPT.ForeColor = System.Drawing.Color.Red;
            this.btnGenerarPDFPPT.Image = global::HematoLab.Properties.Resources.icons8_PDF_32;
            this.btnGenerarPDFPPT.Location = new System.Drawing.Point(242, 93);
            this.btnGenerarPDFPPT.Name = "btnGenerarPDFPPT";
            this.btnGenerarPDFPPT.Size = new System.Drawing.Size(47, 41);
            this.btnGenerarPDFPPT.TabIndex = 24;
            this.btnGenerarPDFPPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarPDFPPT.UseVisualStyleBackColor = false;
            this.btnGenerarPDFPPT.Click += new System.EventHandler(this.btnGenerarPDFPPT_Click_2);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(302, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "Especialista en Hematologia";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("SketchFlow Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(424, 47);
            this.label3.TabIndex = 21;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Image = global::HematoLab.Properties.Resources.icons8_Exit2_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(1005, 664);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 55);
            this.button2.TabIndex = 18;
            this.button2.Text = "Salir";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormInformesGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 724);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cboSeleccion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FormInformesGestionUsuarios";
            this.Padding = new System.Windows.Forms.Padding(20, 69, 20, 23);
            this.Resizable = false;
            this.Text = "Informes Usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInformesGestionUsuarios_FormClosing_1);
            this.Load += new System.EventHandler(this.FormInformesGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxPEXT.ResumeLayout(false);
            this.groupBoxPNM.ResumeLayout(false);
            this.groupBoxPNM.PerformLayout();
            this.groupBoxFiltroPPT.ResumeLayout(false);
            this.groupBoxFiltroPPT.PerformLayout();
            this.groupBox1FiltroPPE.ResumeLayout(false);
            this.groupBox1FiltroPPE.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboSeleccion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxFiltroPPT;
        private System.Windows.Forms.ComboBox cboTurnos;
        private System.Windows.Forms.Button btnFiltroPPT;
        private System.Windows.Forms.Button btnCargarListaPPT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxPNM;
        private System.Windows.Forms.Button btnGenerarPDFPNM;
        private System.Windows.Forms.Button btnListadoPNM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxPEXT;
        private System.Windows.Forms.Button btnFiltroPExt;
        private System.Windows.Forms.ComboBox cboTurnoExt;
        private System.Windows.Forms.Button btnGenerarPDFPExt;
        private System.Windows.Forms.Button btnListadoPExt;
        private System.Windows.Forms.Button btnFiltroEspHem;
        private System.Windows.Forms.Button btnGenerarPDFPPT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1FiltroPPE;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.Label label5;
    }
}
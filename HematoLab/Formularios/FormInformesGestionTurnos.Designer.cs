namespace HematoLab.Formularios
{
    partial class FormInformesGestionTurnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformesGestionTurnos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxDatosCont = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLstDatosContactoPDF = new System.Windows.Forms.Button();
            this.groupBoxFiltroOS = new System.Windows.Forms.GroupBox();
            this.btnGenerarPDFOS = new System.Windows.Forms.Button();
            this.cboObraSocial = new System.Windows.Forms.ComboBox();
            this.btnCargarLista = new System.Windows.Forms.Button();
            this.btnFiltroOS = new System.Windows.Forms.Button();
            this.groupBoxFiltroGE = new System.Windows.Forms.GroupBox();
            this.cboGrupoEtario = new System.Windows.Forms.ComboBox();
            this.btnFiltroGrupoEtario = new System.Windows.Forms.Button();
            this.btnCargarListaPorGE = new System.Windows.Forms.Button();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.cboSeleccion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBoxDatosCont.SuspendLayout();
            this.groupBoxFiltroOS.SuspendLayout();
            this.groupBoxFiltroGE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.groupBoxDatosCont);
            this.panel1.Controls.Add(this.groupBoxFiltroOS);
            this.panel1.Controls.Add(this.groupBoxFiltroGE);
            this.panel1.Location = new System.Drawing.Point(9, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 464);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxDatosCont
            // 
            this.groupBoxDatosCont.Controls.Add(this.button1);
            this.groupBoxDatosCont.Controls.Add(this.btnLstDatosContactoPDF);
            this.groupBoxDatosCont.Enabled = false;
            this.groupBoxDatosCont.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDatosCont.ForeColor = System.Drawing.Color.White;
            this.groupBoxDatosCont.Location = new System.Drawing.Point(3, 314);
            this.groupBoxDatosCont.Name = "groupBoxDatosCont";
            this.groupBoxDatosCont.Size = new System.Drawing.Size(350, 134);
            this.groupBoxDatosCont.TabIndex = 11;
            this.groupBoxDatosCont.TabStop = false;
            this.groupBoxDatosCont.Text = "Listado con datos de contacto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::HematoLab.Properties.Resources.icons8_Select_All_32;
            this.button1.Location = new System.Drawing.Point(128, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 48);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLstDatosContactoPDF
            // 
            this.btnLstDatosContactoPDF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLstDatosContactoPDF.FlatAppearance.BorderSize = 0;
            this.btnLstDatosContactoPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLstDatosContactoPDF.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLstDatosContactoPDF.ForeColor = System.Drawing.Color.Red;
            this.btnLstDatosContactoPDF.Image = global::HematoLab.Properties.Resources.PDF_48px2;
            this.btnLstDatosContactoPDF.Location = new System.Drawing.Point(177, 53);
            this.btnLstDatosContactoPDF.Name = "btnLstDatosContactoPDF";
            this.btnLstDatosContactoPDF.Size = new System.Drawing.Size(44, 48);
            this.btnLstDatosContactoPDF.TabIndex = 18;
            this.btnLstDatosContactoPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLstDatosContactoPDF.UseVisualStyleBackColor = false;
            this.btnLstDatosContactoPDF.Click += new System.EventHandler(this.btnLstDatosContactoPDF_Click);
            // 
            // groupBoxFiltroOS
            // 
            this.groupBoxFiltroOS.Controls.Add(this.btnGenerarPDFOS);
            this.groupBoxFiltroOS.Controls.Add(this.cboObraSocial);
            this.groupBoxFiltroOS.Controls.Add(this.btnCargarLista);
            this.groupBoxFiltroOS.Controls.Add(this.btnFiltroOS);
            this.groupBoxFiltroOS.Enabled = false;
            this.groupBoxFiltroOS.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFiltroOS.ForeColor = System.Drawing.Color.White;
            this.groupBoxFiltroOS.Location = new System.Drawing.Point(3, 164);
            this.groupBoxFiltroOS.Name = "groupBoxFiltroOS";
            this.groupBoxFiltroOS.Size = new System.Drawing.Size(350, 122);
            this.groupBoxFiltroOS.TabIndex = 11;
            this.groupBoxFiltroOS.TabStop = false;
            this.groupBoxFiltroOS.Text = "Filtro por Obra Social";
            // 
            // btnGenerarPDFOS
            // 
            this.btnGenerarPDFOS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerarPDFOS.FlatAppearance.BorderSize = 0;
            this.btnGenerarPDFOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPDFOS.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDFOS.ForeColor = System.Drawing.Color.Red;
            this.btnGenerarPDFOS.Image = global::HematoLab.Properties.Resources.PDF_48px2;
            this.btnGenerarPDFOS.Location = new System.Drawing.Point(290, 44);
            this.btnGenerarPDFOS.Name = "btnGenerarPDFOS";
            this.btnGenerarPDFOS.Size = new System.Drawing.Size(44, 48);
            this.btnGenerarPDFOS.TabIndex = 17;
            this.btnGenerarPDFOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarPDFOS.UseVisualStyleBackColor = false;
            this.btnGenerarPDFOS.Click += new System.EventHandler(this.btnGenerarPDFOS_Click);
            // 
            // cboObraSocial
            // 
            this.cboObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObraSocial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboObraSocial.FormattingEnabled = true;
            this.cboObraSocial.Location = new System.Drawing.Point(18, 50);
            this.cboObraSocial.Name = "cboObraSocial";
            this.cboObraSocial.Size = new System.Drawing.Size(157, 29);
            this.cboObraSocial.TabIndex = 13;
            // 
            // btnCargarLista
            // 
            this.btnCargarLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCargarLista.FlatAppearance.BorderSize = 0;
            this.btnCargarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarLista.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarLista.ForeColor = System.Drawing.Color.White;
            this.btnCargarLista.Image = global::HematoLab.Properties.Resources.icons8_Select_All_32;
            this.btnCargarLista.Location = new System.Drawing.Point(241, 44);
            this.btnCargarLista.Name = "btnCargarLista";
            this.btnCargarLista.Size = new System.Drawing.Size(44, 48);
            this.btnCargarLista.TabIndex = 7;
            this.btnCargarLista.UseVisualStyleBackColor = false;
            this.btnCargarLista.Click += new System.EventHandler(this.btnCargarLista_Click);
            // 
            // btnFiltroOS
            // 
            this.btnFiltroOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiltroOS.FlatAppearance.BorderSize = 0;
            this.btnFiltroOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroOS.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroOS.ForeColor = System.Drawing.Color.White;
            this.btnFiltroOS.Image = global::HematoLab.Properties.Resources.icons8_Filter_32;
            this.btnFiltroOS.Location = new System.Drawing.Point(191, 44);
            this.btnFiltroOS.Name = "btnFiltroOS";
            this.btnFiltroOS.Size = new System.Drawing.Size(44, 48);
            this.btnFiltroOS.TabIndex = 15;
            this.btnFiltroOS.UseVisualStyleBackColor = false;
            this.btnFiltroOS.Click += new System.EventHandler(this.btnFiltroOS_Click);
            // 
            // groupBoxFiltroGE
            // 
            this.groupBoxFiltroGE.Controls.Add(this.cboGrupoEtario);
            this.groupBoxFiltroGE.Controls.Add(this.btnFiltroGrupoEtario);
            this.groupBoxFiltroGE.Controls.Add(this.btnCargarListaPorGE);
            this.groupBoxFiltroGE.Controls.Add(this.btnGenerarPDF);
            this.groupBoxFiltroGE.Enabled = false;
            this.groupBoxFiltroGE.Font = new System.Drawing.Font("SketchFlow Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFiltroGE.ForeColor = System.Drawing.Color.White;
            this.groupBoxFiltroGE.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFiltroGE.Name = "groupBoxFiltroGE";
            this.groupBoxFiltroGE.Size = new System.Drawing.Size(350, 135);
            this.groupBoxFiltroGE.TabIndex = 11;
            this.groupBoxFiltroGE.TabStop = false;
            this.groupBoxFiltroGE.Text = "Filtro por Grupo Etario";
            // 
            // cboGrupoEtario
            // 
            this.cboGrupoEtario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoEtario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGrupoEtario.FormattingEnabled = true;
            this.cboGrupoEtario.Location = new System.Drawing.Point(18, 54);
            this.cboGrupoEtario.Name = "cboGrupoEtario";
            this.cboGrupoEtario.Size = new System.Drawing.Size(157, 29);
            this.cboGrupoEtario.TabIndex = 10;
            // 
            // btnFiltroGrupoEtario
            // 
            this.btnFiltroGrupoEtario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiltroGrupoEtario.FlatAppearance.BorderSize = 0;
            this.btnFiltroGrupoEtario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroGrupoEtario.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroGrupoEtario.ForeColor = System.Drawing.Color.White;
            this.btnFiltroGrupoEtario.Image = global::HematoLab.Properties.Resources.icons8_Filter_32;
            this.btnFiltroGrupoEtario.Location = new System.Drawing.Point(190, 48);
            this.btnFiltroGrupoEtario.Name = "btnFiltroGrupoEtario";
            this.btnFiltroGrupoEtario.Size = new System.Drawing.Size(44, 48);
            this.btnFiltroGrupoEtario.TabIndex = 12;
            this.btnFiltroGrupoEtario.UseVisualStyleBackColor = false;
            this.btnFiltroGrupoEtario.Click += new System.EventHandler(this.btnFiltroGrupoEtario_Click);
            // 
            // btnCargarListaPorGE
            // 
            this.btnCargarListaPorGE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCargarListaPorGE.FlatAppearance.BorderSize = 0;
            this.btnCargarListaPorGE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarListaPorGE.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarListaPorGE.ForeColor = System.Drawing.Color.White;
            this.btnCargarListaPorGE.Image = global::HematoLab.Properties.Resources.icons8_Select_All_32;
            this.btnCargarListaPorGE.Location = new System.Drawing.Point(240, 48);
            this.btnCargarListaPorGE.Name = "btnCargarListaPorGE";
            this.btnCargarListaPorGE.Size = new System.Drawing.Size(44, 48);
            this.btnCargarListaPorGE.TabIndex = 10;
            this.btnCargarListaPorGE.UseVisualStyleBackColor = false;
            this.btnCargarListaPorGE.Click += new System.EventHandler(this.btnCargarListaPorGE_Click);
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerarPDF.FlatAppearance.BorderSize = 0;
            this.btnGenerarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPDF.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDF.ForeColor = System.Drawing.Color.Red;
            this.btnGenerarPDF.Image = global::HematoLab.Properties.Resources.PDF_48px2;
            this.btnGenerarPDF.Location = new System.Drawing.Point(290, 48);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(44, 48);
            this.btnGenerarPDF.TabIndex = 9;
            this.btnGenerarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarPDF.UseVisualStyleBackColor = false;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("SketchFlow Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(369, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(815, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listados y generación de informes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(369, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(815, 464);
            this.dataGridView1.TabIndex = 8;
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
            this.button2.Location = new System.Drawing.Point(1007, 590);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "Salir";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboSeleccion
            // 
            this.cboSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSeleccion.Font = new System.Drawing.Font("Microsoft NeoGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeleccion.FormattingEnabled = true;
            this.cboSeleccion.Items.AddRange(new object[] {
            "Seleccionar...",
            "Filtro por grupo etario",
            "Filtro por obra social",
            "Listado con datos de contacto"});
            this.cboSeleccion.Location = new System.Drawing.Point(140, 81);
            this.cboSeleccion.Name = "cboSeleccion";
            this.cboSeleccion.Size = new System.Drawing.Size(217, 28);
            this.cboSeleccion.TabIndex = 12;
            this.cboSeleccion.SelectedIndexChanged += new System.EventHandler(this.cboSeleccion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("SketchFlow Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Selección";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("SketchFlow Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(356, 41);
            this.label3.TabIndex = 14;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormInformesGestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 649);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cboSeleccion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormInformesGestionTurnos";
            this.Opacity = 0.97D;
            this.Padding = new System.Windows.Forms.Padding(23, 74, 23, 25);
            this.Resizable = false;
            this.Text = "Informes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInformesGestionTurnos_FormClosing);
            this.Load += new System.EventHandler(this.FormInfPacObraSocial_Load);
            this.panel1.ResumeLayout(false);
            this.groupBoxDatosCont.ResumeLayout(false);
            this.groupBoxFiltroOS.ResumeLayout(false);
            this.groupBoxFiltroGE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarLista;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Button btnCargarListaPorGE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFiltroGrupoEtario;
        private System.Windows.Forms.ComboBox cboGrupoEtario;
        private System.Windows.Forms.Button btnFiltroOS;
        private System.Windows.Forms.ComboBox cboObraSocial;
        private System.Windows.Forms.Button btnGenerarPDFOS;
        private System.Windows.Forms.Button btnLstDatosContactoPDF;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxDatosCont;
        private System.Windows.Forms.GroupBox groupBoxFiltroOS;
        private System.Windows.Forms.GroupBox groupBoxFiltroGE;
        private System.Windows.Forms.ComboBox cboSeleccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
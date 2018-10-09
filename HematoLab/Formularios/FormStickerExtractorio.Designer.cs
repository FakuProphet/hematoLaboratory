namespace HematoLab.Formularios
{
    partial class FormStickerExtractorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStickerExtractorio));
            this.groupBoxPrueba = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnImprimirSticker = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFechaDup = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDocDup = new System.Windows.Forms.Label();
            this.lblNombreDup = new System.Windows.Forms.Label();
            this.lblNroSticker = new System.Windows.Forms.Label();
            this.lblStickerDup = new System.Windows.Forms.Label();
            this.groupBoxPrueba.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPrueba
            // 
            this.groupBoxPrueba.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxPrueba.Controls.Add(this.lblStickerDup);
            this.groupBoxPrueba.Controls.Add(this.lblNroSticker);
            this.groupBoxPrueba.Controls.Add(this.label5);
            this.groupBoxPrueba.Controls.Add(this.lblFechaDup);
            this.groupBoxPrueba.Controls.Add(this.label7);
            this.groupBoxPrueba.Controls.Add(this.groupBox3);
            this.groupBoxPrueba.Controls.Add(this.label8);
            this.groupBoxPrueba.Controls.Add(this.lblDocDup);
            this.groupBoxPrueba.Controls.Add(this.lblNombreDup);
            this.groupBoxPrueba.Controls.Add(this.label2);
            this.groupBoxPrueba.Controls.Add(this.lblFecha);
            this.groupBoxPrueba.Controls.Add(this.label3);
            this.groupBoxPrueba.Controls.Add(this.groupBox2);
            this.groupBoxPrueba.Controls.Add(this.label1);
            this.groupBoxPrueba.Controls.Add(this.groupBox1);
            this.groupBoxPrueba.Controls.Add(this.lblDni);
            this.groupBoxPrueba.Controls.Add(this.lblNombre);
            this.groupBoxPrueba.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPrueba.Location = new System.Drawing.Point(31, 68);
            this.groupBoxPrueba.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPrueba.Name = "groupBoxPrueba";
            this.groupBoxPrueba.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPrueba.Size = new System.Drawing.Size(550, 186);
            this.groupBoxPrueba.TabIndex = 0;
            this.groupBoxPrueba.TabStop = false;
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(7, 85);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(125, 22);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "\'\'\'";
            this.lblDni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(31, 18);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(219, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "...";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImprimirSticker
            // 
            this.btnImprimirSticker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirSticker.Image = global::HematoLab.Properties.Resources.icons8_Multifunction_Printer_32;
            this.btnImprimirSticker.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirSticker.Location = new System.Drawing.Point(443, 305);
            this.btnImprimirSticker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImprimirSticker.Name = "btnImprimirSticker";
            this.btnImprimirSticker.Size = new System.Drawing.Size(138, 45);
            this.btnImprimirSticker.TabIndex = 50;
            this.btnImprimirSticker.Text = "Imprimir";
            this.btnImprimirSticker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirSticker.UseVisualStyleBackColor = true;
            this.btnImprimirSticker.Click += new System.EventHandler(this.btnImprimirSticker_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 2);
            this.label1.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(275, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(136, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2, 140);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 51;
            this.label3.Text = "DNI";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 54;
            this.label2.Text = "NRO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(144, 85);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(125, 22);
            this.lblFecha.TabIndex = 53;
            this.lblFecha.Text = "\'\'\'";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(420, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 22);
            this.label5.TabIndex = 61;
            this.label5.Text = "NRO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaDup
            // 
            this.lblFechaDup.Location = new System.Drawing.Point(420, 85);
            this.lblFechaDup.Name = "lblFechaDup";
            this.lblFechaDup.Size = new System.Drawing.Size(125, 22);
            this.lblFechaDup.TabIndex = 60;
            this.lblFechaDup.Text = "\'\'\'";
            this.lblFechaDup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(297, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 22);
            this.label7.TabIndex = 57;
            this.label7.Text = "DNI";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(412, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(2, 142);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(277, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(276, 2);
            this.label8.TabIndex = 58;
            // 
            // lblDocDup
            // 
            this.lblDocDup.Location = new System.Drawing.Point(283, 85);
            this.lblDocDup.Name = "lblDocDup";
            this.lblDocDup.Size = new System.Drawing.Size(125, 22);
            this.lblDocDup.TabIndex = 56;
            this.lblDocDup.Text = "\'\'\'";
            this.lblDocDup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombreDup
            // 
            this.lblNombreDup.Location = new System.Drawing.Point(307, 18);
            this.lblNombreDup.Name = "lblNombreDup";
            this.lblNombreDup.Size = new System.Drawing.Size(219, 20);
            this.lblNombreDup.TabIndex = 55;
            this.lblNombreDup.Text = "...";
            this.lblNombreDup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNroSticker
            // 
            this.lblNroSticker.Location = new System.Drawing.Point(192, 48);
            this.lblNroSticker.Name = "lblNroSticker";
            this.lblNroSticker.Size = new System.Drawing.Size(77, 22);
            this.lblNroSticker.TabIndex = 54;
            this.lblNroSticker.Text = "\'\'\'";
            this.lblNroSticker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStickerDup
            // 
            this.lblStickerDup.Location = new System.Drawing.Point(466, 48);
            this.lblStickerDup.Name = "lblStickerDup";
            this.lblStickerDup.Size = new System.Drawing.Size(77, 22);
            this.lblStickerDup.TabIndex = 62;
            this.lblStickerDup.Text = "\'\'\'";
            this.lblStickerDup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormStickerExtractorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 390);
            this.Controls.Add(this.btnImprimirSticker);
            this.Controls.Add(this.groupBoxPrueba);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormStickerExtractorio";
            this.Padding = new System.Windows.Forms.Padding(27, 65, 27, 22);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Sticker";
            this.Load += new System.EventHandler(this.FormStickerExtractorio_Load);
            this.groupBoxPrueba.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPrueba;
        private System.Windows.Forms.Button btnImprimirSticker;
        protected internal System.Windows.Forms.Label lblDni;
        protected internal System.Windows.Forms.Label lblNombre;
        protected internal System.Windows.Forms.Label label5;
        protected internal System.Windows.Forms.Label lblFechaDup;
        protected internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        protected internal System.Windows.Forms.Label lblDocDup;
        protected internal System.Windows.Forms.Label lblNombreDup;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Label lblFecha;
        protected internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        protected internal System.Windows.Forms.Label lblStickerDup;
        protected internal System.Windows.Forms.Label lblNroSticker;
    }
}
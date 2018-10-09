namespace HematoLab.Reporte
{
    partial class FormInforme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInforme));
            this.crystalReportViewerNuevo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerNuevo
            // 
            this.crystalReportViewerNuevo.ActiveViewIndex = -1;
            this.crystalReportViewerNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerNuevo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerNuevo.Location = new System.Drawing.Point(20, 60);
            this.crystalReportViewerNuevo.Name = "crystalReportViewerNuevo";
            this.crystalReportViewerNuevo.ShowLogo = false;
            this.crystalReportViewerNuevo.Size = new System.Drawing.Size(883, 330);
            this.crystalReportViewerNuevo.TabIndex = 0;
            this.crystalReportViewerNuevo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 410);
            this.Controls.Add(this.crystalReportViewerNuevo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInforme";
            this.Text = "Informe";
            this.Load += new System.EventHandler(this.FormInforme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerNuevo;
    }
}
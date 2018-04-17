namespace UI.Desktop
{
    partial class formRCursos
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
            this.crvCursos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CursosODBC1 = new UI.Desktop.CursosODBC();
            this.SuspendLayout();
            // 
            // crvCursos
            // 
            this.crvCursos.ActiveViewIndex = 0;
            this.crvCursos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCursos.CachedPageNumberPerDoc = 10;
            this.crvCursos.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCursos.Location = new System.Drawing.Point(0, 0);
            this.crvCursos.Name = "crvCursos";
            this.crvCursos.ReportSource = this.CursosODBC1;
            this.crvCursos.Size = new System.Drawing.Size(1027, 484);
            this.crvCursos.TabIndex = 0;
            // 
            // formRCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 484);
            this.Controls.Add(this.crvCursos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formRCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de cursos";
            this.Load += new System.EventHandler(this.formRCursos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCursos;
        private CursosODBC CursosODBC1;
        
    }
}
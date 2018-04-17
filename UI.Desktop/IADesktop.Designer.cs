namespace UI.Desktop
{
    partial class IADesktop
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
            this.tbInscripcion = new System.Windows.Forms.TableLayoutPanel();
            this.cbxIAs = new System.Windows.Forms.ComboBox();
            this.txtIDAlumno = new System.Windows.Forms.TextBox();
            this.txtIDInscripcion = new System.Windows.Forms.TextBox();
            this.lblIDCurso = new System.Windows.Forms.Label();
            this.lblIDAlumno = new System.Windows.Forms.Label();
            this.lblIDDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tbInscripcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInscripcion
            // 
            this.tbInscripcion.ColumnCount = 6;
            this.tbInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.21348F));
            this.tbInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.78651F));
            this.tbInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tbInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tbInscripcion.Controls.Add(this.cbxIAs, 1, 3);
            this.tbInscripcion.Controls.Add(this.txtIDAlumno, 1, 2);
            this.tbInscripcion.Controls.Add(this.txtIDInscripcion, 1, 1);
            this.tbInscripcion.Controls.Add(this.lblIDCurso, 0, 3);
            this.tbInscripcion.Controls.Add(this.lblIDAlumno, 0, 2);
            this.tbInscripcion.Controls.Add(this.lblIDDescripcion, 0, 1);
            this.tbInscripcion.Controls.Add(this.label1, 3, 1);
            this.tbInscripcion.Controls.Add(this.label2, 3, 2);
            this.tbInscripcion.Controls.Add(this.txtNota, 4, 1);
            this.tbInscripcion.Controls.Add(this.txtCondicion, 4, 2);
            this.tbInscripcion.Controls.Add(this.btnCancelar, 5, 4);
            this.tbInscripcion.Controls.Add(this.btnAceptar, 4, 4);
            this.tbInscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInscripcion.Location = new System.Drawing.Point(0, 0);
            this.tbInscripcion.Name = "tbInscripcion";
            this.tbInscripcion.RowCount = 5;
            this.tbInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.79487F));
            this.tbInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.50427F));
            this.tbInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.38095F));
            this.tbInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.38095F));
            this.tbInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbInscripcion.Size = new System.Drawing.Size(624, 195);
            this.tbInscripcion.TabIndex = 0;
            // 
            // cbxIAs
            // 
            this.cbxIAs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxIAs.FormattingEnabled = true;
            this.cbxIAs.Location = new System.Drawing.Point(78, 131);
            this.cbxIAs.Name = "cbxIAs";
            this.cbxIAs.Size = new System.Drawing.Size(175, 21);
            this.cbxIAs.TabIndex = 12;
            // 
            // txtIDAlumno
            // 
            this.txtIDAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDAlumno.Enabled = false;
            this.txtIDAlumno.Location = new System.Drawing.Point(78, 86);
            this.txtIDAlumno.Name = "txtIDAlumno";
            this.txtIDAlumno.Size = new System.Drawing.Size(175, 20);
            this.txtIDAlumno.TabIndex = 8;
            // 
            // txtIDInscripcion
            // 
            this.txtIDInscripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDInscripcion.Enabled = false;
            this.txtIDInscripcion.Location = new System.Drawing.Point(78, 45);
            this.txtIDInscripcion.Name = "txtIDInscripcion";
            this.txtIDInscripcion.Size = new System.Drawing.Size(175, 20);
            this.txtIDInscripcion.TabIndex = 7;
            // 
            // lblIDCurso
            // 
            this.lblIDCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDCurso.AutoSize = true;
            this.lblIDCurso.Location = new System.Drawing.Point(15, 135);
            this.lblIDCurso.Name = "lblIDCurso";
            this.lblIDCurso.Size = new System.Drawing.Size(45, 13);
            this.lblIDCurso.TabIndex = 4;
            this.lblIDCurso.Text = "IDCurso";
            // 
            // lblIDAlumno
            // 
            this.lblIDAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDAlumno.AutoSize = true;
            this.lblIDAlumno.Location = new System.Drawing.Point(11, 90);
            this.lblIDAlumno.Name = "lblIDAlumno";
            this.lblIDAlumno.Size = new System.Drawing.Size(53, 13);
            this.lblIDAlumno.TabIndex = 3;
            this.lblIDAlumno.Text = "IDAlumno";
            // 
            // lblIDDescripcion
            // 
            this.lblIDDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDDescripcion.AutoSize = true;
            this.lblIDDescripcion.Location = new System.Drawing.Point(3, 48);
            this.lblIDDescripcion.Name = "lblIDDescripcion";
            this.lblIDDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblIDDescripcion.TabIndex = 2;
            this.lblIDDescripcion.Text = "IDInscripción";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nota";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Condición";
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota.Location = new System.Drawing.Point(319, 45);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(191, 20);
            this.txtNota.TabIndex = 15;
            this.txtNota.Text = "0";
            // 
            // txtCondicion
            // 
            this.txtCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCondicion.Location = new System.Drawing.Point(319, 86);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(191, 20);
            this.txtCondicion.TabIndex = 16;
            this.txtCondicion.Text = "Inscripto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(516, 167);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(435, 167);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // IADesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 195);
            this.Controls.Add(this.tbInscripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IADesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripción a Cursos";
            this.Load += new System.EventHandler(this.IADesktop_Load);
            this.tbInscripcion.ResumeLayout(false);
            this.tbInscripcion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbInscripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIDDescripcion;
        private System.Windows.Forms.Label lblIDAlumno;
        private System.Windows.Forms.Label lblIDCurso;
        private System.Windows.Forms.TextBox txtIDInscripcion;
        private System.Windows.Forms.TextBox txtIDAlumno;
        private System.Windows.Forms.ComboBox cbxIAs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.TextBox txtCondicion;
    }
}
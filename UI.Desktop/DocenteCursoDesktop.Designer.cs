namespace UI.Desktop
{
    partial class DocenteCursoDesktop
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
            this.tbnInscripcion = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDCurso = new System.Windows.Forms.Label();
            this.cboTipoCargo = new System.Windows.Forms.ComboBox();
            this.lblIdDictado = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIDDocente = new System.Windows.Forms.Label();
            this.txtIDDocente = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCargo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboCursos = new System.Windows.Forms.ComboBox();
            this.tbnInscripcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbnInscripcion
            // 
            this.tbnInscripcion.ColumnCount = 6;
            this.tbnInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.69176F));
            this.tbnInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.30824F));
            this.tbnInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbnInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbnInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tbnInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tbnInscripcion.Controls.Add(this.lblIDCurso, 0, 2);
            this.tbnInscripcion.Controls.Add(this.cboTipoCargo, 4, 2);
            this.tbnInscripcion.Controls.Add(this.lblIdDictado, 0, 1);
            this.tbnInscripcion.Controls.Add(this.txtID, 1, 1);
            this.tbnInscripcion.Controls.Add(this.lblIDDocente, 2, 1);
            this.tbnInscripcion.Controls.Add(this.txtIDDocente, 4, 1);
            this.tbnInscripcion.Controls.Add(this.btnCancelar, 5, 3);
            this.tbnInscripcion.Controls.Add(this.lblCargo, 2, 2);
            this.tbnInscripcion.Controls.Add(this.btnAceptar, 4, 3);
            this.tbnInscripcion.Controls.Add(this.cboCursos, 1, 2);
            this.tbnInscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbnInscripcion.Location = new System.Drawing.Point(0, 0);
            this.tbnInscripcion.Name = "tbnInscripcion";
            this.tbnInscripcion.RowCount = 4;
            this.tbnInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.33333F));
            this.tbnInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.66667F));
            this.tbnInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tbnInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tbnInscripcion.Size = new System.Drawing.Size(628, 199);
            this.tbnInscripcion.TabIndex = 0;
            // 
            // lblIDCurso
            // 
            this.lblIDCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDCurso.AutoSize = true;
            this.lblIDCurso.Location = new System.Drawing.Point(19, 121);
            this.lblIDCurso.Name = "lblIDCurso";
            this.lblIDCurso.Size = new System.Drawing.Size(48, 13);
            this.lblIDCurso.TabIndex = 2;
            this.lblIDCurso.Text = "ID Curso";
            // 
            // cboTipoCargo
            // 
            this.cboTipoCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTipoCargo.FormattingEnabled = true;
            this.cboTipoCargo.Location = new System.Drawing.Point(330, 117);
            this.cboTipoCargo.Name = "cboTipoCargo";
            this.cboTipoCargo.Size = new System.Drawing.Size(180, 21);
            this.cboTipoCargo.TabIndex = 7;
            // 
            // lblIdDictado
            // 
            this.lblIdDictado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdDictado.Location = new System.Drawing.Point(3, 55);
            this.lblIdDictado.Name = "lblIdDictado";
            this.lblIdDictado.Size = new System.Drawing.Size(81, 38);
            this.lblIdDictado.TabIndex = 0;
            this.lblIdDictado.Text = "ID Dictado";
            this.lblIdDictado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(90, 64);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(166, 20);
            this.txtID.TabIndex = 1;
            // 
            // lblIDDocente
            // 
            this.lblIDDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDDocente.AutoSize = true;
            this.lblIDDocente.Location = new System.Drawing.Point(262, 67);
            this.lblIDDocente.Name = "lblIDDocente";
            this.lblIDDocente.Size = new System.Drawing.Size(62, 13);
            this.lblIDDocente.TabIndex = 4;
            this.lblIDDocente.Text = "ID Docente";
            // 
            // txtIDDocente
            // 
            this.txtIDDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDDocente.Enabled = false;
            this.txtIDDocente.Location = new System.Drawing.Point(330, 64);
            this.txtIDDocente.Name = "txtIDDocente";
            this.txtIDDocente.Size = new System.Drawing.Size(180, 20);
            this.txtIDDocente.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(516, 165);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCargo
            // 
            this.lblCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(275, 121);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(35, 13);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "Cargo";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(435, 165);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboCursos
            // 
            this.cboCursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCursos.FormattingEnabled = true;
            this.cboCursos.Location = new System.Drawing.Point(90, 117);
            this.cboCursos.Name = "cboCursos";
            this.cboCursos.Size = new System.Drawing.Size(166, 21);
            this.cboCursos.TabIndex = 10;
            // 
            // DocenteCursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 199);
            this.Controls.Add(this.tbnInscripcion);
            this.Name = "DocenteCursoDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Docente Curso";
            this.Load += new System.EventHandler(this.DocenteCursoDesktop_Load);
            this.tbnInscripcion.ResumeLayout(false);
            this.tbnInscripcion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbnInscripcion;
        private System.Windows.Forms.Label lblIdDictado;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblIDCurso;
        private System.Windows.Forms.Label lblIDDocente;
        private System.Windows.Forms.TextBox txtIDDocente;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cboTipoCargo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboCursos;
    }
}
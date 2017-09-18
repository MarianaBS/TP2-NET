namespace UI.Desktop
{
    partial class MisCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MisCursos));
            this.gbCursos = new System.Windows.Forms.GroupBox();
            this.txtApyNom = new System.Windows.Forms.TextBox();
            this.lblApellidoYNom = new System.Windows.Forms.Label();
            this.cbxCursos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAlumInsc = new System.Windows.Forms.GroupBox();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCursos.SuspendLayout();
            this.gbAlumInsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCursos
            // 
            this.gbCursos.Controls.Add(this.txtApyNom);
            this.gbCursos.Controls.Add(this.lblApellidoYNom);
            this.gbCursos.Controls.Add(this.cbxCursos);
            this.gbCursos.Controls.Add(this.label1);
            this.gbCursos.Location = new System.Drawing.Point(32, 12);
            this.gbCursos.Name = "gbCursos";
            this.gbCursos.Size = new System.Drawing.Size(675, 109);
            this.gbCursos.TabIndex = 0;
            this.gbCursos.TabStop = false;
            this.gbCursos.Text = "Mis Cursos";
            // 
            // txtApyNom
            // 
            this.txtApyNom.Enabled = false;
            this.txtApyNom.Location = new System.Drawing.Point(128, 25);
            this.txtApyNom.Name = "txtApyNom";
            this.txtApyNom.Size = new System.Drawing.Size(202, 20);
            this.txtApyNom.TabIndex = 3;
            // 
            // lblApellidoYNom
            // 
            this.lblApellidoYNom.AutoSize = true;
            this.lblApellidoYNom.Location = new System.Drawing.Point(20, 25);
            this.lblApellidoYNom.Name = "lblApellidoYNom";
            this.lblApellidoYNom.Size = new System.Drawing.Size(90, 13);
            this.lblApellidoYNom.TabIndex = 2;
            this.lblApellidoYNom.Text = "Apellido y nombre";
            // 
            // cbxCursos
            // 
            this.cbxCursos.FormattingEnabled = true;
            this.cbxCursos.Location = new System.Drawing.Point(128, 66);
            this.cbxCursos.Name = "cbxCursos";
            this.cbxCursos.Size = new System.Drawing.Size(202, 21);
            this.cbxCursos.TabIndex = 1;
            this.cbxCursos.SelectedIndexChanged += new System.EventHandler(this.cbxCursos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IDCurso";
            // 
            // gbAlumInsc
            // 
            this.gbAlumInsc.Controls.Add(this.dgvAlumnos);
            this.gbAlumInsc.Location = new System.Drawing.Point(29, 127);
            this.gbAlumInsc.Name = "gbAlumInsc";
            this.gbAlumInsc.Size = new System.Drawing.Size(677, 258);
            this.gbAlumInsc.TabIndex = 1;
            this.gbAlumInsc.TabStop = false;
            this.gbAlumInsc.Text = "Alumnos Inscriptos";
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Apellido,
            this.Nombre,
            this.Email});
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.Location = new System.Drawing.Point(3, 16);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.Size = new System.Drawing.Size(671, 239);
            this.dgvAlumnos.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // MisCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 407);
            this.Controls.Add(this.gbAlumInsc);
            this.Controls.Add(this.gbCursos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MisCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MisCursos";
            this.Load += new System.EventHandler(this.MisCursos_Load);
            this.gbCursos.ResumeLayout(false);
            this.gbCursos.PerformLayout();
            this.gbAlumInsc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCursos;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.GroupBox gbAlumInsc;
        private System.Windows.Forms.TextBox txtApyNom;
        private System.Windows.Forms.Label lblApellidoYNom;
        private System.Windows.Forms.ComboBox cbxCursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}
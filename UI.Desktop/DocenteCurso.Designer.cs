namespace UI.Desktop
{
    partial class DocenteCurso
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

         /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsBorrar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvDocCursos = new System.Windows.Forms.DataGridView();
            this.id_dictado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_docente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tsPrincipal);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(551, 13);
            this.toolStripContainer1.Location = new System.Drawing.Point(1, -4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(551, 38);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNuevo,
            this.tsEditar,
            this.tsBorrar});
            this.tsPrincipal.Location = new System.Drawing.Point(3, 1);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(548, 33);
            this.tsPrincipal.TabIndex = 0;
            // 
            // tsNuevo
            // 
            this.tsNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNuevo.Image = global::UI.Desktop.Properties.Resources.add_icon_icons1;
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(23, 30);
            this.tsNuevo.Text = "tsNuevo";
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click_1);
            // 
            // tsEditar
            // 
            this.tsEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEditar.Image = global::UI.Desktop.Properties.Resources.edit_validated_40458;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(23, 30);
            this.tsEditar.Text = "tsEditar";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click_1);
            // 
            // tsBorrar
            // 
            this.tsBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBorrar.Image = global::UI.Desktop.Properties.Resources.eliminar_cancelar_icono_4935_128;
            this.tsBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBorrar.Name = "tsBorrar";
            this.tsBorrar.Size = new System.Drawing.Size(23, 30);
            this.tsBorrar.Text = "tsBorrar";
            this.tsBorrar.Click += new System.EventHandler(this.tsBorrar_Click_1);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(555, 231);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(440, 231);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // dgvDocCursos
            // 
            this.dgvDocCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_dictado,
            this.id_curso,
            this.id_docente,
            this.cargo});
            this.dgvDocCursos.Location = new System.Drawing.Point(1, 33);
            this.dgvDocCursos.Name = "dgvDocCursos";
            this.dgvDocCursos.Size = new System.Drawing.Size(690, 192);
            this.dgvDocCursos.TabIndex = 1;
            // 
            // id_dictado
            // 
            this.id_dictado.DataPropertyName = "ID";
            this.id_dictado.HeaderText = "Id Dictado";
            this.id_dictado.Name = "id_dictado";
            // 
            // id_curso
            // 
            this.id_curso.DataPropertyName = "IDCurso";
            this.id_curso.HeaderText = "Id Curso";
            this.id_curso.Name = "id_curso";
            // 
            // id_docente
            // 
            this.id_docente.DataPropertyName = "IDDocente";
            this.id_docente.HeaderText = "Id Docente";
            this.id_docente.Name = "id_docente";
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "TiposCargo";
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            // 
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click_1);
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click_1);
            this.tsBorrar.Click += new System.EventHandler(this.tsBorrar_Click_1);
            

            // DocenteCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 262);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvDocCursos);
            this.Name = "DocenteCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripción Docentes";
            this.Load += new System.EventHandler(this.DocenteCurso_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocCursos)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.DataGridView dgvDocCursos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dictado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_docente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsNuevo;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private System.Windows.Forms.ToolStripButton tsBorrar;
    }
}
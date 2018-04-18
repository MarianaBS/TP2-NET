namespace UI.Desktop
{
    partial class InscripcionAlumnos
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
            this.tlinsCursos = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvInsCursos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tscTop = new System.Windows.Forms.ToolStripContainer();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsBorrar = new System.Windows.Forms.ToolStripButton();
            this.tlinsCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsCursos)).BeginInit();
            this.tscTop.ContentPanel.SuspendLayout();
            this.tscTop.TopToolStripPanel.SuspendLayout();
            this.tscTop.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlinsCursos
            // 
            this.tlinsCursos.ColumnCount = 2;
            this.tlinsCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlinsCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlinsCursos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlinsCursos.Controls.Add(this.btnSalir, 1, 1);
            this.tlinsCursos.Controls.Add(this.dgvInsCursos, 0, 0);
            this.tlinsCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlinsCursos.Location = new System.Drawing.Point(0, 0);
            this.tlinsCursos.Name = "tlinsCursos";
            this.tlinsCursos.RowCount = 2;
            this.tlinsCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlinsCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlinsCursos.Size = new System.Drawing.Size(787, 312);
            this.tlinsCursos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.Location = new System.Drawing.Point(630, 286);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.Location = new System.Drawing.Point(711, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(73, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvInsCursos
            // 
            this.dgvInsCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDUser,
            this.IDCurso,
            this.Condicion,
            this.Nota});
            this.tlinsCursos.SetColumnSpan(this.dgvInsCursos, 2);
            this.dgvInsCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsCursos.Location = new System.Drawing.Point(3, 3);
            this.dgvInsCursos.MultiSelect = false;
            this.dgvInsCursos.Name = "dgvInsCursos";
            this.dgvInsCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsCursos.Size = new System.Drawing.Size(781, 277);
            this.dgvInsCursos.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "IDInscripcion";
            this.ID.Name = "ID";
            // 
            // IDUser
            // 
            this.IDUser.DataPropertyName = "IDAlumno";
            this.IDUser.HeaderText = "IDUsuario";
            this.IDUser.Name = "IDUser";
            // 
            // IDCurso
            // 
            this.IDCurso.DataPropertyName = "IDCurso";
            this.IDCurso.HeaderText = "IDCurso";
            this.IDCurso.Name = "IDCurso";
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.Name = "Condicion";
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            // 
            // tscTop
            // 
            this.tscTop.BottomToolStripPanelVisible = false;
            // 
            // tscTop.ContentPanel
            // 
            this.tscTop.ContentPanel.AutoScroll = true;
            this.tscTop.ContentPanel.Controls.Add(this.tlinsCursos);
            this.tscTop.ContentPanel.Size = new System.Drawing.Size(787, 312);
            this.tscTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscTop.LeftToolStripPanelVisible = false;
            this.tscTop.Location = new System.Drawing.Point(0, 0);
            this.tscTop.Name = "tscTop";
            this.tscTop.RightToolStripPanelVisible = false;
            this.tscTop.Size = new System.Drawing.Size(787, 337);
            this.tscTop.TabIndex = 2;
            this.tscTop.Text = "toolStripContainer1";
            // 
            // tscTop.TopToolStripPanel
            // 
            this.tscTop.TopToolStripPanel.Controls.Add(this.tsPrincipal);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNuevo,
            this.tsEditar,
            this.tsBorrar});
            this.tsPrincipal.Location = new System.Drawing.Point(3, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(81, 25);
            this.tsPrincipal.TabIndex = 0;
            // 
            // tsNuevo
            // 
            this.tsNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNuevo.Image = global::UI.Desktop.Properties.Resources.add_icon_icons_com_52393;
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEditar.Image = global::UI.Desktop.Properties.Resources.edit_validated_40458;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(23, 22);
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsBorrar
            // 
            this.tsBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBorrar.Image = global::UI.Desktop.Properties.Resources.eliminar_cancelar_icono_4935_128;
            this.tsBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBorrar.Name = "tsBorrar";
            this.tsBorrar.Size = new System.Drawing.Size(23, 22);
            this.tsBorrar.Click += new System.EventHandler(this.tsBorrar_Click);
            // 
            // InscripcionAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 337);
            this.Controls.Add(this.tscTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "InscripcionAlumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripciones a cursos";
            this.Load += new System.EventHandler(this.InscripcionAlumnos_Load);
            this.tlinsCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsCursos)).EndInit();
            this.tscTop.ContentPanel.ResumeLayout(false);
            this.tscTop.TopToolStripPanel.ResumeLayout(false);
            this.tscTop.TopToolStripPanel.PerformLayout();
            this.tscTop.ResumeLayout(false);
            this.tscTop.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlinsCursos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStripContainer tscTop;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsNuevo;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private System.Windows.Forms.ToolStripButton tsBorrar;
        private System.Windows.Forms.DataGridView dgvInsCursos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;

    }
}
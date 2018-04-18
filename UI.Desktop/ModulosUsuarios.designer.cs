namespace UI.Desktop
{
    partial class ModulosUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModuloUsuario = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PermitirAlta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PermitirBaja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PermitirConsulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PermitirModificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsUsuario = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModuloUsuario)).BeginInit();
            this.tsUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(819, 347);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(819, 372);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsUsuario);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvModuloUsuario, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(819, 347);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvModuloUsuario
            // 
            this.dgvModuloUsuario.AllowUserToAddRows = false;
            this.dgvModuloUsuario.AllowUserToDeleteRows = false;
            this.dgvModuloUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModuloUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.IDModulo,
            this.IDP,
            this.PermitirAlta,
            this.PermitirBaja,
            this.PermitirConsulta,
            this.PermitirModificacion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvModuloUsuario, 2);
            this.dgvModuloUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModuloUsuario.Location = new System.Drawing.Point(3, 3);
            this.dgvModuloUsuario.MultiSelect = false;
            this.dgvModuloUsuario.Name = "dgvModuloUsuario";
            this.dgvModuloUsuario.ReadOnly = true;
            this.dgvModuloUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModuloUsuario.Size = new System.Drawing.Size(813, 312);
            this.dgvModuloUsuario.TabIndex = 5;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // IDModulo
            // 
            this.IDModulo.DataPropertyName = "IdModulo";
            this.IDModulo.HeaderText = "IDModulo";
            this.IDModulo.Name = "IDModulo";
            this.IDModulo.ReadOnly = true;
            // 
            // IDP
            // 
            this.IDP.DataPropertyName = "IdPersona";
            this.IDP.HeaderText = "IDPersona";
            this.IDP.Name = "IDP";
            this.IDP.ReadOnly = true;
            // 
            // PermitirAlta
            // 
            this.PermitirAlta.DataPropertyName = "PermiteAlta";
            this.PermitirAlta.HeaderText = "PermitirAlta";
            this.PermitirAlta.Name = "PermitirAlta";
            this.PermitirAlta.ReadOnly = true;
            // 
            // PermitirBaja
            // 
            this.PermitirBaja.DataPropertyName = "PermiteBaja";
            this.PermitirBaja.HeaderText = "PermitirBaja";
            this.PermitirBaja.Name = "PermitirBaja";
            this.PermitirBaja.ReadOnly = true;
            this.PermitirBaja.Width = 60;
            // 
            // PermitirConsulta
            // 
            this.PermitirConsulta.DataPropertyName = "PermiteConsulta";
            this.PermitirConsulta.HeaderText = "PermitirConsulta";
            this.PermitirConsulta.Name = "PermitirConsulta";
            this.PermitirConsulta.ReadOnly = true;
            // 
            // PermitirModificacion
            // 
            this.PermitirModificacion.DataPropertyName = "PermiteModificacion";
            this.PermitirModificacion.HeaderText = "PermitirModificacion";
            this.PermitirModificacion.Name = "PermitirModificacion";
            this.PermitirModificacion.ReadOnly = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(660, 321);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Actualizar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(741, 321);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsUsuario
            // 
            this.tsUsuario.Dock = System.Windows.Forms.DockStyle.None;
            this.tsUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsUsuario.Location = new System.Drawing.Point(6, 0);
            this.tsUsuario.Name = "tsUsuario";
            this.tsUsuario.Size = new System.Drawing.Size(81, 25);
            this.tsUsuario.TabIndex = 2;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.add_icon_icons1;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.edit_validated_40458;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.eliminar_cancelar_icono_4935_128;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // ModulosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 372);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "ModulosUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulos de Usuario";
            this.Load += new System.EventHandler(this.ModulosUsuarios_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModuloUsuario)).EndInit();
            this.tsUsuario.ResumeLayout(false);
            this.tsUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsUsuario;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridView dgvModuloUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermitirAlta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermitirBaja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermitirConsulta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermitirModificacion;
    }
}
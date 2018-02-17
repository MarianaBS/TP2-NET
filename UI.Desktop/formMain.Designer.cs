namespace UI.Desktop
{
    partial class formMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivoDesconectarse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerCursosDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerInsalum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerPermisosuser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerMisCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerMiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportesCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.mnuVer,
            this.mnuReportes});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(725, 24);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivoDesconectarse,
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuArchivoDesconectarse
            // 
            this.mnuArchivoDesconectarse.Name = "mnuArchivoDesconectarse";
            this.mnuArchivoDesconectarse.Size = new System.Drawing.Size(142, 22);
            this.mnuArchivoDesconectarse.Text = "Cerrar sesión";
            this.mnuArchivoDesconectarse.Click += new System.EventHandler(this.mnuArchivoDesconectarse_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(142, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click_1);
            // 
            // mnuVer
            // 
            this.mnuVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerPersonas,
            this.mnuVerUsuarios,
            this.mnuVerPlanes,
            this.mnuVerEspecialidades,
            this.mnuVerComisiones,
            this.mnuVerMaterias,
            this.mnuVerCursos,
            this.mnuVerCursosDoc,
            this.mnuVerInsalum,
            this.mnuVerModulos,
            this.mnuVerPermisosuser,
            this.mnuVerMisCursos,
            this.mnuVerMiInfo});
            this.mnuVer.Name = "mnuVer";
            this.mnuVer.Size = new System.Drawing.Size(65, 20);
            this.mnuVer.Text = "Principal";
            // 
            // mnuVerPersonas
            // 
            this.mnuVerPersonas.Name = "mnuVerPersonas";
            this.mnuVerPersonas.Size = new System.Drawing.Size(185, 22);
            this.mnuVerPersonas.Text = "Personas";
            this.mnuVerPersonas.Click += new System.EventHandler(this.mnuVerPersonas_Click);
            // 
            // mnuVerUsuarios
            // 
            this.mnuVerUsuarios.Name = "mnuVerUsuarios";
            this.mnuVerUsuarios.Size = new System.Drawing.Size(185, 22);
            this.mnuVerUsuarios.Text = "Usuarios";
            this.mnuVerUsuarios.Click += new System.EventHandler(this.mnuVerUsuarios_Click);
            // 
            // mnuVerPlanes
            // 
            this.mnuVerPlanes.Name = "mnuVerPlanes";
            this.mnuVerPlanes.Size = new System.Drawing.Size(185, 22);
            this.mnuVerPlanes.Text = "Planes";
            this.mnuVerPlanes.Click += new System.EventHandler(this.mnuVerPlanes_Click);
            // 
            // mnuVerEspecialidades
            // 
            this.mnuVerEspecialidades.Name = "mnuVerEspecialidades";
            this.mnuVerEspecialidades.Size = new System.Drawing.Size(185, 22);
            this.mnuVerEspecialidades.Text = "Especialidades";
            this.mnuVerEspecialidades.Click += new System.EventHandler(this.mnuVerEspecialidades_Click);
            // 
            // mnuVerComisiones
            // 
            this.mnuVerComisiones.Name = "mnuVerComisiones";
            this.mnuVerComisiones.Size = new System.Drawing.Size(185, 22);
            this.mnuVerComisiones.Text = "Comisiones";
            this.mnuVerComisiones.Click += new System.EventHandler(this.mnuVerComisiones_Click);
            // 
            // mnuVerMaterias
            // 
            this.mnuVerMaterias.Name = "mnuVerMaterias";
            this.mnuVerMaterias.Size = new System.Drawing.Size(185, 22);
            this.mnuVerMaterias.Text = "Materias";
            this.mnuVerMaterias.Click += new System.EventHandler(this.mnuVerMaterias_Click);
            // 
            // mnuVerCursos
            // 
            this.mnuVerCursos.Name = "mnuVerCursos";
            this.mnuVerCursos.Size = new System.Drawing.Size(185, 22);
            this.mnuVerCursos.Text = "Cursos";
            this.mnuVerCursos.Click += new System.EventHandler(this.mnuVerCursos_Click);
            // 
            // mnuVerCursosDoc
            // 
            this.mnuVerCursosDoc.Name = "mnuVerCursosDoc";
            this.mnuVerCursosDoc.Size = new System.Drawing.Size(185, 22);
            this.mnuVerCursosDoc.Text = "Docentes cursos";
            this.mnuVerCursosDoc.Click += new System.EventHandler(this.mnuVerCursosDoc_Click);
            // 
            // mnuVerInsalum
            // 
            this.mnuVerInsalum.Name = "mnuVerInsalum";
            this.mnuVerInsalum.Size = new System.Drawing.Size(185, 22);
            this.mnuVerInsalum.Text = "Inscripción a cursos";
            this.mnuVerInsalum.Click += new System.EventHandler(this.mnuVerInsalum_Click);
            // 
            // mnuVerModulos
            // 
            this.mnuVerModulos.Name = "mnuVerModulos";
            this.mnuVerModulos.Size = new System.Drawing.Size(185, 22);
            this.mnuVerModulos.Text = "Módulos";
            this.mnuVerModulos.Click += new System.EventHandler(this.mnuVerModulos_Click);
            // 
            // mnuVerPermisosuser
            // 
            this.mnuVerPermisosuser.Name = "mnuVerPermisosuser";
            this.mnuVerPermisosuser.Size = new System.Drawing.Size(185, 22);
            this.mnuVerPermisosuser.Text = "Permisos de usuarios";
            this.mnuVerPermisosuser.Click += new System.EventHandler(this.mnuVerPermisosuser_Click);
            // 
            // mnuVerMisCursos
            // 
            this.mnuVerMisCursos.Name = "mnuVerMisCursos";
            this.mnuVerMisCursos.Size = new System.Drawing.Size(185, 22);
            this.mnuVerMisCursos.Text = "Mis Cursos";
            this.mnuVerMisCursos.Click += new System.EventHandler(this.mnuVerMisCursos_Click);
            // 
            // mnuVerMiInfo
            // 
            this.mnuVerMiInfo.Name = "mnuVerMiInfo";
            this.mnuVerMiInfo.Size = new System.Drawing.Size(185, 22);
            this.mnuVerMiInfo.Text = "Datos Personales";
            this.mnuVerMiInfo.Click += new System.EventHandler(this.mnuVerMiInfo_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportesCursos});
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(65, 20);
            this.mnuReportes.Text = "Reportes";
            // 
            // mnuReportesCursos
            // 
            this.mnuReportesCursos.Name = "mnuReportesCursos";
            this.mnuReportesCursos.Size = new System.Drawing.Size(154, 22);
            this.mnuReportesCursos.Text = "Reporte Cursos";
            this.mnuReportesCursos.Click += new System.EventHandler(this.mnuReportesCursos_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::UI.Desktop.Properties.Resources._167984;
            this.ClientSize = new System.Drawing.Size(725, 408);
            this.Controls.Add(this.mnsPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Name = "formMain";
            this.Text = "Sistema de Gestión Académica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuVer;
        private System.Windows.Forms.ToolStripMenuItem mnuVerInsalum;
        private System.Windows.Forms.ToolStripMenuItem mnuVerComisiones;
        private System.Windows.Forms.ToolStripMenuItem mnuVerCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuVerCursosDoc;
        private System.Windows.Forms.ToolStripMenuItem mnuVerEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuVerMaterias;
        private System.Windows.Forms.ToolStripMenuItem mnuVerPermisosuser;
        private System.Windows.Forms.ToolStripMenuItem mnuVerPersonas;
        private System.Windows.Forms.ToolStripMenuItem mnuVerUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuVerPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuVerModulos;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuVerMisCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuVerMiInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuReportesCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivoDesconectarse;
    }
}
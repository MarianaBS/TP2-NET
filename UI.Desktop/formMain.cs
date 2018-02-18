using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMain : ApplicationForm
    {
        public formMain()
        {
            InitializeComponent();
        }

        //Eventos del formulario
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            this.visible(false);

            if (appLogin.ShowDialog() == DialogResult.OK)
            {
                modificarMenues();   
            }
        }
        
        private void visible(bool enable)
        {
            //Inicio
            mnuVerComisiones.Visible = enable;
            mnuVerCursos.Visible = enable;
            mnuVerEspecialidades.Visible = enable;
            mnuVerInsalum.Visible = enable;
            mnuVerMaterias.Visible = enable;
            mnuVerModulos.Visible = enable;
            mnuVerPermisosuser.Visible = enable;
            mnuVerPersonas.Visible = enable;
            mnuVerPlanes.Visible = enable;
            mnuVerCursosDoc.Visible = enable;
            mnuVerUsuarios.Visible = enable;                
            
        }
        private void visibleDocente(bool enable)
        {
            mnuVerMisCursos.Visible = enable;
            
            mnuVerCursosDoc.Visible = enable;
            //Habilitar cosas del Docente
        }
        private void visibleAlumno(bool enable)
        {
            
            mnuVerInsalum.Visible = enable;
            //Habilitar cosas del alumno 
        }
        private void modificarMenues()
        {
            if (TipoUsuario == 0)
            {
                this.visibleDocente(true);
            }
            else if (TipoUsuario == 1)
            {
                this.visibleAlumno(true);
            }
            else if (TipoUsuario == 2)
            {
                this.visible(true);
            }
        }


        //Eventos clicks en menues
        private void mnuVerPersonas_Click(object sender, EventArgs e)
        {
            Personas per = new Personas();
            per.ShowDialog();
        }
        private void mnuVerUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.ShowDialog();
        }
        private void mnuVerModulos_Click(object sender, EventArgs e)
        {
            Modulos mod = new Modulos();
            mod.ShowDialog();
        }
        private void mnuVerPermisosuser_Click(object sender, EventArgs e)
        {
            ModulosUsuarios mus = new ModulosUsuarios();
            mus.ShowDialog();
        }
        private void mnuVerPlanes_Click(object sender, EventArgs e)
        {
            Planes pl = new Planes();
            pl.ShowDialog();
        }
        private void mnuVerEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades();
            esp.ShowDialog();
        }
        private void mnuVerComisiones_Click(object sender, EventArgs e)
        {
            Comisiones c = new Comisiones();
            c.ShowDialog();
        }
        private void mnuVerMaterias_Click(object sender, EventArgs e)
        {
            UI.Desktop.Materia mat = new Materia();
            mat.ShowDialog();
        }
        private void mnuVerCursos_Click(object sender, EventArgs e)
        {
            UI.Desktop.formCursos cur = new formCursos();
            cur.ShowDialog();
        }
        private void mnuVerCursosDoc_Click(object sender, EventArgs e)
        {
            DocenteCurso dc = new DocenteCurso();
            dc.ShowDialog();
        }
        private void mnuVerInsalum_Click(object sender, EventArgs e)
        {
            InscripcionAlumnos ina = new InscripcionAlumnos();
            ina.ShowDialog();
        }

       
        private void mnuVerMisCursos_Click(object sender, EventArgs e)
        {
            MisCursos cur = new MisCursos();
            cur.ShowDialog();
        }

        private void mnuReportesCursos_Click(object sender, EventArgs e)
        {

            formRCursos reporteCurso = new formRCursos();
            reporteCurso.ShowDialog();
        }

        private void mnuSalir_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mnuArchivoDesconectarse_Click(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            this.visible(false);
            if (appLogin.ShowDialog() == DialogResult.OK)
            {
                modificarMenues();
            }
        }

        private void mnuVerMiInfo_Click(object sender, EventArgs e)
        {

        }

       

    }
}

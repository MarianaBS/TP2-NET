using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class MisCursos : ApplicationForm
    {
        public MisCursos()
        {
            InitializeComponent();
        }

        private void cbxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> ais = new List<AlumnoInscripcion>();
            ais = ail.GetAll();

            List<Persona> Personas = new List<Persona>();
            PersonaLogic pl = new PersonaLogic();
            Persona p = new Persona();
            
            int IDCurso = Convert.ToInt32(cbxCursos.SelectedItem);
            foreach (AlumnoInscripcion alumI in ais)
            {
                if (IDCurso == alumI.IDCurso)
                {
                    p = pl.GetOne(alumI.IDAlumno);
                    Personas.Add(p);
                }
            }
            this.dgvAlumnos.DataSource = Personas;
            
        }

        private void MisCursos_Load(object sender, EventArgs e)
        {
            this.txtApyNom.Text = InfoUsuario;

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<Business.Entities.DocenteCurso> dcs = new List<Business.Entities.DocenteCurso>();
            dcs = dcl.GetAll();
            foreach (Business.Entities.DocenteCurso dc in dcs)
	        {
                if (dc.IDDocente == IDPersona)
                {
                   this.cbxCursos.Items.Add(dc.IDCurso.ToString());
                }
	        }
            dgvAlumnos.AutoGenerateColumns = false;
        }


    }
}

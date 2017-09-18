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
    public partial class InscripcionAlumnos : ApplicationForm
    {
        public InscripcionAlumnos()
        {
            InitializeComponent();
        }
        private void InscripcionAlumnos_Load(object sender, EventArgs e)
        {
            dgvInsCursos.AutoGenerateColumns = false;
            this.Listar();
        }
        private void Listar()
        {
            List<AlumnoInscripcion> ia = new List<AlumnoInscripcion>();
            List<AlumnoInscripcion> ia1 = new List<AlumnoInscripcion>();
            AlumnoInscripcionLogic ial = new AlumnoInscripcionLogic();
            ia = ial.GetAll();
            foreach (AlumnoInscripcion aluI in ia)
            {
                if (aluI.IDAlumno == IDPersona)
                {
                    ia1.Add(aluI);
                }
            }
            this.dgvInsCursos.DataSource = ia1;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void tsNuevo_Click(object sender, EventArgs e)
        {
            IADesktop formInscripcion = new IADesktop(ApplicationForm.ModoForm.Alta);
            formInscripcion.ShowDialog();
            this.Listar();
        }
        private void tsEditar_Click(object sender, EventArgs e)
        {
            int ID = ((AlumnoInscripcion)this.dgvInsCursos.SelectedRows[0].DataBoundItem).ID;
            IADesktop formInscripcion = new IADesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formInscripcion.ShowDialog();
            this.Listar();
        }
        private void tsBorrar_Click(object sender, EventArgs e)
        {
            int ID = ((AlumnoInscripcion)this.dgvInsCursos.SelectedRows[0].DataBoundItem).ID;
            IADesktop formInscripcion = new IADesktop(ID, ApplicationForm.ModoForm.Baja);
            formInscripcion.ShowDialog();
            this.Listar();
        }
    }
}

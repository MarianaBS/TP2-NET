using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class DocenteCurso : ApplicationForm
    {
        public DocenteCurso()
        {
            InitializeComponent();
        }

        private void DocenteCurso_Load(object sender, EventArgs e)
        {
            dgvDocCursos.AutoGenerateColumns = false;
            this.Listar();
        }
        private void Listar()
        {
            List<Business.Entities.DocenteCurso> dc = new List<Business.Entities.DocenteCurso>();
            List<Business.Entities.DocenteCurso> dc1i = new List<Business.Entities.DocenteCurso>();
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            dc = dcl.GetAll();
            foreach (Business.Entities.DocenteCurso dcu in dc)
            {
                if (dcu.IDDocente == IDPersona)
                {
                    dc1i.Add(dcu);
                }
            }
            this.dgvDocCursos.DataSource = dc1i;
        }
               

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsNuevo_Click_1(object sender, EventArgs e)
        {
            DocenteCursoDesktop formInscripcion = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formInscripcion.ShowDialog();
            this.Listar();
        }

        private void tsEditar_Click_1(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDocCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formInscripcion = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formInscripcion.ShowDialog();
            this.Listar();

        }

        private void tsBorrar_Click_1(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDocCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formInscripcion = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            formInscripcion.ShowDialog();
            this.Listar();

        }

       

        
    }
}


       
    


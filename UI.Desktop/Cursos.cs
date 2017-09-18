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
    public partial class formCursos : ApplicationForm
    {
         #region Constructor
        public formCursos()
        {
            InitializeComponent();
        }
        
        #endregion 
  
        #region Metodos
        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvCursos.DataSource = cl.GetAll();
        }      
        #endregion
        
        #region Eventos
                private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop formCursos = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            formCursos.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
             CursosDesktop formCursos = new CursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
             formCursos.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop formCursos = new CursosDesktop(ID, ApplicationForm.ModoForm.Baja);
            formCursos.ShowDialog();
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
             this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
             Listar();
        }

        #endregion



    }

}

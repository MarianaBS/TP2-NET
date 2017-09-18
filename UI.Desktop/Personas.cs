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
    public partial class Personas : ApplicationForm
    {
        
        #region Constructor

        public Personas()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();
            this.dgvPersona.AutoGenerateColumns = false;
            this.dgvPersona.DataSource = ul.GetAll();
        }
        #endregion

        #region Eventos

        private void dgvPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonasDesktop formPersona = new PersonasDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersona.SelectedRows[0].DataBoundItem).ID;
            PersonasDesktop formPersona = new PersonasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersona.SelectedRows[0].DataBoundItem).ID;
            PersonasDesktop formPersona = new PersonasDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();

        }

        #endregion
    }
}

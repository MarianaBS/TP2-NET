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
    public partial class Planes : ApplicationForm
        
    {

        #region Constructor
        public Planes()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlan.AutoGenerateColumns = false;
            this.dgvPlan.DataSource = pl.GetAll();

        }      
        #endregion

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Plan)this.dgvPlan.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Plan)this.dgvPlan.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
             Listar();
        }

        #endregion
    }
}

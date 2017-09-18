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
    public partial class Modulos : ApplicationForm
    {
        #region Constructor
        public Modulos()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            ModuloLogic ml = new ModuloLogic();
            this.dgvModulos.AutoGenerateColumns = false;
            this.dgvModulos.DataSource = ml.GetAll();
        }
        #endregion

        #region Eventos

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            ModulosDesktop formmd = new ModulosDesktop(ApplicationForm.ModoForm.Alta);
            formmd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
            ModulosDesktop formmd = new ModulosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formmd.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
            ModulosDesktop formmd = new ModulosDesktop(ID, ApplicationForm.ModoForm.Baja);
            formmd.ShowDialog();
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

        private void Modulos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        #endregion
    }
}

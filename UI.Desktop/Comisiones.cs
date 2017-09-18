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
    public partial class Comisiones : ApplicationForm
    {
        #region Constructor

        public Comisiones()
        {
            InitializeComponent();
        }
        #endregion 

        #region Metodos
        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComision.AutoGenerateColumns = false;
            this.dgvComision.DataSource = cl.GetAll();

        }
        #endregion




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formCo = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formCo.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Comision)this.dgvComision.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formc = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formc.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Comision)this.dgvComision .SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formco = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
            formco.ShowDialog();
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

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}

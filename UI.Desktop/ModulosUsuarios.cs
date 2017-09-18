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
    public partial class ModulosUsuarios : ApplicationForm
    {
        #region Constructor
        public ModulosUsuarios()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            MuLogic mul = new MuLogic();
            this.dgvModuloUsuario.AutoGenerateColumns = false;
            this.dgvModuloUsuario.DataSource = mul.GetAll();

        }      
        #endregion

         #region Eventos

        private void ModulosUsuarios_Load(object sender, EventArgs e)
        {
             Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {    
           
            MUDesktop formMU = new MUDesktop(ApplicationForm.ModoForm.Alta);
            formMU.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((ModuloUsuario)this.dgvModuloUsuario.SelectedRows[0].DataBoundItem).ID;
            MUDesktop formMU = new MUDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMU.ShowDialog();
            this.Listar();

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((ModuloUsuario)this.dgvModuloUsuario.SelectedRows[0].DataBoundItem).ID;
            MUDesktop formMU = new MUDesktop(ID, ApplicationForm.ModoForm.Baja);
            formMU.ShowDialog();
            this.Listar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
             this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
             this.Close();
        }

         #endregion
    }
}

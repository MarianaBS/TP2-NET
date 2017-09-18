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
    public partial class Materia : ApplicationForm
    {
        #region Constructor
        public Materia()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();
            this.dgvMateria.AutoGenerateColumns = false;
            this.dgvMateria.DataSource = ul.GetAll();
        }
        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMateria.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMateria.ShowDialog();
            this.Listar();


        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMateria.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
            this.Listar();

        }

        private void Materia_Load(object sender, EventArgs e)
        {
            Listar();
        }

        #endregion


























    }
}

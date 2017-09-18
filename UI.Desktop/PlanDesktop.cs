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
using Util;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
       #region Constructor
        public PlanDesktop()
        {
            InitializeComponent();
        }
        
        private Plan _planActual;
        public Plan PlanActual
        {
            get { return _planActual; }
            set { _planActual = value; }
        }
    
        public PlanDesktop(ModoForm modo): this()
        {
            Modo = modo;   
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public PlanDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            PlanActual = new PlanLogic().GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Metodos

        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            List<Especialidad> Especialidades = new List<Especialidad>();
            EspecialidadLogic pl = new EspecialidadLogic();
            Especialidades = pl.GetAll();
            foreach (Especialidad v in Especialidades)
            {
                this.cbxIdEspecialidad.Items.Add(v.ID.ToString());
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.cbxIdEspecialidad.SelectedItem =this.PlanActual.IDEspecialidad.ToString();          
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.State = Plan.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.PlanActual.Descripcion = this.txtDescripcion.Text.Trim();
                this.PlanActual.IDEspecialidad = Convert.ToInt32(this.cbxIdEspecialidad.SelectedItem);

            }
            if (Modo == ModoForm.Modificacion)
            {
                this.PlanActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                PlanActual.State = Plan.States.Modified;

            }
            if (Modo == ModoForm.Consulta)
            {
                PlanActual.State = Plan.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                PlanActual.State = Plan.States.Deleted;
            }

        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new PlanLogic().Save(PlanActual);
        }

        public new void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion 

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion
       
    }
}

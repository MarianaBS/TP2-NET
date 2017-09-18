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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        #region Constructor
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }
        private Especialidad _especialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }
        }
    
        public EspecialidadesDesktop(ModoForm modo): this()
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

        public EspecialidadesDesktop(int ID, ModoForm modo): this()
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
            EspecialidadActual = new EspecialidadLogic().GetOne(ID);
            MapearDeDatos();
        }
        #endregion
        #region Metodos
       
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
        }
        public override void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
                EspecialidadActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                EspecialidadActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                EspecialidadActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = Usuario.States.Deleted;
            }
            
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            new EspecialidadLogic().Save(EspecialidadActual);
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

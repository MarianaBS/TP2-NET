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
    public partial class ModulosDesktop : ApplicationForm
    {
       #region Constructor
        public ModulosDesktop()
        {
            InitializeComponent();
        }
        
        private Modulo _moduloActual;
        public Modulo ModuloActual
        {
            get { return _moduloActual; }
            set { _moduloActual = value; }
        }
   
        public  ModulosDesktop(ModoForm modo): this()
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

        public ModulosDesktop(int ID, ModoForm modo)  : this()
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
            ModuloActual = new ModuloLogic().GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Metodos

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloActual.ID.ToString();
            this.txtDescripcion.Text = this.ModuloActual.Descripcion.ToString();
            this.txtEjecuta.Text = this.ModuloActual.Ejecuta.ToString();

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ModuloActual = new Modulo();
                ModuloActual.State = Modulo.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.ModuloActual.Descripcion = this.txtDescripcion.Text.Trim();
                this.ModuloActual.Ejecuta = this.txtEjecuta.Text.Trim();

            }
            if (Modo == ModoForm.Modificacion)
            {
                this.ModuloActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                ModuloActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                ModuloActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                ModuloActual.State = Usuario.States.Deleted;
            }

        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new ModuloLogic().Save(ModuloActual);
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

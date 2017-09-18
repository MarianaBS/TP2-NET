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
    public partial class MUDesktop : ApplicationForm
    {
        #region Constructor
        private ModuloUsuario _moduloActual;
        public ModuloUsuario ModulouActual
        {
            get { return _moduloActual; }
            set { _moduloActual = value; }
        }

    
        public MUDesktop(ModoForm modo): this()
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

        public MUDesktop(int ID, ModoForm modo) : this()
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
            ModulouActual = new MuLogic().GetOne(ID);
            MapearDeDatos();
        }
    
        public MUDesktop()
        {
            InitializeComponent();
        }

   #endregion

        #region Metodos

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModulouActual.ID.ToString();
            this.cbxModulo.SelectedValue = this.ModulouActual.IdModulo;
            this.cbxUsuario.SelectedValue = this.ModulouActual.IdUsuario;
            this.chbPAlta.Checked = this.ModulouActual.PermiteAlta;
            this.chbPBaja.Checked = this.ModulouActual.PermiteBaja;
            this.chbPConsulta.Checked = this.ModulouActual.PermiteConsulta;
            this.chbPModificacion.Checked = this.ModulouActual.PermiteModificacion;

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ModulouActual = new ModuloUsuario();
                ModulouActual.State = ModuloUsuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.ModulouActual.IdModulo = Convert.ToInt32(this.cbxModulo.SelectedValue);
                this.ModulouActual.IdUsuario = Convert.ToInt32(this.cbxUsuario.SelectedValue);
                this.ModulouActual.PermiteAlta = this.chbPAlta.Checked;
                this.ModulouActual.PermiteBaja = this.chbPBaja.Checked;
                this.ModulouActual.PermiteConsulta = this.chbPConsulta.Checked;
                this.ModulouActual.PermiteModificacion = this.chbPModificacion.Checked;
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.ModulouActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                ModulouActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                ModulouActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                ModulouActual.State = Usuario.States.Deleted;
            }

        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new MuLogic().Save(ModulouActual);
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

        private void MUDesktop_Load(object sender, EventArgs e)
        {
            cbxUsuario.DisplayMember = "Apellido";
            cbxUsuario.ValueMember = "ID";
            cbxUsuario.DataSource = new UsuarioLogic().GetAll();

            cbxModulo.DisplayMember = "Descripcion";
            cbxModulo.ValueMember = "ID";
            cbxModulo.DataSource = new ModuloLogic().GetAll();
        }
    
    }
}

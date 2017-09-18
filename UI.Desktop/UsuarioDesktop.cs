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
    public partial class UsuarioDesktop : ApplicationForm
    {
        #region Constructor
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        public UsuarioDesktop()
        {
            InitializeComponent();
        }    
    
        public UsuarioDesktop(ModoForm modo): this()
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
        public UsuarioDesktop(int ID, ModoForm modo): this()
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
            UsuarioActual = new UsuarioLogic().GetOne(ID);
            MapearDeDatos();
        }
        #endregion
        #region Metodos
       
        public override void MapearDeDatos()
        {   
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtClave.Text = this.UsuarioActual.Clave;      
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.cbxIdPersona.SelectedValue = UsuarioActual.ID; //falta modificar está sentencia
            //provamos pero no tuvimos exito 
        }

        public override void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Nombre = this.txtNombre.Text.Trim();
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Email = this.txtEmail.Text.Trim();
                this.UsuarioActual.Clave = this.txtClave.Text.Trim();
                this.UsuarioActual.Apellido = this.txtApellido.Text.Trim();
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text.Trim();
                this.UsuarioActual.Clave = this.txtConfirmarClave.Text.Trim();
                this.UsuarioActual.IDPersona = Convert.ToInt32(this.cbxIdPersona.SelectedValue);
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                UsuarioActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                UsuarioActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = Usuario.States.Deleted;
            }
            
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            new UsuarioLogic().Save(UsuarioActual);
        }
        public override bool Validar() 
        {
            bool valida = false;
            RegexUtilities util = new RegexUtilities();

            string mensaje = "";
            if (txtApellido.Text.Trim() == "")
                mensaje += "El apellido no puede estar en blanco." + "\n";
            if (txtNombre.Text.Trim() == "")
                mensaje += "El nombre no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                mensaje += "El usuario no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                mensaje += "El email no puede estar en blanco." + "\n";
            if (!util.validarMail(txtEmail.Text))
                mensaje += "El mail no tiene el formato correcto" + "\n";
            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
                mensaje += "La clave no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()))
                mensaje += "El repetir clave no puede estar en blanco." + "\n";
            if (txtConfirmarClave.Text.Trim() != txtClave.Text.Trim())
                mensaje += "Las claves no coinciden." + "\n";
            if (txtClave.Text.Length < 8)
                mensaje += "La clave debe contener al menos 8 caracteres." + "\n";
            
            if (!string.IsNullOrEmpty(mensaje))
            {
                this.Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valida = true;
            }

            return valida; 
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
            if (Modo != ModoForm.Baja)
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else 
            {
                this.GuardarCambios();
            }    
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            cbxIdPersona.DisplayMember = "ApyNom";
            cbxIdPersona.ValueMember = "ID";
            cbxIdPersona.DataSource = new PersonaLogic().GetAll();
        }
        private void cbxIdPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxIdPersona.SelectedIndex != -1)
            {
                Persona pers = new Persona();
                pers = (Persona)cbxIdPersona.SelectedItem;
                this.txtApellido.Text = pers.Apellido.ToString();
                this.txtNombre.Text = pers.Nombre.ToString();
                this.txtEmail.Text = pers.Email.ToString();
            }
        }
    }
}

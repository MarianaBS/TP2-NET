using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PersonasDesktop : ApplicationForm
    {
        #region Constructor
        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }
        public PersonasDesktop()
        {
            InitializeComponent();
        }
        public PersonasDesktop(ModoForm modo) : this()
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
        public PersonasDesktop(int ID, ModoForm modo) : this()
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
            PersonaActual = new PersonaLogic().GetOne(ID);
            MapearDeDatos();
        }

        #endregion


        #region Metodos
        private void PersonasDesktop_Load(object sender, EventArgs e)
        {
            //cbxTipoPersona.Items.Add(Persona.TiposPersonas.Administrador);
            //cbxTipoPersona.Items.Add(Persona.TiposPersonas.Alumno);
            //cbxTipoPersona.Items.Add(Persona.TiposPersonas.Docente);
            cbxTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TiposPersonas));
            cbxPlan.DisplayMember = "Descripcion";
            cbxPlan.ValueMember = "ID";
            cbxPlan.DataSource = new PlanLogic().GetAll();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion.ToString();
            this.txtEmail.Text = this.PersonaActual.Email.ToString();
            this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.cbxPlan.SelectedItem = this.PersonaActual.IdPlan;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono.ToString();
            this.cbxTipoPersona.SelectedItem = Convert.ToInt32(this.PersonaActual.TipoPersona); 
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
               PersonaActual = new Persona();
                PersonaActual.State = Persona.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.PersonaActual.Apellido = this.txtApellido.Text.Trim();
                this.PersonaActual.Direccion = this.txtDireccion.Text.Trim();
                this.PersonaActual.Email = this.txtEmail.Text.Trim();
                this.PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text.Trim());
                this.PersonaActual.IdPlan = Convert.ToInt32(this.cbxPlan.SelectedValue);
                this.PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());
                this.PersonaActual.Nombre = this.txtNombre.Text.Trim();
                this.PersonaActual.Telefono = this.txtTelefono.Text.Trim();
                this.PersonaActual.TipoPersona = (Business.Entities.Persona.TiposPersonas)(this.cbxTipoPersona.SelectedItem) ;
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.PersonaActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                PersonaActual.State = Persona.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                PersonaActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                PersonaActual.State = Usuario.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            new PersonaLogic().Save(PersonaActual);
        }
       /* public override bool Validar()
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
        }*/

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

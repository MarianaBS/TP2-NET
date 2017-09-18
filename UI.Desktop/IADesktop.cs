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
    public partial class IADesktop : ApplicationForm
    {
        #region Constructor
        public IADesktop()
        {
            InitializeComponent();
        }
        private AlumnoInscripcion _aiActual;
        public AlumnoInscripcion IAActual
        {
            get { return _aiActual; }
            set { _aiActual = value; }
        }
        public IADesktop(ModoForm modo): this()
        {
            Modo = modo;   
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtIDAlumno.Text = IDPersona.ToString();
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
        public IADesktop(int ID, ModoForm modo): this()
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
            IAActual = new AlumnoInscripcionLogic().GetOne(ID);
            MapearDeDatos();
        }
        #endregion


        #region Metodos

        public override void MapearDeDatos()
        {
            this.txtIDAlumno.Text = this.IAActual.IDAlumno.ToString();
            this.txtIDInscripcion.Text = this.IAActual.ID.ToString();
            this.cbxIAs.SelectedValue= IAActual.IDCurso;
            this.txtNota.Text = IAActual.Nota.ToString();
            this.txtCondicion.Text = IAActual.Condicion.ToString();
            
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                IAActual= new AlumnoInscripcion();
                IAActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                IAActual.IDAlumno = IDPersona;
                IAActual.IDCurso = Convert.ToInt32(cbxIAs.SelectedValue);
                IAActual.Nota = Convert.ToInt32(this.txtNota.Text);
                IAActual.Condicion = this.txtCondicion.Text.ToString();
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.IAActual.ID = Convert.ToInt32(this.txtIDInscripcion.Text.Trim());
                IAActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
               IAActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
               IAActual.State = Usuario.States.Deleted;
            }

        }
        public override void GuardarCambios()
        {
           MapearADatos();
           new AlumnoInscripcionLogic().Save(IAActual);
        }
        public override bool Validar()
        {
            bool valida = false;
           /* RegexUtilities util = new RegexUtilities();

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
            */
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

        private void IADesktop_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            cbxIAs.DisplayMember = "ID";
            cbxIAs.ValueMember = "ID";
            cbxIAs.DataSource = new CursoLogic().GetAll();
        }
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

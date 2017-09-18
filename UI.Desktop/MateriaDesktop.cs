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
    public partial class MateriaDesktop : ApplicationForm
    {

        #region Constructor
        private Business.Entities.Materia _materiaActual;
        public Business.Entities.Materia MateriaActual
        {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        public MateriaDesktop(ModoForm modo)
            : this()
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
        public MateriaDesktop(int ID, ModoForm modo)
            : this()
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
            MateriaActual = new MateriaLogic().GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Metodos

        public override void MapearDeDatos()
        {
            this.txtID.Text = MateriaActual.ID.ToString();
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtHoraSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHorasTotales.Text = MateriaActual.HSTotales.ToString();
            this.cbxIdPlan.SelectedValue = MateriaActual.IdPlan;
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                MateriaActual = new Business.Entities.Materia();
                MateriaActual.State = Business.Entities.Materia.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.Descripcion = this.txtDescripcion.Text.Trim();
                this.MateriaActual.HSSemanales = Convert.ToInt32(this.txtHoraSemanales.Text.Trim());
                this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHorasTotales.Text.Trim());
                this.MateriaActual.IdPlan = Convert.ToInt32(this.cbxIdPlan.SelectedValue);
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                MateriaActual.State = Business.Entities.Materia.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                MateriaActual.State = Business.Entities.Materia.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                MateriaActual.State = Business.Entities.Materia.States.Deleted;
            }

        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new MateriaLogic().Save(MateriaActual);
        }
        /*  public override bool Validar()
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
          } */
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

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            cbxIdPlan.DisplayMember = "Descripcion";
            cbxIdPlan.ValueMember = "ID";
            cbxIdPlan.DataSource = new PlanLogic().GetAll();  
        }


    }
}

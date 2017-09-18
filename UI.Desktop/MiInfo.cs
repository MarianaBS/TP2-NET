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
    public partial class MiInfo : ApplicationForm
    {
        private Usuario _user;
        public Usuario User
        {
            get { return _user; }
            set { _user = value; }
        }

        public MiInfo()
        {
            InitializeComponent();
        }
        private void MiInfo_Load(object sender, EventArgs e)
        {
            this.gbModificar.Visible = false;
            cargarDatos(1);  
        }
        private void cargarDatos(int i)
        {
            switch (i)
            {
                case 1: 
                    User = new UsuarioLogic().GetOne(IDUsuario);
                    txtApellido.Text = User.Apellido;
                    txtEmail.Text = User.Email;
                    txtNombre.Text = User.Nombre;
                    txtUsuario.Text = User.NombreUsuario;
                    break;
                case 2: 
                    txtMApellido.Text = txtApellido.Text;
                    txtMEmail.Text = txtEmail.Text;
                    txtMNombre.Text = txtNombre.Text;
                    txtMUsuario.Text = txtUsuario.Text;
                    txtMPass.Text = string.Empty;
                    break;
                default:
                    break;
            }
        }
        private void lnkEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.gbModificar.Visible = true;
            cargarDatos(2);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            User = new UsuarioLogic().GetOne(IDUsuario);
            try
            {
                if (cbCambiaPass.Checked == true)
                {
                    if (txtMPass.Text == User.Clave)
                    {
                        User.Clave = txtMRPass.Text;
                        User.State = BusinessEntity.States.Modified;
                        new UsuarioLogic().Save(User);
                    }
                }
                else if (txtMPass.Text == string.Empty)
                {
                    MessageBox.Show("La contraseña no puede estar vacia");
                }
                else if (txtMPass.Text == User.Clave)
                {
                    User.State = BusinessEntity.States.Modified;
                    new UsuarioLogic().Save(User);
                }
                
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                cargarDatos(1);
                this.gbModificar.Visible = false;
            }    
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.gbModificar.Visible = false;
        }

        private void cbCambiaPass_Click(object sender, EventArgs e)
        {
            if (cbCambiaPass.Checked == true)
            {
                txtMRPass.Enabled = true;
            }
            else if (cbCambiaPass.Checked == false)
            {
                txtMRPass.Enabled = false;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : ABM
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               Desloguear();
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic user = new UsuarioLogic();
            try
            {
                Usuario usuario = user.GetUser(this.txtUsuario.Text, this.txtClave.Text);
                if (usuario != null)
                {
                    if (usuario.Clave == txtClave.Text.Trim())
                    {
                        if (usuario.Habilitado == true)
                        {
                            IDUsuario = usuario.ID;
                            PersonaLogic pl = new PersonaLogic();
                            Persona p = new Persona();
                            p = pl.GetOne(usuario.IDPersona);
                            if (p.TipoPersona == Persona.TiposPersonas.Administrador)
                            {
                                TipoUsuario = 2;
                            }
                            else if (p.TipoPersona == Persona.TiposPersonas.Alumno)
	                        {
                                TipoUsuario = 1;
	                        }
                            else if (p.TipoPersona == Persona.TiposPersonas.Docente)
	                        {
                                TipoUsuario = 0;
	                        }
                            NombreUsuario = usuario.Nombre + " " + usuario.Apellido;
                            Response.Redirect("/Default.aspx", false);
                        }
                        else
                        {
                            lblLogin.Text = "Usuario no habilitado. Comuníquese con un administrador.";
                        }
                    } lblLogin.Text = "Usuario y/o contraseña incorrectos";
                }             
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }

        }
        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            lblLogin.Text = "Usted es un usuario muy descuidado, haga memoria!";
            lblLogin.Visible = true;
        }
    }
}

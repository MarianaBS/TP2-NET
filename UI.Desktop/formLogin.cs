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
    public partial class formLogin : ApplicationForm
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usuario = new UsuarioLogic();
            Usuario usr = new Usuario();
            
            
            if (usuario.GetOne(this.txtUsuario.Text, this.txtPass.Text))
            {
                usr = usuario.GetUser(this.txtUsuario.Text, this.txtPass.Text);

                PersonaLogic per = new PersonaLogic();
                Persona pers = per.GetOne(usr.IDPersona);
                InfoUsuario = usr.Apellido + "," + usr.Nombre;
                IDPersona = usr.IDPersona;
                IDUsuario = usr.ID;
                if (usr.Habilitado == true)
                {
                this.DialogResult = DialogResult.OK;
               
                    if (pers.TipoPersona == Persona.TiposPersonas.Administrador)
                    {
                        TipoUsuario = 2;
                        this.Dispose();
                    }
                    else if (pers.TipoPersona == Persona.TiposPersonas.Alumno)
                    {
                        TipoUsuario = 1;
                        this.Dispose();
                    }
                    else if (pers.TipoPersona == Persona.TiposPersonas.Docente)
                    {
                        TipoUsuario = 0;
                        this.Dispose();
                    }
                    this.Dispose();
                }
            
            else {MessageBox.Show("Usuario inhabilitado. Comuníquese con el Administrador.", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);}}
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria!", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
        }

        

      
    }
}

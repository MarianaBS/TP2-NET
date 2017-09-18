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
            //se fija si existe el usuario enviando el nombre de usuario ingresado
            //y el pass, si todo sale bien se devuelve true y ingresa al sistema
            //metodo de verificacion de login desarrollado en UsuarioAdapter
            //y luego invocado desde UsuarioLogic
            Usuario usr = new Usuario();
            
            //definir login

            if (usuario.GetOne(this.txtUsuario.Text, this.txtPass.Text))
            {
                usr = usuario.GetUser(this.txtUsuario.Text,this.txtPass.Text);
                //necesito traer la persona para saber cual es su tipo
                PersonaLogic per = new PersonaLogic();
                //para eso la traemos con getone y su id que es clave foranea a usuarios
                Persona pers = per.GetOne(usr.IDPersona);
                //luego me guardo info del usuario, el id por las dudas 
                InfoUsuario = usr.Apellido + "," + usr.Nombre;
                IDPersona = usr.IDPersona;
                IDUsuario = usr.ID;
                //cambio el resultado del dialogo para mostrar que todo está bien
                this.DialogResult = DialogResult.OK;
                //por ultimo defino el tipo de persona para los menues
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
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
        }

        

      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        #region Constructor
        private ModoForm _modo;

        //Con este vamos a traer los datos cada ves que los necesitemos 
        static private int _IDUsuario;
        static public int IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        //A veces no basta con el IDUsuario, asi que guardamos el de la persona tambien
        static private int _IDPersona;
        public static int IDPersona
        {
            get { return ApplicationForm._IDPersona; }
            set { ApplicationForm._IDPersona = value; }
        }
        //El tipo de usuario va a servir para modificar los menus en tiempo de ejecucion
        static private int _TipoUsuario;
        static public int TipoUsuario
        {
            get { return _TipoUsuario; }
            set { _TipoUsuario = value; }
        }

        //El usuario está compuesto por nombre y apellido
        //Es para mostrar información durante el Log
        static private string _infoUsuario;
        static public string InfoUsuario
        {
            get { return _infoUsuario; }
            set { _infoUsuario = value; }
        }
       
        public ApplicationForm()
        {
            InitializeComponent();
        }
        public enum ModoForm
        {
            Alta ,Baja , Modificacion , Consulta
        }
        
        #endregion

        #region Metodos

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }
        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion

    }
}

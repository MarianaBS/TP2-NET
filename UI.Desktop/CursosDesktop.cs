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
    public partial class CursosDesktop : ApplicationForm
    {
        #region Constructor
        public CursosDesktop()
        {
            InitializeComponent();
        }
        private Curso _cursoActual;

        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }
    
        public CursosDesktop(ModoForm modo): this()
        {
            Modo = modo;   
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text ="Guardar";
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

        public CursosDesktop(int ID, ModoForm modo): this()
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
            CursoActual = new CursoLogic().GetOne(ID);
            MapearDeDatos();
        }
       
        #endregion
        #region Metodos
       
        public override void MapearDeDatos() 
        {
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.cbxIDComision.SelectedValue = CursoActual.IDComision;
            this.cbxIDMateria.SelectedValue = CursoActual.IDMateria;
        }
        public override void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
                CursoActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.CursoActual.IDComision = Convert.ToInt32(this.cbxIDComision.SelectedValue);
                this.CursoActual.IDMateria = Convert.ToInt32(this.cbxIDMateria.SelectedValue);
                this.CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.CursoActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                CursoActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                CursoActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                CursoActual.State = Usuario.States.Deleted;
            }
            
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            new CursoLogic().Save(CursoActual);
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

        private void CursosDesktop_Load(object sender, EventArgs e)
        {
            cbxIDMateria.DisplayMember = "ID";
            cbxIDMateria.ValueMember = "ID";
            cbxIDMateria.DataSource = new MateriaLogic().GetAll();
            cbxIDComision.DisplayMember = "ID";
            cbxIDComision.ValueMember = "ID";
            cbxIDComision.DataSource = new ComisionLogic().GetAll();
        }
        #endregion




    }
}

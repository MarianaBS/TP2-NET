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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }
        private Business.Entities.DocenteCurso _docActual;
        public Business.Entities.DocenteCurso docActual
        {
            get { return _docActual; }
            set { _docActual = value; }
        }
        public DocenteCursoDesktop(ModoForm modo): this()
        {
            Modo = modo;   
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtIDDocente.Text = IDPersona.ToString();
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
        public DocenteCursoDesktop(int ID, ModoForm modo): this()
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
            docActual = new DocenteCursoLogic().GetOne(ID);
            MapearDeDatos();
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

        private void DocenteCursoDesktop_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.docActual.ID.ToString();
            this.txtIDDocente.Text = this.docActual.IDDocente.ToString();
            this.cboCursos.SelectedValue = docActual.IDCurso;
            this.cboTipoCargo.SelectedValue = docActual.TiposCargo;

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                docActual = new Business.Entities.DocenteCurso();
                docActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                docActual.IDDocente = IDPersona;
                docActual.IDCurso = Convert.ToInt32(cboCursos.SelectedValue);
                docActual.TiposCargo = (Business.Entities.DocenteCurso.TiposCargos)(cboTipoCargo.SelectedValue);
                
            }
            if (Modo == ModoForm.Modificacion)
            {
                this.docActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                docActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                docActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                docActual.State = Usuario.States.Deleted;
            }

        }
        private void cargarDatos()
        {
            cboCursos.DisplayMember = "ID";
            cboCursos.ValueMember = "ID";
            cboCursos.DataSource = new CursoLogic().GetAll();
            cboTipoCargo.DataSource = Enum.GetValues(typeof(Business.Entities.DocenteCurso.TiposCargos));
        }
     
    }
}

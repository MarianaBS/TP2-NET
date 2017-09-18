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
    public partial class AlumnosIncripciones : ABM
    {
        #region cto

        AlumnoInscripcionLogic _Logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new AlumnoInscripcionLogic();
                }
                return _Logic;
            }
        }
        private AlumnoInscripcion Entity { get; set; }
        #endregion

        #region metodos
        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.ddlIDAlumno.Enabled = enable;
            this.ddlCurso.Enabled = enable;
            this.txtCondicion.Enabled = enable;
            this.txtNota.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.ddlCurso.SelectedValue = this.Entity.IDCurso.ToString();
            this.ddlIDAlumno.SelectedValue = this.Entity.IDAlumno.ToString();
            this.txtCondicion.Text = this.Entity.Condicion;
            this.txtNota.Text = this.Entity.Nota.ToString();
            
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.ddlCurso.SelectedIndex = -1;
            this.ddlIDAlumno.SelectedIndex = -1;
            this.txtCondicion.Text = string.Empty;
            this.txtNota.Text = string.Empty;
        }
        private void LoadEntity(AlumnoInscripcion AluIns)
        {
            AluIns.IDAlumno = Convert.ToInt32(this.ddlIDAlumno.SelectedValue);
            AluIns.IDCurso = Convert.ToInt32(this.ddlCurso.SelectedValue);
            AluIns.Nota = Convert.ToInt32(this.txtNota.Text);
            AluIns.Condicion = this.txtCondicion.Text;
        }
        private void SaveEntity(AlumnoInscripcion AluIns)
        {
            Logic.Save(AluIns);
        }
        

        #endregion

        #region eventos
        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                    PersonaLogic per = new PersonaLogic();
                    CursoLogic cur = new CursoLogic();
                    List<Curso> curs = new List<Curso>();
                    List<Persona> pers = new List<Persona>();
                    this.LoadGrid();
                    curs = cur.GetAll();
                    foreach (Curso cu in curs)
                    {
                        ddlCurso.Items.Add(cu.ID.ToString());
                    }
                    pers = per.GetAll();
                    foreach (Persona pe in pers)
                    {
                        if (pe.TipoPersona == Persona.TiposPersonas.Alumno)
                        {
                            this.ddlIDAlumno.Items.Add(pe.ID.ToString());
                        }
                    }
            }
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            EnableForm(true);
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
            this.formActionsPanel.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AlumnosIncripciones.aspx");
        }
        protected void ddlIDAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Persona pers = new Persona();
            PersonaLogic persL = new PersonaLogic();
            pers = persL.GetOne(Convert.ToInt32(ddlIDAlumno.SelectedValue));
            this.txtAlumno.Text = pers.Apellido+","+pers.Nombre;
        }
        protected void ddlIDAlumno_Load(object sender, EventArgs e)
        {
            Persona pers = new Persona();
            PersonaLogic persL = new PersonaLogic();
            pers = persL.GetOne(Convert.ToInt32(ddlIDAlumno.SelectedValue));
            this.txtAlumno.Text = pers.Apellido + "," + pers.Nombre;
        }
        #endregion

       

        
    }
}

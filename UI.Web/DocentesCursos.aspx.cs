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
    public partial class docentes_cursos : ABM
    {
        #region cto
        DocenteCursoLogic _Logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new DocenteCursoLogic();
                }
                return _Logic;
            }
        }
        private DocenteCurso Entity { get; set; }
        #endregion
        #region metodos
        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.ddlCurso.Enabled = enable;
            this.ddlDocente.Enabled = enable;
            this.ddlTipoCargo.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.ddlDocente.SelectedValue = this.Entity.IDDocente.ToString();
            this.ddlCurso.SelectedValue = this.Entity.IDCurso.ToString();
            this.ddlTipoCargo.SelectedValue= this.Entity.TiposCargo.ToString();
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.ddlDocente.SelectedIndex = -1;
            this.ddlCurso.SelectedIndex = -1;
            this.ddlTipoCargo.SelectedIndex = -1;
        }

        private void LoadEntity(DocenteCurso DC)
        {
            DC.IDCurso = Convert.ToInt32(this.ddlCurso.SelectedValue);
            DC.IDDocente = Convert.ToInt32(this.ddlDocente.SelectedValue);
            DC.TiposCargo =  (DocenteCurso.TiposCargos)Convert.ToInt32(ddlTipoCargo.SelectedIndex);
        }
        private void SaveEntity(DocenteCurso dc)
        {
            Logic.Save(dc);
        }
        #endregion
        #region eventos
        
        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();

                CursoLogic cur = new CursoLogic();
                PersonaLogic per = new PersonaLogic();
                List<Curso> curs = new List<Curso>();
                curs = cur.GetAll();
                foreach (Curso cu in curs)
                {
                    ddlCurso.Items.Add(cu.ID.ToString());
                }

                List<Persona> pers = new List<Persona>();
                pers = per.GetAll();
                foreach (Persona pe in pers)
                {
                    if (pe.TipoPersona == Persona.TiposPersonas.Docente)
                    {
                        ddlDocente.Items.Add(pe.ID.ToString());
                    }
                }

                ddlTipoCargo.Items.Add(DocenteCurso.TiposCargos.Auxiliar.ToString());
                ddlTipoCargo.Items.Add(DocenteCurso.TiposCargos.Titular.ToString());
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new DocenteCurso();
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
            Response.Redirect("~/DocentesCursos.aspx");
        }
        protected void ddlDocente_Load(object sender, EventArgs e)
        {
            Persona pers = new Persona();
            PersonaLogic persL = new PersonaLogic();
            pers = persL.GetOne(Convert.ToInt32(ddlDocente.SelectedValue));
            this.txtDocente.Text = pers.Apellido + "," + pers.Nombre;
        }
        protected void ddlDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Persona pers = new Persona();
            PersonaLogic persL = new PersonaLogic();
            pers = persL.GetOne(Convert.ToInt32(ddlDocente.SelectedValue));
            this.txtDocente.Text = pers.Apellido + "," + pers.Nombre;
        }
        #endregion
    
    }
}

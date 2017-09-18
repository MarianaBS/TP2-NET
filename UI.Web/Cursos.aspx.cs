using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Cursos : ABM
    {
        #region cto
      
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic==null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }
        private Curso Entity { get; set; }

        #endregion

        #region metodos
        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.txtAnioCalendario.Enabled = enable;
            this.txtCupo.Enabled = enable;
            this.ddlComision.Enabled = enable;
            this.ddlMateria.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtAnioCalendario.Text = this.Entity.AnioCalendario.ToString();
            this.txtCupo.Text = this.Entity.Cupo.ToString();
            this.ddlComision.SelectedValue = this.Entity.IDComision.ToString();
            this.ddlMateria.SelectedValue = this.Entity.IDMateria.ToString();
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.txtAnioCalendario.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
            this.ddlComision.SelectedIndex = -1;
            this.ddlMateria.SelectedIndex = -1;
        }
        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            curso.Cupo = Convert.ToInt32(this.txtCupo.Text);
            curso.IDComision = Convert.ToInt32(this.ddlComision.SelectedValue);
            curso.IDMateria = Convert.ToInt32(this.ddlMateria.SelectedValue);
        }
        private void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
        }
        #endregion

        #region eventos
        protected override void CargarPagina()
        {
            ComisionLogic com = new ComisionLogic();
            MateriaLogic mat = new MateriaLogic();

            if (!Page.IsPostBack)
            {
                Business.Logic.ComisionLogic cl = new ComisionLogic();
                this.LoadGrid();
                List<Comision> listacursos = new List<Comision>();
                listacursos = cl.GetAll();
                foreach (Comision comi in listacursos)
                {
                    ddlComision.Items.Add(comi.ID.ToString());
                }

                List<Materia> listaMateria = new List<Materia>();
                listaMateria = mat.GetAll();
                foreach (Materia mate in listaMateria)
                {
                    ddlMateria.Items.Add(mate.ID.ToString());
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
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new Curso();
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
            Response.Redirect("~/Cursos.aspx");
        }
        #endregion

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Materia mat = new Materia();
            MateriaLogic matL = new MateriaLogic();
            mat = matL.GetOne(Convert.ToInt32(ddlMateria.SelectedValue));
            this.txtMateria.Text = mat.Descripcion;
        }

        protected void ddlMateria_Load(object sender, EventArgs e)
        {
            Materia mat = new Materia();
            MateriaLogic matL = new MateriaLogic();
            mat = matL.GetOne(Convert.ToInt32(ddlMateria.SelectedValue));
            this.txtMateria.Text = mat.Descripcion;
        }
    }
}

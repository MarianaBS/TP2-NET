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
    public partial class Planes : ABM
    {
        #region cto

        PlanLogic _Logic;
        private PlanLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new PlanLogic();
                }
                return _Logic;
            }
        }
        private Plan Entity { get; set; }
        #endregion

        #region metodos
        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.ddlEspecialidad.SelectedValue = this.Entity.IDEspecialidad.ToString();
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.ddlEspecialidad.SelectedIndex = -1;
        }
        private void LoadEntity(Plan planes)
        {
            planes.Descripcion = this.txtDescripcion.Text;
            planes.IDEspecialidad = Convert.ToInt32(this.ddlEspecialidad.SelectedValue);
        }
        private void SaveEntity(Plan planes)
        {
            Logic.Save(planes);
        }
        #endregion

        #region eventos
        protected override void CargarPagina()
        {
            EspecialidadLogic esp = new EspecialidadLogic();
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                List<Business.Entities.Especialidad> listaespecialidades = new List<Business.Entities.Especialidad>();
                listaespecialidades = esp.GetAll();
                foreach (Business.Entities.Especialidad espe in listaespecialidades)
                {
                    ddlEspecialidad.Items.Add(espe.ID.ToString());
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Plan();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new Plan();
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
            Response.Redirect("~/Planes.aspx");
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
        #endregion
    }
}

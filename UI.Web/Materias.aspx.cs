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
    public partial class Materias : ABM
    {
        #region cto
        MateriaLogic _Logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new MateriaLogic();
                }
                return _Logic;
            }
        }
        private Business.Entities.Materia Entity { get; set; }
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
            this.txtHSSemanales.Enabled = enable;
            this.txtHSTotales.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtHSSemanales.Text = this.Entity.HSSemanales.ToString();
            this.txtHSTotales.Text = this.Entity.HSTotales.ToString();
            this.ddlPlan.SelectedValue = this.Entity.IdPlan.ToString();
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.GetOne(id);
        }
        protected override void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtHSSemanales.Text = string.Empty;
            this.txtHSTotales.Text = string.Empty;
            this.ddlPlan.SelectedIndex = -1;
        }
        private void LoadEntity(Business.Entities.Materia materia)
        {

            materia.Descripcion = this.txtDescripcion.Text;
            materia.HSSemanales = Convert.ToInt32(this.txtHSSemanales.Text);
            materia.HSTotales = Convert.ToInt32(this.txtHSTotales.Text);
            materia.IdPlan = Convert.ToInt32(this.ddlPlan.SelectedValue);

        }
        private void SaveEntity(Business.Entities.Materia materia)
        {
            Logic.Save(materia);
        }

        #endregion
        #region eventos

        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                PlanLogic pl = new PlanLogic();
                List<Plan> listaplanes = new List<Plan>();
                listaplanes = pl.GetAll();
                foreach (Plan plan in listaplanes)
                {
                    ddlPlan.Items.Add(plan.ID.ToString());
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
                    this.Entity = new Business.Entities.Materia();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new Business.Entities.Materia();
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
            Response.Redirect("~/Materias.aspx");
        }
        protected void gridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
        #endregion

       
    }
}

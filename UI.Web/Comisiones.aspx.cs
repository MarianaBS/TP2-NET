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
    public partial class Comisiones : ABM
    {
        #region cto
        ComisionLogic _Logic;
        private ComisionLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new ComisionLogic();
                }
                return _Logic;
            }
        }
        private Comision Entity { get; set; }
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
            this.txtAnioEspecialidad.Enabled = enable;
            this.ddlIDPlan.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtAnioEspecialidad.Text = this.Entity.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.ddlIDPlan.SelectedValue = this.Entity.IDPlan.ToString();
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtAnioEspecialidad.Text = string.Empty;
            this.ddlIDPlan.SelectedIndex = -1;
        }

        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = this.txtDescripcion.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
            comision.IDPlan = Convert.ToInt32(ddlIDPlan.SelectedValue); 
        }
        private void SaveEntity(Comision comision)
        {
            Logic.Save(comision);
        }
        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                this.txtDescPlan.Enabled = false;
                PlanLogic pl = new PlanLogic();
                List<Plan> listaplanes = new List<Plan>();
                listaplanes = pl.GetAll();
                foreach (Plan plan in listaplanes)
                {
                    ddlIDPlan.Items.Add(plan.ID.ToString());
                }
            }
        }
        #endregion
        #region eventos
      
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
                    this.Entity = new Comision();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new Comision();
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
            Response.Redirect("~/Comisiones.aspx");
        }
        protected void ddlIDPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlanLogic plan = new PlanLogic();
            Plan pl = new Plan();
            pl = plan.GetOne(Convert.ToInt32(this.ddlIDPlan.SelectedValue));
            this.txtDescPlan.Text = pl.Descripcion;
        }
        protected void ddlIDPlan_Load(object sender, EventArgs e)
        {
            PlanLogic plan = new PlanLogic();
            Plan pl = new Plan();
            pl = plan.GetOne(Convert.ToInt32(this.ddlIDPlan.SelectedValue));
            this.txtDescPlan.Text = pl.Descripcion;
        }
        #endregion       

     

       
    }
}

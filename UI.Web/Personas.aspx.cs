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
    public partial class Personas : ABM
    {

        #region cto

        PersonaLogic _Logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new PersonaLogic();
                }
                return _Logic;
            }
        }
        private Business.Entities.Persona Entity { get; set; }
        #endregion
        #region metodos

        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtFechaNacimiento.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.ddlIdPlan.Enabled = enable;
            this.ddlTipoPersona.Enabled = enable;

        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre.ToString();
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.Email;
            this.txtFechaNacimiento.Text = this.Entity.FechaNacimiento.ToString();
            this.txtLegajo.Text = this.Entity.Legajo.ToString();
            this.txtDireccion.Text = this.Entity.Direccion;
            this.txtTelefono.Text = this.Entity.Telefono;
            this.ddlTipoPersona.SelectedValue = this.Entity.TipoPersona.ToString();
            this.ddlIdPlan.SelectedValue = this.Entity.IdPlan.ToString();

        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtFechaNacimiento.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.ddlIdPlan.SelectedIndex = -1;
            this.ddlTipoPersona.SelectedIndex = -1;

        }

        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.txtNombre.Text;
            persona.Apellido = this.txtApellido.Text;
            persona.Email = this.txtEmail.Text;
            persona.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
            persona.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            persona.Direccion = this.txtDireccion.Text;
            persona.Telefono = this.txtTelefono.Text;
            persona.IdPlan = Convert.ToInt32(this.ddlIdPlan.SelectedValue);
            persona.TipoPersona = (Persona.TiposPersonas)Convert.ToInt32(ddlTipoPersona.SelectedIndex);

        }
        private void SaveEntity(Persona persona)
        {
            Logic.Save(persona);
        }

        #endregion
        #region eventos
        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                PlanLogic pl = new PlanLogic();
                List<Plan> listaPlanes = new List<Plan>();
                listaPlanes = pl.GetAll();
                foreach (Plan plan in listaPlanes)
                {
                    this.ddlIdPlan.Items.Add(plan.ID.ToString());

                }
                ddlTipoPersona.Items.Add(Persona.TiposPersonas.Docente.ToString());
                ddlTipoPersona.Items.Add(Persona.TiposPersonas.Alumno.ToString());
                ddlTipoPersona.Items.Add(Persona.TiposPersonas.Administrador.ToString());
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
                    this.Entity = new Persona();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new Persona();
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
            Response.Redirect("~/Personas.aspx");
        }
        #endregion       
    }
}

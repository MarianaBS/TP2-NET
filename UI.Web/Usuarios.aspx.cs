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
    public partial class Usuarios : ABM
    {
        #region cto
        /*public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }*/
        UsuarioLogic _Logic;
        private UsuarioLogic Logic
        {
            get 
            {
                if (_Logic==null)
                {
                    _Logic = new UsuarioLogic();
                }
                return _Logic;
            }
        }
        private Usuario Entity { get; set; }
        #endregion

        #region metodos
        /*private int SelectedID
        {
            get 
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.ViewState["SelectedID"] = value; }
        }

        private bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }
        */
        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtClave.Enabled = enable;
            this.txtNombreUsuario.Enabled = enable;
            this.chbHabilitado.Enabled = enable;
            this.claveUsuarioLabel.Enabled = enable;
            this.txtRepetirClave.Enabled = enable;
            this.repetirClaveLabel.Enabled = enable;
            this.ddlPersona.Enabled = enable;
        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre.ToString();
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.Email;
            this.chbHabilitado.Checked = this.Entity.Habilitado;
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
            this.ddlPersona.SelectedValue = this.Entity.IDPersona.ToString();
            this.txtClave.Text = this.Entity.Clave.ToString();
            this.txtRepetirClave.Text = this.Entity.Clave.ToString();
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
            this.chbHabilitado.Checked = false;
            this.txtNombreUsuario.Text = string.Empty;
            this.ddlPersona.SelectedIndex = -1;
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.chbHabilitado.Checked;
            usuario.IDPersona = Convert.ToInt32(this.ddlPersona.SelectedValue);
        }
        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }
        
        #endregion

        #region eventos
 
        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
                PersonaLogic persona = new PersonaLogic();
                List<Persona> personas = new List<Persona>();
                personas = persona.GetAll();
                
                foreach (Persona pers in personas)
                {
                        ddlPersona.Items.Add(pers.ID.ToString());
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
                this.ddlPersona.Enabled = false;
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
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new Usuario();
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
            Response.Redirect("~/Usuarios.aspx");
        }
        protected void ddlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPersona.SelectedIndex != -1)
            {
                Persona pers = new Persona();
                PersonaLogic persl = new PersonaLogic();
                pers = persl.GetOne(Convert.ToInt32(ddlPersona.SelectedValue));
                this.txtApellido.Text = pers.Apellido.ToString();
                this.txtNombre.Text = pers.Nombre.ToString();
                this.txtEmail.Text = pers.Email.ToString();   
            }
        }
        protected void ddlPersona_Load(object sender, EventArgs e)
        {
            if (ddlPersona.SelectedIndex != -1)
            {
                Persona pers = new Persona();
                PersonaLogic persl = new PersonaLogic();
                pers = persl.GetOne(Convert.ToInt32(ddlPersona.SelectedValue));
                this.txtApellido.Text = pers.Apellido.ToString();
                this.txtNombre.Text = pers.Nombre.ToString();
                this.txtEmail.Text = pers.Email.ToString();
            }
        }
        #endregion          

        

    }
}

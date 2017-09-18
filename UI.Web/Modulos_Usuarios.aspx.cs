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
    public partial class Modulos_Usuarios : ABM
    {
        #region cto
        MuLogic _Logic;
        private MuLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new MuLogic();
                }
                return _Logic;
            }
        }
        private ModuloUsuario Entity { get; set; }


        #endregion
        #region metodos
        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        protected override void EnableForm(bool enable)
        {
            this.ddlModulo.Enabled = enable;
            this.ddlUsuario.Enabled = enable;
            this.chbAlta.Enabled = enable;
            this.chbBaja.Enabled = enable;
            this.chbModifcado.Enabled = enable;
            this.chbConsulta.Enabled = enable;

        }
        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.ddlModulo.SelectedValue = Entity.IdModulo.ToString();
            this.ddlUsuario.SelectedValue = Entity.IdUsuario.ToString();
            this.chbAlta.Checked = Entity.PermiteAlta;
            this.chbBaja.Checked = Entity.PermiteBaja;
            this.chbModifcado.Checked = Entity.PermiteModificacion;
            this.chbConsulta.Checked = Entity.PermiteConsulta;
            
        }
        protected override void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        protected override void ClearForm()
        {
            this.ddlModulo.SelectedIndex = -1;
            this.ddlUsuario.SelectedIndex = -1;
            this.chbAlta.Checked = false;
            this.chbBaja.Checked = false;
            this.chbConsulta.Checked = false;
            this.chbModifcado.Checked = false;
        }

        private void LoadEntity(ModuloUsuario mu)
        {
            mu.IdModulo = Convert.ToInt32(this.ddlModulo.SelectedValue);
            mu.IdUsuario = Convert.ToInt32(this.ddlUsuario.SelectedValue);
            mu.PermiteAlta = this.chbAlta.Checked;
            mu.PermiteBaja = this.chbBaja.Checked;
            mu.PermiteConsulta = this.chbConsulta.Checked;
            mu.PermiteModificacion = this.chbModifcado.Checked;
        }
        private void SaveEntity(ModuloUsuario mu)
        {
            Logic.Save(mu);
        }
        
        #endregion
        #region eventos

        protected override void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                UsuarioLogic user = new UsuarioLogic();
                ModuloLogic mod = new ModuloLogic();
                this.LoadGrid();
                List<Usuario> users = new List<Usuario>();
                users = user.GetAll();
                foreach (Usuario us in users)
                {
                    ddlUsuario.Items.Add(us.ID.ToString());
                }
                List<Modulo> mods = new List<Modulo>();
                mods = mod.GetAll();
                foreach (Modulo mo in mods)
                {
                    ddlModulo.Items.Add(mo.ID.ToString());
                }
            }
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
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
                    this.Entity = new ModuloUsuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.Entity = new ModuloUsuario();
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
            Response.Redirect("~/Modulos_Usuarios.aspx");
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioLogic userl = new UsuarioLogic();
            user = userl.GetOne(Convert.ToInt32(this.ddlUsuario.SelectedValue));
            this.txtApyNom.Text = user.Apellido + "," + user.Nombre;
        }

        protected void ddlUsuario_Load(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioLogic userl = new UsuarioLogic();
            user = userl.GetOne(Convert.ToInt32(this.ddlUsuario.SelectedValue));
            this.txtApyNom.Text = user.Apellido + "," + user.Nombre;
        }

        protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modulo mod = new Modulo();
            ModuloLogic mods = new ModuloLogic();
            mod = mods.GetOne(Convert.ToInt32(this.ddlModulo.SelectedValue));
            this.txtDescripcionModulo.Text = mod.Descripcion;
        }

        protected void ddlModulo_Load(object sender, EventArgs e)
        {
            Modulo mod = new Modulo();
            ModuloLogic mods = new ModuloLogic();
            mod = mods.GetOne(Convert.ToInt32(this.ddlModulo.SelectedValue));
            this.txtDescripcionModulo.Text = mod.Descripcion;

        }
        #endregion

    }
}

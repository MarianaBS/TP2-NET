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
    public partial class ABM : System.Web.UI.Page
    {
        #region cto
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (EstaUsuarioLogueado)
            {
                if (!IsPostBack)
                {
                    CargarPagina();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        #endregion
        #region metodos
        protected int SelectedID
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
        protected bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }
        
        protected int TipoUsuario {
        get
            {
                if (Session["TipoUsuario"] != null)
                {
                    return (int)Session["TipoUsuario"];
                }
                else
                {
                    return -1;
                }
            }
            set { Session["TipoUsuario"] = value; }
        
        }
        protected int IDUsuario
        {
            get
            {
                if (Session["IDUsuario"] != null)
                {
                    return (int)Session["IDUsuario"];
                }
                else
                {
                    return 0;
                }
            }
            set { Session["IDUsuario"] = value; }
        }
        public bool EstaUsuarioLogueado
        {
            get { return IDUsuario != 0; }
        }
        public string NombreUsuario
        {
            get
            {
                if (Session["NombreUsuario"] != null)
                {
                    return Session["NombreUsuario"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set { Session["NombreUsuario"] = value; }
        }
        public void Desloguear()
        {
            IDUsuario = 0;
            //IDPersona = -1;
            NombreUsuario = null;
            //MensajeError = null;
        }

        protected virtual void LoadGrid() {}
        protected virtual void EnableForm(bool enable) { }
        protected virtual void LoadForm(int id) { }
        protected virtual void DeleteEntity(int id) { }
        protected virtual void ClearForm() { }
        protected virtual void Validar() { }
        
        protected void SaveEntity() { }
        protected void LoadEntity() { }
        protected virtual void CargarPagina()
        {

        }

        
        

        #endregion

        
    }
}

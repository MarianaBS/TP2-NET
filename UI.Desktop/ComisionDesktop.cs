using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {


        #region Constructor
        private Comision _comisionActual;
        public Comision ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }
        public ComisionDesktop()
        {
            InitializeComponent();
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            ComisionActual = new ComisionLogic().GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Metodos
        
              private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            List<Plan> Planes = new List<Plan>();
            PlanLogic pl = new PlanLogic();
            Planes = pl.GetAll();
            foreach (Plan v in Planes)
            {
                cbxPlan.Items.Add(v.ID.ToString());
            }


        }

        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = this.ComisionActual.Descripcion.ToString();
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cbxPlan.SelectedItem = this.ComisionActual.IDPlan.ToString();

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Comision();
                ComisionActual.State = Comision.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.Descripcion = this.txtDescripcion.Text.Trim();
                this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
                this.ComisionActual.IDPlan = Convert.ToInt32(this.cbxPlan.SelectedItem);
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
                ComisionActual.State = Comision.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                ComisionActual.State = Comision.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                ComisionActual.State = Comision.States.Deleted;
            }

        
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            new ComisionLogic().Save(ComisionActual);
        }

        public new void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion
        
         #region Eventos
         private void btnAceptar_Click(object sender, EventArgs e)
        {
             this.GuardarCambios();
                   this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
             this.Close();
        }

      
        #endregion    
    
        }


    }



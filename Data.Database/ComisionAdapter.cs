using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        private static List<Comision> _Comision;

        public List<Comision> Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        public List<Comision> GetAll()
        {

            Comision = new List<Comision>();

            this.OpenConnection();

           
            SqlCommand cmdComision = new SqlCommand("select * from comisiones", sqlConn);
            
            SqlDataReader drComision = cmdComision.ExecuteReader();

            while (drComision.Read())
            {
                
                Comision cm = new Comision();
                
                cm.ID = (int)drComision["id_comision"];
                cm.IDPlan = (int)drComision["id_plan"];
                cm.AnioEspecialidad = (int)drComision["anio_especialidad"];
                cm.Descripcion = (string)drComision["desc_comision"];
                Comision.Add(cm);
            }
            
            drComision.Close();
            this.CloseConnection();
           
            return Comision;

        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision cm = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComision = new SqlCommand("Select * from comisiones where id_comision=@id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComision = cmdComision.ExecuteReader();

                if (drComision.Read())
                {
                    cm.ID = (int)drComision["id_comision"];
                    cm.IDPlan = (int)drComision["id_plan"];
                    cm.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    cm.Descripcion = (string)drComision["desc_comision"];
                  
                }
                drComision.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Comisiones", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cm;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar comisiones", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {

                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision,  anio_especialidad = @anio_especialidad, " +
                    " id_plan= @id_plan " +
                    "WHERE id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de la Comision", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into comisiones(desc_comision,anio_especialidad,id_plan) " +
                    "values(@desc_comision,@anio_especialidad,@id_plan) " +
                    "Select @@identity", //esta linea es para recuperar el Id que asigno el sql automaticamente
                    sqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;               
                comision.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear la comision", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}

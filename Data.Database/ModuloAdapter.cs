using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class ModuloAdapter : Adapter
    {
        private static List<Modulo> _Modulos;
        public List<Modulo> Modulos
        {
            get { return _Modulos; }
            set { _Modulos = value; }
        }
        public List<Modulo> GetAll()
        {
            Modulos = new List<Modulo>();
            this.OpenConnection();
            SqlCommand cmdModulos = new SqlCommand("select * from modulos", sqlConn);
            SqlDataReader drModulos = cmdModulos.ExecuteReader();
            while (drModulos.Read())
            {
                Modulo modulo = new Modulo();
                modulo.ID = (int)drModulos["id_modulo"];
                modulo.Descripcion = (string)drModulos["desc_modulo"];
                modulo.Ejecuta = (string)drModulos["ejecuta"];
                Modulos.Add(modulo);
            }
            drModulos.Close();
            this.CloseConnection();
            return Modulos;
        }
        public Business.Entities.Modulo GetOne(int ID)
        {
            Modulo modulo = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("Select * from modulos where id_modulo=@id", sqlConn);
                cmdModulo.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulo = cmdModulo.ExecuteReader();

                if (drModulo.Read())
                {
                    modulo.ID = (int)drModulo["id_modulo"];
                    modulo.Descripcion = (string)drModulo["desc_modulo"];
                    modulo.Ejecuta = (string)drModulo["ejecuta"];
                }
                drModulo.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del modulo", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulo;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete modulos where id_modulo=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar modulo", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos SET desc_modulo = @desc_modulo, ejecuta = @ejecuta " +
                    "WHERE id_modulo=@id", sqlConn);
                
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                cmdSave.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = modulo.Ejecuta;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos del modulo", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into modulos(desc_modulo,ejecuta)" +
                    "values(@desc_modulo,@ejecuta) Select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                cmdSave.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = modulo.Ejecuta;
                modulo.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear modulo", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.New)
            {
                this.Insert(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                this.Update(modulo);
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }

    }
}

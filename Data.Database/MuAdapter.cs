using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MuAdapter : Adapter
    {
        private static List<ModuloUsuario> _Mus;
        public List<ModuloUsuario> Modulos
        {
            get { return _Mus; }
            set { _Mus = value; }
        }
        public List<ModuloUsuario> GetAll()
        {
            Modulos = new List<ModuloUsuario>();
            this.OpenConnection();
            SqlCommand cmdMu = new SqlCommand("select * from modulos_usuarios", sqlConn);
            SqlDataReader drMu = cmdMu.ExecuteReader();
            while (drMu.Read())
            {
                ModuloUsuario muUsuario = new ModuloUsuario();
                muUsuario.ID = (int)drMu["id_modulo_usuario"];
                muUsuario.IdModulo = (int)drMu["id_modulo"];
                muUsuario.IdUsuario = (int)drMu["id_usuario"];
                muUsuario.PermiteAlta = (bool)drMu["alta"];
                muUsuario.PermiteBaja = (bool)drMu["baja"];
                muUsuario.PermiteModificacion = (bool)drMu["modificacion"];
                muUsuario.PermiteConsulta = (bool)drMu["consulta"];
                Modulos.Add(muUsuario);
            }
            drMu.Close();
            this.CloseConnection();

            return Modulos;
        }
        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario muUsuario = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMus = new SqlCommand("Select * from modulos_usuarios where id_modulo_usuario=@id", sqlConn);
                cmdMus.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMu = cmdMus.ExecuteReader();

                if (drMu.Read())
                {
                    muUsuario.ID = (int)drMu["id_modulo_usuario"];
                    muUsuario.IdModulo = (int)drMu["id_modulo"];
                    muUsuario.IdUsuario = (int)drMu["id_usuario"];
                    muUsuario.PermiteAlta = (bool)drMu["alta"];
                    muUsuario.PermiteBaja = (bool)drMu["baja"];
                    muUsuario.PermiteModificacion = (bool)drMu["modificacion"];
                    muUsuario.PermiteConsulta = (bool)drMu["consulta"];
                }
                drMu.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de modulo usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return muUsuario;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete modulos_usuarios where id_modulo_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar modulo usuario", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET id_modulo = @id_modulo, id_usuario = @id_usuario, " +
                    "alta = @alta , baja = @baja, modificacion = @modificacion , consulta = @consulta WHERE id_modulo_usuario=@id", sqlConn);
                
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mu.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = mu.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = mu.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = mu.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = mu.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = mu.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = mu.PermiteConsulta;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de modulo usuario", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion,consulta) " +
                    "values(@id_modulo,@id_usuario,@alta,@baja,@modificacion,@consulta) " +
                    "Select @@identity", //esta linea es para recuperar el Id que asigno el sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = mu.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = mu.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = mu.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = mu.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = mu.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = mu.PermiteConsulta; 
                mu.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear modulo usuario", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(ModuloUsuario mu)
        {
            if (mu.State == BusinessEntity.States.New)
            {
                this.Insert(mu);
            }
            else if (mu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mu.ID);
            }
            else if (mu.State == BusinessEntity.States.Modified)
            {
                this.Update(mu);
            }
            mu.State = BusinessEntity.States.Unmodified;
        }
    }
}

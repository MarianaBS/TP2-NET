using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        private static List<Persona> _Persona;

        public List<Persona> Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        public List<Persona> GetAll()
        {
            
            Persona = new List<Persona>();
           
            this.OpenConnection();

            
            SqlCommand cmdPersona = new SqlCommand("select * from personas", sqlConn);
            
            SqlDataReader drPersona = cmdPersona.ExecuteReader();

            while (drPersona.Read())
            {
               
                Persona prs = new Persona();
               
                prs.ID = (int)drPersona["id_persona"];
                prs.IdPlan = (int)drPersona["id_plan"];
                prs.Telefono = (string)drPersona["telefono"];
                prs.Nombre = (string)drPersona["nombre"];
                prs.Apellido = (string)drPersona["apellido"];
                prs.Email = (string)drPersona["email"];
                prs.Direccion = (string)drPersona["direccion"];
                prs.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                prs.Legajo = (int)drPersona["legajo"];
                prs.TipoPersona = (Business.Entities.Persona.TiposPersonas)drPersona["tipo_persona"];
                Persona.Add(prs);
            }
            
            drPersona.Close();
            this.CloseConnection();
            
            return Persona;

        }

        public Business.Entities.Persona GetOne(int ID)
        {
            Persona prs = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("Select * from personas where id_persona=@id", sqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                if (drPersona.Read())
                {
                    prs.ID = (int)drPersona["id_persona"];
                    prs.IdPlan = (int)drPersona["id_plan"];
                    prs.Telefono = (string)drPersona["telefono"];
                    prs.Nombre = (string)drPersona["nombre"];
                    prs.Apellido = (string)drPersona["apellido"];
                    prs.Email = (string)drPersona["email"];
                    prs.Direccion = (string)drPersona["direccion"];
                    prs.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    prs.Legajo = (int)drPersona["legajo"];
                    prs.TipoPersona = (Business.Entities.Persona.TiposPersonas)drPersona["tipo_persona"];
                
                }
                drPersona.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return prs;
        } 

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar la persona", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {

                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre = @nombre, email = @email, " +
                    "direccion = @direccion, telefono = @telefono, apellido = @apellido, " +
                    "fecha_nac = @fecha_nac, legajo= @legajo, tipo_persona= @tipo_persona, id_plan= @id_plan " +
                    "WHERE id_persona=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de la persona", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into personas(nombre,direccion,telefono,fecha_nac,apellido,email,legajo,tipo_persona,id_plan) " +
                    "values(@nombre,@direccion,@telefono,@fecha_nac,@apellido,@email,@legajo,@tipo_persona,@id_plan) " +
                    "Select @@identity",
                    sqlConn);
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                persona.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
           
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear una persona", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
